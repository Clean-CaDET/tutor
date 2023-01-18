using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.UseCases.Management.Stakeholders;
using Tutor.Web.Controllers.Administrators.Courses;
using Tutor.Web.Mappings.Knowledge.DTOs;
using Xunit;

namespace Tutor.Web.Tests.Integration.Management.Courses;

[Collection("Sequential")]
public class CourseQueryTests : BaseWebIntegrationTest
{
    public CourseQueryTests(TutorApplicationTestFactory<Startup> factory) : base(factory) { }

    [Fact]
    public void Retrieves_courses()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupController(scope);

        var result = ((OkObjectResult)controller.GetAll(0, 0).Result)?.Value as PagedResult<CourseDto>;

        result.ShouldNotBeNull();
        result.Results.Count.ShouldBe(3);
        result.TotalCount.ShouldBe(3);
    }

    private CourseController SetupController(IServiceScope scope)
    {
        return new CourseController(Factory.Services.GetRequiredService<IMapper>(),
            scope.ServiceProvider.GetRequiredService<ICourseService>())
        {
            ControllerContext = BuildContext("0", "administrator")
        };
    }
}