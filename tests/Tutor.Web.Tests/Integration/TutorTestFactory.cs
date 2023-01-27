using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Configurations;
using DotNet.Testcontainers.Containers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Tutor.Infrastructure.Database;
using Tutor.Infrastructure.Database.EventStore.Postgres;
using Xunit;

namespace Tutor.Web.Tests.Integration;

public class TutorApplicationTestFactory<TStartup> : WebApplicationFactory<Startup>, IAsyncLifetime
{
    private readonly TestcontainerDatabase _dbContainer;
    private readonly TestcontainerDatabase _dbEventContainer;
    private readonly IConfiguration _config;

    public TutorApplicationTestFactory()
    {
        _config = InitConfiguration();
        var testContainers = _config.GetValue("TESTCONTAINERS", true);
        if (testContainers)
        {
            _dbContainer = new TestcontainersBuilder<PostgreSqlTestcontainer>()
                    .WithDatabase(new PostgreSqlTestcontainerConfiguration
                    {
                        Database = "smart_tutor_test",
                        Username = "postgres",
                        Password = "postgres",
                    })
                    .WithImage("postgres")
                    .WithCleanUp(true)
                    .Build();
            _dbEventContainer = new TestcontainersBuilder<PostgreSqlTestcontainer>()
                    .WithDatabase(new PostgreSqlTestcontainerConfiguration
                    {
                        Database = "smart_tutor_test_events",
                        Username = "postgres",
                        Password = "postgres",
                    })
                    .WithImage("postgres")
                    .WithCleanUp(true)
                    .Build();
        }
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            using var scope = BuildServiceProvider(services).CreateScope();
            var scopedServices = scope.ServiceProvider;  
            var db = scopedServices.GetRequiredService<TutorContext>();
            var eventDb = scopedServices.GetRequiredService<EventContext>();
            var logger = scopedServices.GetRequiredService<ILogger<TutorApplicationTestFactory<TStartup>>>();

            InitializeDatabase(db, "../../../TestData/Scripts/", logger);
            InitializeDatabase(eventDb, "../../../TestData/Scripts/Events/", logger);
        });
    }

    private static void InitializeDatabase(DbContext context, string scriptFolder, ILogger<TutorApplicationTestFactory<TStartup>> logger)
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

    private ServiceProvider BuildServiceProvider(IServiceCollection services)
    {
        var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<TutorContext>));
        services.Remove(descriptor);
        var eventDescriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<EventContext>));
        services.Remove(eventDescriptor);

        services.AddDbContext<TutorContext>(opt => opt.UseNpgsql(CreateConnectionStringForTest()));
        services.AddDbContext<EventContext>(opt => opt.UseNpgsql(CreateConnectionStringForEvents()));
        return services.BuildServiceProvider();
    }

    private string CreateConnectionStringForTest()
    {
        var testContainers = _config.GetValue("TESTCONTAINERS", true);
        if (testContainers) return _dbContainer.ConnectionString;

        var server = _config.GetValue("DATABASE_HOST", "localhost");
        var port = _config.GetValue("DATABASE_PORT", "5432");
        var database = _config.GetValue("DATABASE_SCHEMA", "smart-tutor-test");
        var user = _config.GetValue("DATABASE_USERNAME", "postgres");
        var password = _config.GetValue("DATABASE_PASSWORD", "super");
        var integratedSecurity = _config.GetValue("DATABASE_INTEGRATED_SECURITY", "false");
        var pooling = _config.GetValue("DATABASE_POOLING", "true");

        return
            $"Server={server};Port={port};Database={database};User ID={user};Password={password};Integrated Security={integratedSecurity};Pooling={pooling};Include Error Detail=True";
    }

    private string CreateConnectionStringForEvents()
    {
        var testContainers = _config.GetValue("TESTCONTAINERS", true);
        if (testContainers) return _dbEventContainer.ConnectionString;

        var server = _config.GetValue("DATABASE_HOST", "localhost");
        var port = _config.GetValue("DATABASE_PORT", "5432");
        var database = _config.GetValue("EVENT_DATABASE_SCHEMA", "smart-tutor-test-events");
        var user =  _config.GetValue("DATABASE_USERNAME", "postgres");
        var password = _config.GetValue("DATABASE_PASSWORD", "super");
        var integratedSecurity = _config.GetValue("DATABASE_INTEGRATED_SECURITY", "false");
        var pooling = _config.GetValue("DATABASE_POOLING", "true");

        return
            $"Server={server};Port={port};Database={database};User ID={user};Password={password};Integrated Security={integratedSecurity};Pooling={pooling};";
    }

    public IConfiguration InitConfiguration()
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.test.json")
            .AddEnvironmentVariables()
            .Build();
        return config;
    }

    public async Task InitializeAsync()
    {
        var testContainers = _config.GetValue("TESTCONTAINERS", true);
        if (testContainers)
        {
            await _dbContainer.StartAsync();
            await _dbEventContainer.StartAsync();
        }
    }

    public new async Task DisposeAsync()
    {
        var testContainers = _config.GetValue("TESTCONTAINERS", true);
        if (testContainers)
        {
            await _dbContainer.DisposeAsync();
            await _dbEventContainer.DisposeAsync();
        }
    }
}