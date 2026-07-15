using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Npgsql;
using Tutor.BuildingBlocks.Infrastructure.Security;

namespace Tutor.BuildingBlocks.Tests;

public abstract class BaseTestFactory<TDbContext> : WebApplicationFactory<Program> where TDbContext : DbContext
{
    private static readonly object _schemaLock = new();

    // Tracks which schemas have been dropped+recreated in this process to avoid
    // redundant work across multiple factory instances (one per test class).
    private static readonly HashSet<string> _recreatedSchemas = new();

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            using var scope = BuildServiceProvider(services).CreateScope();
            var scopedServices = scope.ServiceProvider;
            var db = scopedServices.GetRequiredService<TDbContext>();
            var logger = scopedServices.GetRequiredService<ILogger<BaseTestFactory<TDbContext>>>();

            InitializeDatabase(db, scopedServices, logger);
        });
    }

    private void InitializeDatabase(DbContext context, IServiceProvider services, ILogger logger)
    {
        context.Database.EnsureCreated();

        // Each factory drop+recreates only its OWN primary schema (TDbContext) to
        // handle model changes. Dependency schemas are left alone — they are owned
        // and recreated by their respective module's test process. This is important
        // because dotnet test runs assemblies in parallel as separate processes
        // sharing the same database.
        foreach (var contextType in GetRequiredDbContextTypes())
        {
            var ctx = (DbContext)services.GetRequiredService(contextType);
            var schema = ctx.Model.GetDefaultSchema();

            if (contextType == typeof(TDbContext))
            {
                // Own schema: drop+recreate once per process to pick up model changes.
                bool alreadyRecreated;
                lock (_schemaLock)
                {
                    alreadyRecreated = !_recreatedSchemas.Add(schema!);
                }

                if (!alreadyRecreated && schema != null)
                {
                    ctx.Database.ExecuteSqlRaw($"DROP SCHEMA IF EXISTS \"{schema}\" CASCADE");
                    ctx.Database.GetService<IRelationalDatabaseCreator>().CreateTables();
                }
            }
            else
            {
                // Dependency schema: create if absent, skip if it already exists.
                try
                {
                    ctx.Database.GetService<IRelationalDatabaseCreator>().CreateTables();
                }
                catch (Exception)
                {
                    // Schema already exists — created by its owning module's test
                    // process or persisted from a previous test run.
                }
            }
        }

        try
        {
            foreach (var folder in GetOrderedTestDataFolders())
            {
                if (!Directory.Exists(folder)) continue;
                var scriptFiles = Directory.GetFiles(folder).Order().ToArray();
                var script = string.Join('\n', scriptFiles.Select(File.ReadAllText));
                context.Database.ExecuteSqlRaw(script);
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred seeding the database with test data. Error: {Message}", ex.Message);
            throw;
        }
    }

    /// <summary>
    /// Returns all DbContext types this factory needs tables for, in creation order.
    /// Override in factories with cross-module test data dependencies to include
    /// dependency contexts. Each type listed here must also be registered in
    /// ReplaceNeededDbContexts so it points to the test database.
    /// </summary>
    protected virtual Type[] GetRequiredDbContextTypes() => [typeof(TDbContext)];

    /// <summary>
    /// Returns script folders in dependency order. Override in factories
    /// with cross-module dependencies to include dependent modules' TestData
    /// folders before the factory's own (e.g., Courses → own).
    /// </summary>
    protected virtual List<string> GetOrderedTestDataFolders() =>
        ["../../../TestData/"];

    private ServiceProvider BuildServiceProvider(IServiceCollection services)
    {
        return ReplaceNeededDbContexts(services).BuildServiceProvider();
    }

    protected abstract IServiceCollection ReplaceNeededDbContexts(IServiceCollection services);

    protected static Action<DbContextOptionsBuilder> SetupTestContext()
    {
        var dataSourceBuilder = new NpgsqlDataSourceBuilder(CreateConnectionString());
        dataSourceBuilder.EnableDynamicJson();
        var dataSource = dataSourceBuilder.Build();

        return opt => opt.UseNpgsql(dataSource);
    }

    protected static string CreateConnectionString()
    {
        var server = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
        var port = Environment.GetEnvironmentVariable("DATABASE_PORT") ?? "5432";
        var database = EnvironmentConnection.GetSecret("DATABASE_SCHEMA") ?? "tutor-v3.0-test";
        var user = EnvironmentConnection.GetSecret("DATABASE_USERNAME") ?? "postgres";
        var password = EnvironmentConnection.GetSecret("DATABASE_PASSWORD") ?? "admin";
        var pooling = Environment.GetEnvironmentVariable("DATABASE_POOLING") ?? "true";

        var connectionString = $"Server={server};Port={port};Database={database};User ID={user};Password={password};Pooling={pooling};Include Error Detail=True";
        return connectionString;
    }
}
