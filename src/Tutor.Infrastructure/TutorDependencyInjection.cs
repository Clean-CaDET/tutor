using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Tutor.Infrastructure.Database;
using Tutor.Infrastructure.Database.EventStore;
using Tutor.Infrastructure.Security;

namespace Tutor.Infrastructure
{
    public static class TutorDependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TutorContext>(opt =>
                opt.UseNpgsql(CreateConnectionStringFromEnvironment()));
            services.AddDbContext<EventContext>(opt =>
                opt.UseNpgsql(CreateConnectionStringFromEnvironment()));
            services.AddScoped<IEventStore, PostgresStore>();

            return services;
        }

        private static string CreateConnectionStringFromEnvironment()
        {
            var server = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
            var port = Environment.GetEnvironmentVariable("DATABASE_PORT") ?? "5432";
            var database = EnvironmentConnection.GetSecret("DATABASE_SCHEMA") ?? "smart-tutor-db";
            var user = EnvironmentConnection.GetSecret("DATABASE_USERNAME") ?? "postgres";
            var password = EnvironmentConnection.GetSecret("DATABASE_PASSWORD") ?? "super";
            var integratedSecurity = Environment.GetEnvironmentVariable("DATABASE_INTEGRATED_SECURITY") ?? "false";
            var pooling = Environment.GetEnvironmentVariable("DATABASE_POOLING") ?? "true";

            return
                $"Server={server};Port={port};Database={database};User ID={user};Password={password};Integrated Security={integratedSecurity};Pooling={pooling};";
        }
    }
}
