using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Administrator.Courses;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Interfaces.Management;

namespace Tutor.Courses.Tests.Integration.Management;

[Collection("Sequential")]
public class CourseQueryTests : BaseCoursesIntegrationTest
{
    public CourseQueryTests(CoursesTestFactory factory) : base(factory) { }

    [Fact]
    public void Retrieves_courses()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);

        var result = ((OkObjectResult)controller.GetAll(0, 0).Result)?.Value as PagedResult<CourseDto>;

        result.ShouldNotBeNull();
        result.Results.Count.ShouldBe(5);
        result.TotalCount.ShouldBe(5);
    }

    private static CourseController CreateController(IServiceScope scope)
    {
        return new CourseController(scope.ServiceProvider.GetRequiredService<ICourseService>())
        {
            ControllerContext = BuildContext("0", "administrator")
        };
    }
}