using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System;
using System.Linq;
using Tutor.Core.UseCases.Management.Stakeholders;
using Tutor.Infrastructure.Database;
using Tutor.Web.Controllers.Administrators.Courses;
using Tutor.Web.Mappings.Knowledge.DTOs;
using Xunit;

namespace Tutor.Web.Tests.Integration.Management.Courses;

[Collection("Sequential")]
public class CoursesTests : BaseWebIntegrationTest
{
    public CoursesTests(TutorApplicationTestFactory<Startup> factory) : base(factory) { }

    [Fact]
    public void Saves_course()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupCoursesController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();
        var newCourse = new CourseDto
        {
            Code = "NC-1",
            Name = "New course",
            Description = "New course description",
            StartDate = DateTime.UtcNow
        };

        var result = ((OkObjectResult)controller.Create(newCourse).Result)?.Value as CourseDto;

        result.ShouldNotBeNull();
        result.Id.ShouldNotBe(0);
        result.Code.ShouldBe(newCourse.Code);
        result.Name.ShouldBe(newCourse.Name);
        result.Description.ShouldBe(newCourse.Description);
        var storedCourse = dbContext.Courses.FirstOrDefault(c => c.Id == result.Id);
        storedCourse.ShouldNotBeNull();
        var storedLearnerGroup = dbContext.LearnerGroups.FirstOrDefault(g => g.Name == "Group 1");
        storedLearnerGroup.ShouldNotBeNull();
        storedLearnerGroup.CourseId.ShouldBe(result.Id);
    }

    private CourseController SetupCoursesController(IServiceScope scope)
    {
        return new CourseController(Factory.Services.GetRequiredService<IMapper>(),
            scope.ServiceProvider.GetRequiredService<ICourseService>())
        {
            ControllerContext = BuildContext("0", "administrator")
        };
    }
}