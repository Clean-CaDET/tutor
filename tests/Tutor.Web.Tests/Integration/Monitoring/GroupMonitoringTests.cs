using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Collections.Generic;
using Tutor.Core.BuildingBlocks;
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
    public void Retrieves_group_progress(string userId, int courseId, int groupId, PagedResult<LearnerProgressDto> expectedProgress)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupController(scope, userId);

        var result = ((OkObjectResult)controller.GetProgressForGroup(courseId, groupId, 1, 10).Result)?.Value as PagedResult<LearnerProgressDto>;

        result.ShouldNotBeNull();
        result.TotalCount.ShouldBe(expectedProgress.TotalCount);
    }
    
    public static IEnumerable<object[]> TestData()
    {
        return new List<object[]>
        {
            new object[]
            {
                "-51", -1, -1,
                new PagedResult<LearnerProgressDto>(new List<LearnerProgressDto>(), 4)
            }
        };
    }

    [Fact]
    public void Retrieves_progress_of_all_learners()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupController(scope, "-51");

        var result = ((OkObjectResult)controller.GetProgressForAll(-1, 1, 10).Result)?.Value as PagedResult<LearnerProgressDto>;

        result.ShouldNotBeNull();
        result.TotalCount.ShouldBe(5);
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