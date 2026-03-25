using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Instructor.Authoring.Elaboration;
using Tutor.Elaborations.API.Dtos.Conversations;
using Tutor.Elaborations.API.Public.Authoring;

namespace Tutor.Elaborations.Tests.Integration.Authoring;

[Collection("Sequential")]
public class ElaborationTaskQueryTests : BaseElaborationsIntegrationTest
{
    public ElaborationTaskQueryTests(ElaborationsTestFactory factory) : base(factory) { }

    [Fact]
    public void Gets_by_unit()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);

        var actionResult = controller.GetByUnit(-1).Result;
        var result = (actionResult as OkObjectResult)?.Value as List<ElaborationTaskDto>;

        result.ShouldNotBeNull();
        result.Count.ShouldBe(2);
        result[0].UnitId.ShouldBe(-1);
        result[0].Order.ShouldBe(1);
        result[1].Order.ShouldBe(2);
    }

    [Fact]
    public void Non_owner_fails_to_get()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);

        var actionResult = controller.GetByUnit(-3).Result;
        var objectResult = actionResult as ObjectResult;

        objectResult.ShouldNotBeNull();
        objectResult.StatusCode.ShouldBe(403);
    }

    private static ElaborationTaskController CreateController(IServiceScope scope)
    {
        return new ElaborationTaskController(scope.ServiceProvider.GetRequiredService<IElaborationTaskService>())
        {
            ControllerContext = BuildContext("-51", "instructor")
        };
    }
}
