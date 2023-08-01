using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.BuildingBlocks.Infrastructure.Database;
using Tutor.Courses.API.Internal;
using Tutor.Courses.API.Public.Authoring;
using Tutor.Courses.API.Public.Learning;
using Tutor.Courses.API.Public.Management;
using Tutor.Courses.API.Public.Monitoring;
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
        // Registers all profiles since it works on the assembly
        services.AddAutoMapper(typeof(CourseProfile).Assembly);
        SetupCore(services);
        SetupInfrastructure(services);
        return services;
    }
    
    private static void SetupCore(IServiceCollection services)
    {
        services.AddScoped<IOwnedCourseService, OwnedCourseService>();
        services.AddScoped<IOwnershipValidator, OwnedCourseService>();
        services.AddScoped<IUnitService, UnitService>();

        services.AddScoped<IEnrolledCourseService, EnrolledCourseService>();
        services.AddScoped<IEnrollmentValidator, EnrolledCourseService>();

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
        services.AddScoped<IUnitEnrollmentRepository, UnitEnrollmentDatabaseRepository>();
        services.AddScoped<ICourseOwnershipRepository, CourseOwnershipDatabaseRepository>();
        services.AddScoped<ICourseRepository, CourseDatabaseRepository>();
        services.AddScoped<IGroupRepository, GroupDatabaseRepository>();

        services.AddScoped<ICoursesUnitOfWork, CoursesUnitOfWork>();
        services.AddDbContext<CoursesContext>(opt =>
            opt.UseNpgsql(DbConnectionStringBuilder.Build("courses"),
                x => x.MigrationsHistoryTable("__EFMigrationsHistory", "courses")));
    }
}