using System;
using Castle.DynamicProxy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tutor.Core.BuildingBlocks.EventSourcing;
using Tutor.Infrastructure.Database;
using Tutor.Infrastructure.Database.EventStore.Postgres;
using Tutor.Infrastructure.Interceptors;
using Tutor.Infrastructure.Security;
using Tutor.Infrastructure.Smtp;

namespace Tutor.Infrastructure;

public static class TutorDependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TutorContext>(opt =>
            opt.UseNpgsql(CreateConnectionStringFromEnvironment()));
        services.AddDbContext<EventContext>(opt =>
            opt.UseNpgsql(CreateConnectionStringFromEnvironment()));
        services.AddScoped<IEventStore, PostgresStore>();

        services.AddScoped<IEmailSender, EmailSender>();
        var emailConfig = CreateEmailConfigurationFromEnvironment();
        services.AddSingleton(emailConfig);

        services.AddSingleton(new ProxyGenerator());
        services.AddScoped<IInterceptor, LoggingInterceptor>();
        return services;
    }

    private static string CreateConnectionStringFromEnvironment()
    {
        var server = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
        var port = Environment.GetEnvironmentVariable("DATABASE_PORT") ?? "5432";
        var database = EnvironmentConnection.GetSecret("DATABASE_SCHEMA") ?? "tutor-v2";
        var user = EnvironmentConnection.GetSecret("DATABASE_USERNAME") ?? "postgres";
        var password = EnvironmentConnection.GetSecret("DATABASE_PASSWORD") ?? "super";
        var integratedSecurity = Environment.GetEnvironmentVariable("DATABASE_INTEGRATED_SECURITY") ?? "false";
        var pooling = Environment.GetEnvironmentVariable("DATABASE_POOLING") ?? "true";

        return
            $"Server={server};Port={port};Database={database};User ID={user};Password={password};Integrated Security={integratedSecurity};Pooling={pooling};";
    }

    private static EmailConfiguration CreateEmailConfigurationFromEnvironment()
    {
        var smtpHost = Environment.GetEnvironmentVariable("SMTP_HOST") ?? "smtp.gmail.com";
        var smtpPort = Environment.GetEnvironmentVariable("SMTP_PORT") ?? "587";
        var username = Environment.GetEnvironmentVariable("SMTP_USERNAME") ?? "perapera2359@gmail.com";
        var password = Environment.GetEnvironmentVariable("SMTP_PASSWORD") ?? "rreskjmprcqsbfjg";
        var proxyAddress = Environment.GetEnvironmentVariable("PROXY_ADDRESS") ?? "proxy.uns.ac.rs";
        var proxyPort = Environment.GetEnvironmentVariable("PROXY_PORT") ?? "8080";

        return new EmailConfiguration
        {
            SmtpHost = smtpHost,
            SmtpPort = int.Parse(smtpPort),
            Username = username,
            Password = password,
            ProxyAddress = proxyAddress,
            ProxyPort = int.Parse(proxyPort)
        };
    }
}