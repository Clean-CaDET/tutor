using Castle.DynamicProxy;
using Tutor.BuildingBlocks.Infrastructure.Interceptors;

namespace Tutor.API.Startup;

public static class InterceptorsConfiguration
{
    public static IServiceCollection ConfigureInterceptors(this IServiceCollection services)
    {
        services.AddSingleton(new ProxyGenerator());
        services.AddScoped<IInterceptor, LoggingInterceptor>();
        return services;
    }
}