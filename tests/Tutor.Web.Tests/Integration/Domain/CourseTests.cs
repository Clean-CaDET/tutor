using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.Web.Controllers.Domain.DTOs;
using Xunit;

namespace Tutor.Web.Tests.Integration.Domain;

[Collection("Sequential")]
public class CourseTests : BaseWebIntegrationTest
{
    public CourseTests(TutorApplicationTestFactory<Startup> factory) : base(factory)
    {
    }
    
    [Theory]
    [InlineData(-1, -1)]
    [InlineData(-2, -2)]
    public void Get_course(int courseId, int expectedResult)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupCourseController(scope, "-51");
        var result = ((OkObjectResult)controller.GetCourse(courseId).Result)?.Value as CourseDto;

        result.Id.ShouldBe(expectedResult);
    }
}