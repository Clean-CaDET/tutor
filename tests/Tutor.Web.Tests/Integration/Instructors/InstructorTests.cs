using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Collections.Generic;
using AutoMapper;
using Tutor.Core.UseCases.ProgressMonitoring;
using Tutor.Core.UseCases.StakeholderManagement;
using Tutor.Web.Controllers.Instructors;
using Tutor.Web.Mappings.Enrollments;
using Tutor.Web.Mappings.Knowledge.DTOs;
using Xunit;

namespace Tutor.Web.Tests.Integration.Instructors;

[Collection("Sequential")]
public class InstructorTests : BaseWebIntegrationTest
{
    public InstructorTests(TutorApplicationTestFactory<Startup> factory) : base(factory) {}

    [Theory]
    [InlineData("-51", 1)]
    [InlineData("-52", 2)]
    public void Retrieves_owned_courses(string instructorId, int expectedResult)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupInstructorController(scope, instructorId);
        var result = ((OkObjectResult)controller.GetOwnedCourses().Result)?.Value as List<CourseDto>;

        result.Count.ShouldBe(expectedResult);
    }

    [Theory]
    [InlineData("-51", -1, 1)]
    [InlineData("-52", -2, 2)]
    public void Retrieves_owned_groups(string instructorId, int courseId, int expectedResult)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupInstructorController(scope, instructorId);
        var result = ((OkObjectResult)controller.GetAssignedGroups(courseId).Result)?.Value as List<GroupDto>;

        result.Count.ShouldBe(expectedResult);
    }

    private InstructorController SetupInstructorController(IServiceScope scope, string id)
    {
        return new InstructorController(Factory.Services.GetRequiredService<IMapper>(),
            scope.ServiceProvider.GetRequiredService<IAvailableCourseService>(),
            scope.ServiceProvider.GetRequiredService<IGroupMonitoringService>())
        {
            ControllerContext = BuildContext(id, "instructor")
        };
    }
}