using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Administrator.Courses;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Public.Authoring;
using Tutor.Courses.API.Public.Management;
using Tutor.Courses.Infrastructure.Database;

namespace Tutor.Courses.Tests.Integration.Management;

[Collection("Sequential")]
public class InstructorOwnershipTests : BaseCoursesIntegrationTest
{
    public InstructorOwnershipTests(CoursesTestFactory factory) : base(factory) { }

    [Fact]
    public void Gets_all()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);

        var result = ((OkObjectResult)controller.GetAll(-52).Result)?.Value as List<CourseDto>;

        result.ShouldNotBeNull();
        result.Count.ShouldBe(3);
    }

    [Fact]
    public void Creates()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<CoursesContext>();
        dbContext.Database.BeginTransaction();

        var result = (OkObjectResult)controller.Create(-51, -3);

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(200);
        var storedEntity = dbContext.CourseOwnerships.FirstOrDefault(o => o.Course.Id == -3 && o.InstructorId == -51);
        storedEntity.ShouldNotBeNull();
    }

    [Fact]
    public void Deletes()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<CoursesContext>();
        dbContext.Database.BeginTransaction();

        var result = (OkResult)controller.Delete(-51, -1);

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(200);
        var storedOwnerships = dbContext.CourseOwnerships.FirstOrDefault(o => o.Course.Id == -1 && o.InstructorId == -51);
        storedOwnerships.ShouldBeNull();
        var storedCourse = dbContext.Courses.FirstOrDefault(i => i.Id == -1);
        storedCourse.ShouldNotBeNull();
    }

    private static InstructorOwnershipController CreateController(IServiceScope scope)
    {
        return new InstructorOwnershipController(scope.ServiceProvider.GetRequiredService<ICourseOwnershipService>(),
            scope.ServiceProvider.GetRequiredService<IOwnedCourseService>())
        {
            ControllerContext = BuildContext("0", "administrator")
        };
    }
}