using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Instructor.Monitoring;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Interfaces.Monitoring;

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
        var result = ((OkObjectResult)controller.GetCourseGroups(courseId).Result)?.Value as List<GroupDto>;

        result.ShouldNotBeNull();
        result.Count.ShouldBe(expectedResult);
    }

    //TODO: Test for get learners endpoint

    private static GroupMonitoringController CreateController(IServiceScope scope, string id)
    {
        return new GroupMonitoringController(scope.ServiceProvider.GetRequiredService<IGroupMonitoringService>())
        {
            ControllerContext = BuildContext(id, "instructor")
        };
    }
}