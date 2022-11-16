using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Collections.Generic;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.UseCases.ProgressMonitoring;
using Tutor.Web.Controllers.Instructors;
using Tutor.Web.Mappings.CourseIteration;
using Xunit;

namespace Tutor.Web.Tests.Integration.ProgressMonitoring;

[Collection("Sequential")]
public class CourseIterationMonitoringTests : BaseWebIntegrationTest
{
    public CourseIterationMonitoringTests(TutorApplicationTestFactory<Startup> factory) : base(factory) {}
    
    [Theory]
    [InlineData("-51", -1, 1)]
    [InlineData("-52", -2, 2)]
    public void Retrieves_owned_groups(string instructorId, int courseId, int expectedResult)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupCourseIterationMonitoringController(scope, instructorId);
        var result = ((OkObjectResult)controller.GetAssignedGroups(courseId).Result)?.Value as List<GroupDto>;

        result.Count.ShouldBe(expectedResult);
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void Retrieves_knowledge_component_statistics(string userId, int courseId, int groupId, PagedResult<LearnerProgressDto> expectedProgress)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupCourseIterationMonitoringController(scope, userId);

        var result = ((OkObjectResult)controller.GetProgressForGroup(courseId, groupId, 1, 10).Result).Value as PagedResult<LearnerProgressDto>;

        result.ShouldNotBeNull();
        result.TotalCount.ShouldBe(expectedProgress.TotalCount);
    }
    
    public static IEnumerable<object[]> TestData()
    {
        return new List<object[]>
        {
            new object[]
            {
                "-50", -1, -1,
                new PagedResult<LearnerProgressDto>(new List<LearnerProgressDto>(), 5)
            }
        };
    }

    private CourseIterationMonitoringController SetupCourseIterationMonitoringController(IServiceScope scope, string id)
    {
        return new CourseIterationMonitoringController(Factory.Services.GetRequiredService<IMapper>(),
            scope.ServiceProvider.GetRequiredService<ICourseIterationMonitoringService>())
        {
            ControllerContext = BuildContext(id, "instructor")
        };
    }
}