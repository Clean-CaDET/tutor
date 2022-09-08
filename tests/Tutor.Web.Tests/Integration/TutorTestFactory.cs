using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;
using Tutor.Infrastructure;
using Tutor.Infrastructure.Database;
using Tutor.Infrastructure.Database.EventStore;
using Tutor.Infrastructure.Database.EventStore.Configuration;
using Tutor.Infrastructure.Database.EventStore.Configuration.EventSerializerConfiguration;
using Tutor.Infrastructure.Database.EventStore.Postgres.Configuration;
using Tutor.Infrastructure.Security;

namespace Tutor.Web.Tests.Integration;

public class TutorApplicationTestFactory<TStartup> : WebApplicationFactory<Startup>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            using var scope = BuildServiceProvider(services).CreateScope();
            var scopedServices = scope.ServiceProvider;
            var db = scopedServices.GetRequiredService<TutorContext>();
            var eventStore = scopedServices.GetRequiredService<IEventStore>();
            var logger = scopedServices.GetRequiredService<ILogger<TutorApplicationTestFactory<TStartup>>>();

            InitializeDatabase(db, LoadSeedingScript("../../../TestData/Scripts/", logger), logger);
            InitializeEventStore(eventStore, LoadSeedingScript("../../../TestData/Scripts/Events/", logger), logger);
        });
    }

    private static string LoadSeedingScript(string scriptFolder, ILogger<TutorApplicationTestFactory<TStartup>> logger)
    {
        try
        {
            var scriptFiles = Directory.GetFiles(scriptFolder);
            return string.Join('\n', scriptFiles.Select(File.ReadAllText));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while loading seeding scripts. Error: {Message}", ex.Message);
            return "";
        }
    }

    private static void InitializeDatabase(DbContext context, string script, ILogger<TutorApplicationTestFactory<TStartup>> logger)
    {
        try
        {
            context.Database.EnsureCreated();
            context.Database.ExecuteSqlRaw(script);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while seeding the database with test data. Error: {Message}", ex.Message);
        }
    }

    private static void InitializeEventStore(IEventStore eventStore, string script, ILogger<TutorApplicationTestFactory<TStartup>> logger)
    {     
        try
        {
            eventStore.EnsureCreated();
            eventStore.ExecuteRaw(script);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while seeding the event store with test data. Error: {Message}", ex.Message);
        }
    }

    private static ServiceProvider BuildServiceProvider(IServiceCollection services)
    {
        var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<TutorContext>));
        services.Remove(descriptor);
        services.RemoveEventStore();

        services.AddDbContext<TutorContext>(opt => opt.UseNpgsql(CreateConnectionStringForTest()));
        services.AddEventStore(opt => opt.UsePostgres(CreateConnectionStringForEvents())
                                        .UseDefaultSerializer(EventConfiguration.SerializationConfiguration));
        return services.BuildServiceProvider();
    }

    private static string CreateConnectionStringForTest()
    {
        var server = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
        var port = Environment.GetEnvironmentVariable("DATABASE_PORT") ?? "5432";
        var database = EnvironmentConnection.GetSecret("DATABASE_SCHEMA") ?? "smart-tutor-test";
        var user = EnvironmentConnection.GetSecret("DATABASE_USERNAME") ?? "postgres";
        var password = EnvironmentConnection.GetSecret("DATABASE_PASSWORD") ?? "super";
        var integratedSecurity = Environment.GetEnvironmentVariable("DATABASE_INTEGRATED_SECURITY") ?? "false";
        var pooling = Environment.GetEnvironmentVariable("DATABASE_POOLING") ?? "true";

        return
            $"Server={server};Port={port};Database={database};User ID={user};Password={password};Integrated Security={integratedSecurity};Pooling={pooling};";
    }

    private static string CreateConnectionStringForEvents()
    {
        var server = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
        var port = Environment.GetEnvironmentVariable("DATABASE_PORT") ?? "5432";
        var database = EnvironmentConnection.GetSecret("EVENT_DATABASE_SCHEMA") ?? "smart-tutor-test-events";
        var user = EnvironmentConnection.GetSecret("DATABASE_USERNAME") ?? "postgres";
        var password = EnvironmentConnection.GetSecret("DATABASE_PASSWORD") ?? "super";
        var integratedSecurity = Environment.GetEnvironmentVariable("DATABASE_INTEGRATED_SECURITY") ?? "false";
        var pooling = Environment.GetEnvironmentVariable("DATABASE_POOLING") ?? "true";

        return
            $"Server={server};Port={port};Database={database};User ID={user};Password={password};Integrated Security={integratedSecurity};Pooling={pooling};";
    }
}