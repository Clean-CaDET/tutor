using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Instructor.Authoring.Elaboration;
using Tutor.Elaborations.API.Dtos.ConceptRecords;
using Tutor.Elaborations.API.Public.Authoring;
using Tutor.Elaborations.Infrastructure.Database;

namespace Tutor.Elaborations.Tests.Integration.Authoring;

[Collection("Sequential")]
public class ConceptRecordCommandTests : BaseElaborationsIntegrationTest
{
    public ConceptRecordCommandTests(ElaborationsTestFactory factory) : base(factory) { }

    [Fact]
    public void Creates()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<ElaborationsContext>();
        var newEntity = new ConceptRecordDto
        {
            CourseId = -1,
            Title = "New Concept",
            CanonicalDefinition = "A new concept definition.",
            KeyPropositions = new List<KeyPropositionDto>
            {
                new() { Statement = "First proposition", Level = "Beginner", Order = 1 },
                new() { Statement = "Second proposition", Level = "Intermediate", Order = 2 }
            },
            BoundaryConditions = new List<BoundaryConditionDto>
            {
                new() { Statement = "A boundary condition", Level = "Beginner", Order = 1 }
            },
            CommonMisconceptions = new List<CommonMisconceptionDto>
            {
                new() { Description = "A misconception", Correction = "The correction", Order = 1 }
            },
            KeyRelations = new List<KeyRelationDto>()
        };
        dbContext.Database.BeginTransaction();

        var actionResult = controller.Create(-1, newEntity).Result;
        var result = (actionResult as OkObjectResult)?.Value as ConceptRecordDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Title.ShouldBe(newEntity.Title);
        result.CourseId.ShouldBe(-1);
        result.KeyPropositions.Count.ShouldBe(2);
        result.KeyPropositions[0].Level.ShouldBe("Beginner");
        result.BoundaryConditions.Count.ShouldBe(1);
        result.CommonMisconceptions.Count.ShouldBe(1);
        result.KeyRelations.Count.ShouldBe(0);
    }

    [Fact]
    public void Updates()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<ElaborationsContext>();
        var updatedEntity = new ConceptRecordDto
        {
            Id = -1,
            CourseId = -1,
            Title = "Updated Encapsulation",
            CanonicalDefinition = "Updated definition.",
            KeyPropositions = new List<KeyPropositionDto>
            {
                new() { Statement = "Updated proposition", Level = "Beginner", Order = 1 }
            },
            BoundaryConditions = new List<BoundaryConditionDto>(),
            CommonMisconceptions = new List<CommonMisconceptionDto>(),
            KeyRelations = new List<KeyRelationDto>()
        };
        dbContext.Database.BeginTransaction();

        var actionResult = controller.Update(-1, -1, updatedEntity).Result;
        var result = (actionResult as OkObjectResult)?.Value as ConceptRecordDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Id.ShouldBe(-1);
        result.Title.ShouldBe("Updated Encapsulation");
        result.KeyPropositions.Count.ShouldBe(1);
        result.KeyPropositions[0].Statement.ShouldBe("Updated proposition");
    }

    [Fact]
    public void Updates_relations_round_trip()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<ElaborationsContext>();
        // CR -5 has KPs -50 and -51 already; add a second relation alongside the seeded -100.
        var updatedEntity = new ConceptRecordDto
        {
            Id = -5,
            CourseId = -1,
            Title = "Polymorphism Mechanics",
            CanonicalDefinition = "Polymorphism resolves method calls at runtime via dynamic dispatch.",
            KeyPropositions = new List<KeyPropositionDto>
            {
                new() { Id = -50, Statement = "A subclass can override a parent method", Level = "Beginner", Order = 1 },
                new() { Id = -51, Statement = "The runtime selects the implementation by the actual type", Level = "Beginner", Order = 2 }
            },
            BoundaryConditions = new List<BoundaryConditionDto>(),
            CommonMisconceptions = new List<CommonMisconceptionDto>(),
            KeyRelations = new List<KeyRelationDto>
            {
                new()
                {
                    SourceKeyPropositionId = -50, TargetKeyPropositionId = -51,
                    Mechanism = "Override matters because dispatch happens at runtime",
                    Level = "Beginner", Order = 1
                },
                new()
                {
                    SourceKeyPropositionId = -51, TargetKeyPropositionId = -50,
                    Mechanism = "Runtime type lookup is what makes the override observable",
                    Level = "Beginner", Order = 2
                }
            }
        };
        dbContext.Database.BeginTransaction();

        var actionResult = controller.Update(-1, -5, updatedEntity).Result;
        var result = (actionResult as OkObjectResult)?.Value as ConceptRecordDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.KeyRelations.Count.ShouldBe(2);
        result.KeyRelations[0].Mechanism.ShouldContain("dispatch happens at runtime");
        result.KeyRelations[0].Level.ShouldBe("Beginner");
    }

    [Fact]
    public void Deletes()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<ElaborationsContext>();
        dbContext.Database.BeginTransaction();

        var result = (OkResult)controller.Delete(-1, -4);

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(200);
        var stored = dbContext.ConceptRecords.FirstOrDefault(cr => cr.Id == -4);
        stored.ShouldBeNull();
    }

    [Fact]
    public void Fails_to_delete_nonexistent()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);

        var actionResult = controller.Delete(-1, -999);
        var objectResult = actionResult as ObjectResult;

        objectResult.ShouldNotBeNull();
        objectResult.StatusCode.ShouldBe(404);
    }

    [Fact]
    public void Non_owner_fails_to_create()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var newEntity = new ConceptRecordDto
        {
            CourseId = -2,
            Title = "Should Fail",
            CanonicalDefinition = "Fail",
            KeyPropositions = new List<KeyPropositionDto>(),
            BoundaryConditions = new List<BoundaryConditionDto>(),
            CommonMisconceptions = new List<CommonMisconceptionDto>(),
            KeyRelations = new List<KeyRelationDto>()
        };

        var actionResult = controller.Create(-2, newEntity).Result;
        var objectResult = actionResult as ObjectResult;

        objectResult.ShouldNotBeNull();
        objectResult.StatusCode.ShouldBe(403);
    }

    [Fact]
    public void Non_owner_fails_to_update()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var updatedEntity = new ConceptRecordDto
        {
            Id = -3,
            CourseId = -2,
            Title = "Should Fail",
            CanonicalDefinition = "Fail",
            KeyPropositions = new List<KeyPropositionDto>(),
            BoundaryConditions = new List<BoundaryConditionDto>(),
            CommonMisconceptions = new List<CommonMisconceptionDto>(),
            KeyRelations = new List<KeyRelationDto>()
        };

        var actionResult = controller.Update(-2, -3, updatedEntity).Result;
        var objectResult = actionResult as ObjectResult;

        objectResult.ShouldNotBeNull();
        objectResult.StatusCode.ShouldBe(403);
    }

    [Fact]
    public void Non_owner_fails_to_delete()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);

        var actionResult = controller.Delete(-2, -3);
        var objectResult = actionResult as ObjectResult;

        objectResult.ShouldNotBeNull();
        objectResult.StatusCode.ShouldBe(403);
    }

    private static ConceptRecordController CreateController(IServiceScope scope)
    {
        return new ConceptRecordController(scope.ServiceProvider.GetRequiredService<IConceptRecordService>())
        {
            ControllerContext = BuildContext("-51", "instructor")
        };
    }
}
