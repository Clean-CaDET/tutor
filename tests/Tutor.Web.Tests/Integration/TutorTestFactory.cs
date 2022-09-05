using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;
using Tutor.Infrastructure.Database;
using Tutor.Infrastructure.Database.EventStore.Postgres;
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

    private static ServiceProvider BuildServiceProvider(IServiceCollection services)
    {
        var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<TutorContext>));
        services.Remove(descriptor);
        var eventDescriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<EventContext>));
        services.Remove(eventDescriptor);

        services.AddDbContext<TutorContext>(opt => opt.UseNpgsql(CreateConnectionStringForTest()));
        services.AddDbContext<EventContext>(opt => opt.UseNpgsql(CreateConnectionStringForEvents()));
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