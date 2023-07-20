using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.BuildingBlocks.Infrastructure.Database;
using Tutor.BuildingBlocks.Infrastructure.Security;
using Tutor.Courses.API.Interfaces.Authoring;
using Tutor.Courses.API.Interfaces.Learning;
using Tutor.Courses.API.Interfaces.Management;
using Tutor.Courses.API.Interfaces.Monitoring;
using Tutor.Courses.Core.Domain;
using Tutor.Courses.Core.Domain.RepositoryInterfaces;
using Tutor.Courses.Core.Mappers;
using Tutor.Courses.Core.UseCases;
using Tutor.Courses.Core.UseCases.Authoring;
using Tutor.Courses.Core.UseCases.Learning;
using Tutor.Courses.Core.UseCases.Management;
using Tutor.Courses.Core.UseCases.Monitoring;
using Tutor.Courses.Infrastructure.Database;
using Tutor.Courses.Infrastructure.Database.Repositories;

namespace Tutor.Courses.Infrastructure;

public static class CoursesStartup
{
    public static IServiceCollection ConfigureCoursesModule(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(CourseProfile).Assembly);
        services.AddAutoMapper(typeof(GroupEnrollmentProfile).Assembly);
        services.AddAutoMapper(typeof(StakeholdersProfile).Assembly);
        SetupCore(services);
        SetupInfrastructure(services);
        return services;
    }
    
    private static void SetupCore(IServiceCollection services)
    {
        services.AddScoped<IOwnedCoursesService, OwnedCourseService>();
        services.AddScoped<IUnitService, UnitService>();

        services.AddScoped<IEnrolledCoursesService, EnrolledCoursesService>();

        services.AddScoped<ICourseOwnershipService, CourseOwnershipService>();
        services.AddScoped<ICourseService, CourseService>();
        services.AddScoped<IGroupMembershipService, GroupMembershipService>();
        services.AddScoped<IGroupService, GroupService>();

        services.AddScoped<IEnrollmentService, EnrollmentService>();
        services.AddScoped<IGroupMonitoringService, GroupMonitoringService>();
    }

    private static void SetupInfrastructure(IServiceCollection services)
    {
        services.AddScoped<IOwnedCourseRepository, OwnedCourseDatabaseRepository>();
        services.AddScoped(typeof(ICrudRepository<KnowledgeUnit>), typeof(CrudDatabaseRepository<KnowledgeUnit, CoursesContext>));
        services.AddScoped<IEnrollmentRepository, EnrollmentDatabaseRepository>();
        services.AddScoped<ICourseOwnershipRepository, CourseOwnershipDatabaseRepository>();
        services.AddScoped<ICourseRepository, CourseDatabaseRepository>();
        services.AddScoped<IGroupRepository, GroupDatabaseRepository>();

        services.AddScoped<ICoursesUnitOfWork, CoursesUnitOfWork>();
        services.AddDbContext<CoursesContext>(opt =>
            opt.UseNpgsql(CreateConnectionStringFromEnvironment()));
    }

    private static string CreateConnectionStringFromEnvironment()
    {
        var server = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
        var port = Environment.GetEnvironmentVariable("DATABASE_PORT") ?? "5432";
        var database = EnvironmentConnection.GetSecret("DATABASE_SCHEMA") ?? "tutor-v4";
        var user = EnvironmentConnection.GetSecret("DATABASE_USERNAME") ?? "postgres";
        var password = EnvironmentConnection.GetSecret("DATABASE_PASSWORD") ?? "super";
        var integratedSecurity = Environment.GetEnvironmentVariable("DATABASE_INTEGRATED_SECURITY") ?? "false";
        var pooling = Environment.GetEnvironmentVariable("DATABASE_POOLING") ?? "true";

        return
            $"Server={server};Port={port};Database={database};User ID={user};Password={password};Integrated Security={integratedSecurity};Pooling={pooling};";
    }
}