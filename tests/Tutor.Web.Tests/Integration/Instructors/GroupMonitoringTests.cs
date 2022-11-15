using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Collections.Generic;
using Tutor.Core.UseCases.ProgressMonitoring;
using Tutor.Web.Controllers.Instructors;
using Tutor.Web.Mappings.Enrollments;
using Xunit;

namespace Tutor.Web.Tests.Integration.Instructors;

[Collection("Sequential")]
public class GroupMonitoringTests : BaseWebIntegrationTest
{
    public GroupMonitoringTests(TutorApplicationTestFactory<Startup> factory) : base(factory) {}
    
    [Theory]
    [InlineData("-51", -1, 1)]
    [InlineData("-52", -2, 2)]
    public void Retrieves_owned_groups(string instructorId, int courseId, int expectedResult)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupGroupMonitoringController(scope, instructorId);
        var result = ((OkObjectResult)controller.GetAssignedGroups(courseId).Result)?.Value as List<GroupDto>;

        result.Count.ShouldBe(expectedResult);
    }

    private GroupMonitoringController SetupGroupMonitoringController(IServiceScope scope, string id)
    {
        return new GroupMonitoringController(Factory.Services.GetRequiredService<IMapper>(),
            scope.ServiceProvider.GetRequiredService<IGroupMonitoringService>())
        {
            ControllerContext = BuildContext(id, "instructor")
        };
    }
}