using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Tutor.API;
using Tutor.BuildingBlocks.Infrastructure.Security;
using Tutor.Stakeholders.Infrastructure.Database;

namespace Tutor.Stakeholders.Tests;

public class StakeholdersTestFactory<TStartup> : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            using var scope = BuildServiceProvider(services).CreateScope();
            var scopedServices = scope.ServiceProvider;  
            var db = scopedServices.GetRequiredService<StakeholdersContext>();
            var logger = scopedServices.GetRequiredService<ILogger<StakeholdersTestFactory<TStartup>>>();

            InitializeDatabase(db, "../../../TestData/", logger);
        });
    }

    private static void InitializeDatabase(DbContext context, string scriptFolder, ILogger logger)
    {
        context.Database.EnsureCreated();

        try
        {
            var scriptFiles = Directory.GetFiles(scriptFolder);
            var script = string.Join('\n', scriptFiles.Select(File.ReadAllText));
            context.Database.ExecuteSqlRaw(script);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred seeding the database with test data. Error: {Message}", ex.Message);
        }
    }

    private static ServiceProvider BuildServiceProvider(IServiceCollection services)
    {
        var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<StakeholdersContext>));
        services.Remove(descriptor!);

        services.AddDbContext<StakeholdersContext>(opt => opt.UseNpgsql(CreateConnectionStringForTest()));
        return services.BuildServiceProvider();
    }

    private static string CreateConnectionStringForTest()
    {
        // TODO: Think about these environment variables if I need them as such.
        // TODO: Examine near the end if all project dependencies are justified.
        var server = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
        var port = Environment.GetEnvironmentVariable("DATABASE_PORT") ?? "5432";
        var database = EnvironmentConnection.GetSecret("DATABASE_SCHEMA") ?? "tutor-v4-test";
        var user = EnvironmentConnection.GetSecret("DATABASE_USERNAME") ?? "postgres";
        var password = EnvironmentConnection.GetSecret("DATABASE_PASSWORD") ?? "super";
        var integratedSecurity = Environment.GetEnvironmentVariable("DATABASE_INTEGRATED_SECURITY") ?? "false";
        var pooling = Environment.GetEnvironmentVariable("DATABASE_POOLING") ?? "true";

        return
            $"Server={server};Port={port};Database={database};User ID={user};Password={password};Integrated Security={integratedSecurity};Pooling={pooling};Include Error Detail=True";
    }
}