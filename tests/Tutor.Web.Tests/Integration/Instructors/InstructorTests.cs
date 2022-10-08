using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Collections.Generic;
using Tutor.Web.Mappings.Domain.DTOs;
using Tutor.Web.Mappings.Enrollments;
using Xunit;

namespace Tutor.Web.Tests.Integration.Instructors;

[Collection("Sequential")]
public class InstructorTests : BaseWebIntegrationTest
{
    public InstructorTests(TutorApplicationTestFactory<Startup> factory) : base(factory)
    {
    }

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
}