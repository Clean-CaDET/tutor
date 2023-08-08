using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Administrator.Courses;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Public.Learning;

namespace Tutor.Courses.Tests.Integration.Management;

[Collection("Sequential")]
public class LearnerMembershipTests : BaseCoursesIntegrationTest
{
    public LearnerMembershipTests(CoursesTestFactory factory) : base(factory) { }

    [Fact]
    public void Retrieves_learner_courses()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);

        var result = ((OkObjectResult)controller.GetAll(-1, 0, 0).Result)?.Value as PagedResult<CourseDto>;

        result.ShouldNotBeNull();
        result.Results.Count.ShouldBe(2);
        result.TotalCount.ShouldBe(2);
    }

    private static LearnerMembershipController CreateController(IServiceScope scope)
    {
        return new LearnerMembershipController(scope.ServiceProvider.GetRequiredService<IEnrolledCourseService>())
        {
            ControllerContext = BuildContext("0", "administrator")
        };
    }
}