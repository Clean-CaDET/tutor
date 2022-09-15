using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.Web.Controllers.Domain.DTOs.Enrollment;
using Xunit;

namespace Tutor.Web.Tests.Integration.Instructors;

[Collection("Sequential")]
public class InstructorTests : BaseWebIntegrationTest
{
    public InstructorTests(TutorApplicationTestFactory<Startup> factory) : base(factory)
    {
    }
    
    [Fact]
    public void Retrieves_courses()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupInstructorController(scope, "-51");
        var result = ((OkObjectResult)controller.GetCourses().Result)?.Value as List<CourseDto>;
            
        result.Count.ShouldBe(1);
    }

    [Fact]
    public void Retrieves_groups()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupInstructorController(scope, "-51");
        var result = ((OkObjectResult)controller.GetGroups(-1000).Result)?.Value as List<GroupDto>;
        
        result.Count.ShouldBe(1);
    }
}