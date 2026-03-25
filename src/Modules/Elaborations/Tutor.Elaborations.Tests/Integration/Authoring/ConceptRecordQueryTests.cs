using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Instructor.Authoring.Elaboration;
using Tutor.Elaborations.API.Dtos.ConceptRecords;
using Tutor.Elaborations.API.Public.Authoring;

namespace Tutor.Elaborations.Tests.Integration.Authoring;

[Collection("Sequential")]
public class ConceptRecordQueryTests : BaseElaborationsIntegrationTest
{
    public ConceptRecordQueryTests(ElaborationsTestFactory factory) : base(factory) { }

    [Fact]
    public void Gets_by_id()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);

        var actionResult = controller.Get(-1, -1).Result;
        var result = (actionResult as OkObjectResult)?.Value as ConceptRecordDto;

        result.ShouldNotBeNull();
        result.Id.ShouldBe(-1);
        result.CourseId.ShouldBe(-1);
        result.Title.ShouldBe("Encapsulation");
        result.KeyPropositions.Count.ShouldBe(3);
        result.KeyPropositions[0].Statement.ShouldBe("Data and methods are bundled in a class");
        result.KeyPropositions[0].Level.ShouldBe("Beginner");
        result.BoundaryConditions.Count.ShouldBe(2);
        result.CommonMisconceptions.Count.ShouldBe(2);
    }

    [Fact]
    public void Gets_by_course()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);

        var actionResult = controller.GetByCourse(-1).Result;
        var result = (actionResult as OkObjectResult)?.Value as List<ConceptRecordDto>;

        result.ShouldNotBeNull();
        result.Count.ShouldBe(2);
    }

    [Fact]
    public void Non_owner_fails_to_get()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);

        var actionResult = controller.Get(-2, -3).Result;
        var objectResult = actionResult as ObjectResult;

        objectResult.ShouldNotBeNull();
        objectResult.StatusCode.ShouldBe(403);
    }

    [Fact]
    public void Non_owner_fails_to_get_by_course()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);

        var actionResult = controller.GetByCourse(-2).Result;
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
    public void Fails_to_get_record_from_wrong_course()
    {
        using var scope = Factory.Services.CreateScope();
        // Instructor -52 owns course -2, but CR -1 belongs to course -1
        var controller = new ConceptRecordController(
            scope.ServiceProvider.GetRequiredService<IConceptRecordService>())
        {
            ControllerContext = BuildContext("-52", "instructor")
        };

        var actionResult = controller.Get(-2, -1).Result;
        var objectResult = actionResult as ObjectResult;

        objectResult.ShouldNotBeNull();
        objectResult.StatusCode.ShouldBe(404);
    }

    private static ConceptRecordController CreateController(IServiceScope scope)
    {
        return new ConceptRecordController(scope.ServiceProvider.GetRequiredService<IConceptRecordService>())
        {
            ControllerContext = BuildContext("-51", "instructor")
        };
    }
}
