using Microsoft.Extensions.DependencyInjection;

namespace Tutor.LearningTasks.Infrastructure;

public static class LearningTasksStartup
{
    public static IServiceCollection ConfigureLearningTasksModule(this IServiceCollection services)
    {
        //services.AddAutoMapper(typeof(LearningTaskProfile).Assembly);
        //SetupCore(services);
        //SetupInfrastructure(services);
        return services;
    }

    private static void SetupInfrastructure(IServiceCollection services)
    {
        throw new NotImplementedException();
    }

    private static void SetupCore(IServiceCollection services)
    {
        throw new NotImplementedException();
    }
}