using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Instructor.Authoring.Elaboration;
using Tutor.Elaborations.API.Dtos.ConceptElaborationTasks;
using Tutor.Elaborations.API.Public.Authoring;

namespace Tutor.Elaborations.Tests.Integration.Authoring;

[Collection("Sequential")]
public class ConceptElaborationTaskQueryTests : BaseElaborationsIntegrationTest
{
    public ConceptElaborationTaskQueryTests(ElaborationsTestFactory factory) : base(factory) { }

    [Fact]
    public void Gets_by_unit()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);

        var actionResult = controller.GetByUnit(-1).Result;
        var result = (actionResult as OkObjectResult)?.Value as List<ConceptElaborationTaskDto>;

        result.ShouldNotBeNull();
        result.Count.ShouldBe(2);
        result[0].Order.ShouldBeLessThanOrEqualTo(result[1].Order);
        result.ShouldContain(s => s.Id == -1 && s.Title == "Encapsulation (Basics)");
        result.ShouldContain(s => s.Id == -2 && s.Title == "Encapsulation (Members)");
    }

    [Fact]
    public void Non_owner_fails_to_get_by_unit()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);

        var actionResult = controller.GetByUnit(-3).Result;
        var objectResult = actionResult as ObjectResult;

        objectResult.ShouldNotBeNull();
        objectResult.StatusCode.ShouldBe(403);
    }

    private static ConceptElaborationTaskController CreateController(IServiceScope scope)
    {
        return new ConceptElaborationTaskController(
            scope.ServiceProvider.GetRequiredService<IConceptElaborationTaskService>())
        {
            ControllerContext = BuildContext("-51", "instructor")
        };
    }
}
