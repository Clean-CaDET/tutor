using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Administrator.Courses;
using Tutor.Courses.API.Dtos.Groups;
using Tutor.Courses.API.Public.Management;
using Tutor.Courses.Infrastructure.Database;

namespace Tutor.Courses.Tests.Integration.Management;

[Collection("Sequential")]
public class CourseOwnerTests : BaseCoursesIntegrationTest
{
    public CourseOwnerTests(CoursesTestFactory factory) : base(factory) { }

    [Fact]
    public void Gets_all()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);

        var result = ((OkObjectResult)controller.GetAll(-2).Result)?.Value as List<InstructorDto>;

        result.ShouldNotBeNull();
        result.Count.ShouldBe(1);
    }

    [Fact]
    public void Creates()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<CoursesContext>();
        dbContext.Database.BeginTransaction();

        var result = (OkObjectResult)controller.Create(-3, -51);

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

        var result = (OkResult)controller.Delete(-1, -51);

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(200);
        var storedOwnerships = dbContext.CourseOwnerships.FirstOrDefault(o => o.Course.Id == -1 && o.InstructorId == -51);
        storedOwnerships.ShouldBeNull();
        var storedCourse = dbContext.Courses.FirstOrDefault(i => i.Id == -1);
        storedCourse.ShouldNotBeNull();
    }

    private static CourseOwnerController CreateController(IServiceScope scope)
    {
        return new CourseOwnerController(scope.ServiceProvider.GetRequiredService<ICourseOwnershipService>())
        {
            ControllerContext = BuildContext("0", "administrator")
        };
    }
}