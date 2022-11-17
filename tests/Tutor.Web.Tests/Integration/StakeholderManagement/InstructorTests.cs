using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Collections.Generic;
using Tutor.Core.UseCases.StakeholderManagement;
using Tutor.Web.Controllers.Instructors;
using Tutor.Web.Mappings.Knowledge.DTOs;
using Xunit;

namespace Tutor.Web.Tests.Integration.StakeholderManagement;

[Collection("Sequential")]
public class InstructorTests : BaseWebIntegrationTest
{
    public InstructorTests(TutorApplicationTestFactory<Startup> factory) : base(factory) {}

    [Theory]
    [InlineData("-51", 1)]
    [InlineData("-52", 2)]
    public void Retrieves_owned_courses(string instructorId, int expectedCourseCount)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupInstructorController(scope, instructorId);
        var result = ((OkObjectResult)controller.GetOwnedCourses().Result)?.Value as List<CourseDto>;

        result.ShouldNotBeNull();
        result.Count.ShouldBe(expectedCourseCount);
    }

    [Fact]
    public void Retrieves_owned_course_with_units()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupInstructorController(scope, "-51");
        var result = ((OkObjectResult)controller.GetCourseWithUnits(-1).Result)?.Value as CourseDto;

        result.ShouldNotBeNull();
        result.Id.ShouldBe(-1);
        result.KnowledgeUnits.Count.ShouldBe(2);
    }

    private InstructorController SetupInstructorController(IServiceScope scope, string id)
    {
        return new InstructorController(Factory.Services.GetRequiredService<IMapper>(),
            scope.ServiceProvider.GetRequiredService<ICourseOwnershipService>())
        {
            ControllerContext = BuildContext(id, "instructor")
        };
    }
}