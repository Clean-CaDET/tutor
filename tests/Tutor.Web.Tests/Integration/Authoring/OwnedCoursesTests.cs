using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.UseCases.Management.Stakeholders;
using Tutor.Infrastructure.Database;
using Tutor.Web.Controllers.Instructors;
using Tutor.Web.Mappings.Knowledge.DTOs;
using Xunit;

namespace Tutor.Web.Tests.Integration.Authoring;

[Collection("Sequential")]
public class OwnedCoursesTests : BaseWebIntegrationTest
{
    public OwnedCoursesTests(TutorApplicationTestFactory<Startup> factory) : base(factory) { }

    [Theory]
    [InlineData("-51", 1)]
    [InlineData("-52", 2)]
    public void Retrieves_owned_courses(string instructorId, int expectedCourseCount)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupOwnedCoursesController(scope, instructorId);
        var result = ((OkObjectResult)controller.GetOwnedCourses().Result)?.Value as List<CourseDto>;

        result.ShouldNotBeNull();
        result.Count.ShouldBe(expectedCourseCount);
    }

    [Fact]
    public void Retrieves_owned_course_with_units()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupOwnedCoursesController(scope, "-51");

        var result = ((OkObjectResult)controller.GetCourseWithUnitsAndKcs(-1).Result)?.Value as CourseDto;

        result.ShouldNotBeNull();
        result.Id.ShouldBe(-1);
        result.KnowledgeUnits.Count.ShouldBe(3);
        result.KnowledgeUnits.First(u => u.Id == -1).KnowledgeComponents.Count.ShouldBe(6);
    }

    [Fact]
    public void Updates_course_description()
    {
        using var scope = Factory.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();
        var controller = SetupOwnedCoursesController(scope, "-51");
        var updateCourse = new CourseDto
        {
            Id = -1,
            Description = "Test"
        };

        var result = ((OkObjectResult)controller.Update(updateCourse).Result)?.Value as CourseDto;

        result.ShouldNotBeNull();
        result.Id.ShouldBe(-1);
        result.Description.ShouldBe("Test");

        // DEMO - context caching
        // (with and without change tracker clearing)
        dbContext.ChangeTracker.Clear();
        var storedCourse = dbContext.Courses.FirstOrDefault(c => c.Id == -1);
        storedCourse.ShouldNotBeNull();
        storedCourse.Description.ShouldBe(updateCourse.Description);
    }

    private OwnedCoursesController SetupOwnedCoursesController(IServiceScope scope, string id)
    {
        return new OwnedCoursesController(Factory.Services.GetRequiredService<IMapper>(),
            scope.ServiceProvider.GetRequiredService<ICourseOwnershipService>())
        {
            ControllerContext = BuildContext(id, "instructor")
        };
    }
}