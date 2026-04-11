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
    public void Gets_by_id()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);

        var actionResult = controller.Get(-1, -1).Result;
        var result = (actionResult as OkObjectResult)?.Value as ConceptElaborationTaskDto;

        result.ShouldNotBeNull();
        result.Id.ShouldBe(-1);
        result.UnitId.ShouldBe(-1);
        result.Title.ShouldBe("Encapsulation (Basics)");
        result.KeyPropositions.Count.ShouldBe(1);
        result.KeyPropositions.ShouldContain(kp => kp.Statement == "Data and methods are bundled in a class");
        result.BoundaryConditions.Count.ShouldBe(1);
        result.CommonMisconceptions.Count.ShouldBe(1);
    }

    [Fact]
    public void Gets_by_unit()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);

        var actionResult = controller.GetByUnit(-1).Result;
        var result = (actionResult as OkObjectResult)?.Value as List<ConceptElaborationTaskSummaryDto>;

        result.ShouldNotBeNull();
        result.Count.ShouldBe(2);
        result[0].Order.ShouldBeLessThanOrEqualTo(result[1].Order);
        result.ShouldContain(s => s.Id == -1 && s.Title == "Encapsulation (Basics)");
        result.ShouldContain(s => s.Id == -2 && s.Title == "Encapsulation (Members)");
    }

    [Fact]
    public void Gets_task_with_relations()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);

        var actionResult = controller.Get(-2, -7).Result;
        var result = (actionResult as OkObjectResult)?.Value as ConceptElaborationTaskDto;

        result.ShouldNotBeNull();
        result.KeyPropositions.Count.ShouldBe(2);
        result.BoundaryConditions.Count.ShouldBe(0);
        result.CommonMisconceptions.Count.ShouldBe(0);
        result.KeyRelations.Count.ShouldBe(1);
        result.KeyRelations[0].SourceKeyPropositionId.ShouldBe(-70);
        result.KeyRelations[0].TargetKeyPropositionId.ShouldBe(-71);
        result.KeyRelations[0].Mechanism.ShouldContain("dispatch happens at runtime");
    }

    [Fact]
    public void Non_owner_fails_to_get()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);

        var actionResult = controller.Get(-3, -4).Result;
        var objectResult = actionResult as ObjectResult;

        objectResult.ShouldNotBeNull();
        objectResult.StatusCode.ShouldBe(403);
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

    [Fact]
    public void Fails_to_get_nonexistent()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);

        var actionResult = controller.Get(-1, -999).Result;
        var objectResult = actionResult as ObjectResult;

        objectResult.ShouldNotBeNull();
        objectResult.StatusCode.ShouldBe(404);
    }

    [Fact]
    public void Fails_to_get_task_from_wrong_unit()
    {
        using var scope = Factory.Services.CreateScope();
        // Instructor -51 owns Unit -2, but CET -1 belongs to Unit -1
        var controller = CreateController(scope);

        var actionResult = controller.Get(-2, -1).Result;
        var objectResult = actionResult as ObjectResult;

        objectResult.ShouldNotBeNull();
        objectResult.StatusCode.ShouldBe(404);
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
