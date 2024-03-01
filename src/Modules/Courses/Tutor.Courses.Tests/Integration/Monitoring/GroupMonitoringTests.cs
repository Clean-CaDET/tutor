using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Instructor.Monitoring;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Public.Monitoring;

namespace Tutor.Courses.Tests.Integration.Monitoring;

[Collection("Sequential")]
public class GroupMonitoringTests : BaseCoursesIntegrationTest
{
    public GroupMonitoringTests(CoursesTestFactory factory) : base(factory) {}
    
    [Theory]
    [InlineData("-51", -1, 3)]
    [InlineData("-52", -2, 2)]
    public void Retrieves_owned_course_groups(string instructorId, int courseId, int expectedResult)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, instructorId);
        var result = ((OkObjectResult)controller.GetCourseGroups(courseId).Result)?.Value as PagedResult<GroupDto>;

        result.ShouldNotBeNull();
        result.Results.Count.ShouldBe(expectedResult);
    }

    [Theory]
    [InlineData("-51", -1, -1, 4)]
    [InlineData("-51", -1, 0, 5)]
    public void Retrieves_learners(string instructorId, int courseId, int groupId, int expectedCount)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, instructorId);
        var result = ((OkObjectResult)controller.GetLearners(courseId, groupId, 1, 2).Result)?.Value as PagedResult<LearnerDto>;

        result.ShouldNotBeNull();
        result.TotalCount.ShouldBe(expectedCount);
    }

    private static GroupMonitoringController CreateController(IServiceScope scope, string id)
    {
        return new GroupMonitoringController(scope.ServiceProvider.GetRequiredService<IGroupMonitoringService>())
        {
            ControllerContext = BuildContext(id, "instructor")
        };
    }
}