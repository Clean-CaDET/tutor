using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Administrator.Courses;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Courses.API.Dtos.Groups;
using Tutor.Courses.API.Public.Management;

namespace Tutor.Courses.Tests.Integration.Management;

[Collection("Sequential")]
public class GroupQueryTests : BaseCoursesIntegrationTest
{
    public GroupQueryTests(CoursesTestFactory factory) : base(factory) { }

    [Fact]
    public void Gets_all()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);

        var result = ((OkObjectResult)controller.GetAll(-1).Result)?.Value as PagedResult<GroupDto>;

        result.ShouldNotBeNull();
        result.Results.Count.ShouldBe(3);
    }

    private static GroupController CreateController(IServiceScope scope)
    {
        return new GroupController(scope.ServiceProvider.GetRequiredService<IGroupService>())
        {
            ControllerContext = BuildContext("0", "administrator")
        };
    }
}