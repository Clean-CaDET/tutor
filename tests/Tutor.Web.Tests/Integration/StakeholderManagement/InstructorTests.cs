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
    public void Retrieves_owned_courses(string instructorId, int expectedResult)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupInstructorController(scope, instructorId);
        var result = ((OkObjectResult)controller.GetOwnedCourses().Result)?.Value as List<CourseDto>;

        result.Count.ShouldBe(expectedResult);
    }
    
    private InstructorController SetupInstructorController(IServiceScope scope, string id)
    {
        return new InstructorController(Factory.Services.GetRequiredService<IMapper>(),
            scope.ServiceProvider.GetRequiredService<IAvailableCourseService>())
        {
            ControllerContext = BuildContext(id, "instructor")
        };
    }
}