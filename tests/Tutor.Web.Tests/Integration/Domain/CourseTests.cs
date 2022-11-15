using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.Core.Domain.Knowledge.KnowledgeComponents;
using Tutor.Web.Controllers.Instructors;
using Tutor.Web.Mappings.Domain.DTOs;
using Xunit;

namespace Tutor.Web.Tests.Integration.Domain;

[Collection("Sequential")]
public class CourseTests : BaseWebIntegrationTest
{
    public CourseTests(TutorApplicationTestFactory<Startup> factory) : base(factory) {}
    
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

    private CourseController SetupCourseController(IServiceScope scope, string id)
    {
        return new CourseController(scope.ServiceProvider.GetRequiredService<ICourseRepository>(),
            Factory.Services.GetRequiredService<IMapper>())
        {
            ControllerContext = BuildContext(id, "instructor")
        };
    }
}