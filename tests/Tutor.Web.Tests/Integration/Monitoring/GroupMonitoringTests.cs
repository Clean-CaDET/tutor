using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Collections.Generic;
using Tutor.Core.UseCases.Monitoring;
using Tutor.Web.Controllers.Instructors;
using Tutor.Web.Mappings.Enrollments;
using Xunit;

namespace Tutor.Web.Tests.Integration.Monitoring;

[Collection("Sequential")]
public class GroupMonitoringTests : BaseWebIntegrationTest
{
    public GroupMonitoringTests(TutorApplicationTestFactory<Startup> factory) : base(factory) {}
    
    [Theory]
    [InlineData("-51", -1, 3)]
    [InlineData("-52", -2, 2)]
    public void Retrieves_owned_course_groups(string instructorId, int courseId, int expectedResult)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupController(scope, instructorId);
        var result = ((OkObjectResult)controller.GetCourseGroups(courseId).Result)?.Value as List<GroupDto>;

        result.ShouldNotBeNull();
        result.Count.ShouldBe(expectedResult);
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void Retrieves_learner_progress(string userId, int[] learnerIds, int expectedProgressCount)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupController(scope, userId);

        var result = ((OkObjectResult)controller.GetLearnerProgress(-1, -1, learnerIds).Result)?.Value as List<KcmProgressDto>;

        result.ShouldNotBeNull();
        result.Count.ShouldBe(expectedProgressCount);
    }
    
    public static IEnumerable<object[]> TestData()
    {
        return new List<object[]>
        {
            new object[]
            {
                "-51", new []{-2, -3}, 12
            },
            new object[]
            {
                "-51", new []{-2}, 6
            },
            new object[]
            {
                "-51", new []{-3}, 6
            },
            new object[]
            {
                "-51", new []{-1}, 0
            }
        };
    }

    private GroupMonitoringController SetupController(IServiceScope scope, string id)
    {
        return new GroupMonitoringController(Factory.Services.GetRequiredService<IMapper>(),
            scope.ServiceProvider.GetRequiredService<IGroupMonitoringService>())
        {
            ControllerContext = BuildContext(id, "instructor")
        };
    }
}