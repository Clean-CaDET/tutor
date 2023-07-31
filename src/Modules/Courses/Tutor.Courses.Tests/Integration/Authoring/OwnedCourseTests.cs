using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Instructor.Authoring;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Public.Authoring;
using Tutor.Courses.Infrastructure.Database;

namespace Tutor.Courses.Tests.Integration.Authoring;

[Collection("Sequential")]
public class OwnedCourseTests : BaseCoursesIntegrationTest
{
    public OwnedCourseTests(CoursesTestFactory factory) : base(factory) { }

    [Theory]
    [InlineData("-51", 1)]
    [InlineData("-52", 3)]
    public void Retrieves_owned_courses(string instructorId, int expectedCourseCount)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, instructorId);
        var result = ((OkObjectResult)controller.GetOwnedCourses().Result)?.Value as List<CourseDto>;

        result.ShouldNotBeNull();
        result.Count.ShouldBe(expectedCourseCount);
    }

    [Fact]
    public void Retrieves_owned_course_with_units()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-51");

        var result = ((OkObjectResult)controller.GetCourseWithUnits(-1).Result)?.Value as CourseDto;

        result.ShouldNotBeNull();
        result.Id.ShouldBe(-1);
        result.KnowledgeUnits.Count.ShouldBe(3);
    }

    [Fact]
    public void Updates_course_description()
    {
        using var scope = Factory.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<CoursesContext>();
        var controller = CreateController(scope, "-51");
        var updateCourse = new CourseDto
        {
            Id = -1,
            Name = "Test",
            Code = "Test",
            Description = "Test",
            StartDate = DateTime.UnixEpoch
        };
        dbContext.Database.BeginTransaction();

        var result = ((OkObjectResult)controller.Update(updateCourse).Result)?.Value as CourseDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Id.ShouldBe(-1);
        result.Description.ShouldBe("Test");
        var storedCourse = dbContext.Courses.FirstOrDefault(c => c.Id == -1);
        storedCourse.ShouldNotBeNull();
        storedCourse.Description.ShouldBe(updateCourse.Description);
    }

    private static OwnedCourseController CreateController(IServiceScope scope, string id)
    {
        return new OwnedCourseController(scope.ServiceProvider.GetRequiredService<IOwnedCourseService>())
        {
            ControllerContext = BuildContext(id, "instructor")
        };
    }
}