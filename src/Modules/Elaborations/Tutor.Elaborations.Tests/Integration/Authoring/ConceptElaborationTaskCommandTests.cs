using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Instructor.Authoring.Elaboration;
using Tutor.Elaborations.API.Dtos.ConceptElaborationTasks;
using Tutor.Elaborations.API.Public.Authoring;
using Tutor.Elaborations.Infrastructure.Database;

namespace Tutor.Elaborations.Tests.Integration.Authoring;

[Collection("Sequential")]
public class ConceptElaborationTaskCommandTests : BaseElaborationsIntegrationTest
{
    public ConceptElaborationTaskCommandTests(ElaborationsTestFactory factory) : base(factory) { }

    [Fact]
    public void Creates()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<ElaborationsContext>();
        var newEntity = new ConceptElaborationTaskDto
        {
            UnitId = -1,
            Order = 10,
            Title = "New Concept",
            ConceptRecord = new ConceptRecordDto
            {
                CanonicalDefinition = "A new concept definition.",
                KeyPropositions = new List<KeyPropositionDto>
                {
                    new() { Key = "P1", Statement = "First proposition" },
                    new() { Key = "P2", Statement = "Second proposition" }
                },
                CommonMisconceptions = new List<CommonMisconceptionDto>
                {
                    new() { Key = "M1", Description = "A misconception", Correction = "The correction" }
                },
                KeyRelations = new List<KeyRelationDto>()
            }
        };
        dbContext.Database.BeginTransaction();

        var actionResult = controller.Create(-1, newEntity).Result;
        var result = (actionResult as OkObjectResult)?.Value as ConceptElaborationTaskDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Title.ShouldBe(newEntity.Title);
        result.UnitId.ShouldBe(-1);
        result.Order.ShouldBe(10);
        result.ConceptRecord.KeyPropositions.Count.ShouldBe(2);
        result.ConceptRecord.CommonMisconceptions.Count.ShouldBe(1);
        result.ConceptRecord.KeyRelations.Count.ShouldBe(0);
    }

    [Fact]
    public void Creates_with_relations()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<ElaborationsContext>();
        var newEntity = new ConceptElaborationTaskDto
        {
            UnitId = -1,
            Order = 11,
            Title = "Concept With Relations",
            ConceptRecord = new ConceptRecordDto
            {
                CanonicalDefinition = "A concept created with KPs and KRs in one request.",
                KeyPropositions = new List<KeyPropositionDto>
                {
                    new() { Key = "P1", Statement = "First proposition" },
                    new() { Key = "P2", Statement = "Second proposition" }
                },

                CommonMisconceptions = new List<CommonMisconceptionDto>(),
                KeyRelations = new List<KeyRelationDto>
                {
                    new()
                    {
                        Key = "R1", SourceKey = "P1", TargetKey = "P2",
                        Mechanism = "First enables second"
                    }
                }
            }
        };
        dbContext.Database.BeginTransaction();

        var actionResult = controller.Create(-1, newEntity).Result;
        var result = (actionResult as OkObjectResult)?.Value as ConceptElaborationTaskDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.ConceptRecord.KeyPropositions.Count.ShouldBe(2);
        result.ConceptRecord.KeyRelations.Count.ShouldBe(1);
        result.ConceptRecord.KeyRelations[0].Mechanism.ShouldBe("First enables second");
        result.ConceptRecord.KeyRelations[0].SourceKey.ShouldBe("P1");
        result.ConceptRecord.KeyRelations[0].TargetKey.ShouldBe("P2");
    }

    [Fact]
    public void Updates()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<ElaborationsContext>();
        var updatedEntity = new ConceptElaborationTaskDto
        {
            Id = -1,
            UnitId = -1,
            Order = 1,
            Title = "Updated Encapsulation",
            ConceptRecord = new ConceptRecordDto
            {
                CanonicalDefinition = "Updated definition.",
                KeyPropositions = new List<KeyPropositionDto>
                {
                    new() { Key = "P1", Statement = "Updated proposition" }
                },

                CommonMisconceptions = new List<CommonMisconceptionDto>(),
                KeyRelations = new List<KeyRelationDto>()
            }
        };
        dbContext.Database.BeginTransaction();

        var actionResult = controller.Update(-1, -1, updatedEntity).Result;
        var result = (actionResult as OkObjectResult)?.Value as ConceptElaborationTaskDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Id.ShouldBe(-1);
        result.Title.ShouldBe("Updated Encapsulation");
        result.ConceptRecord.KeyPropositions.Count.ShouldBe(1);
        result.ConceptRecord.KeyPropositions[0].Statement.ShouldBe("Updated proposition");
    }

    [Fact]
    public void Updates_relations_with_natural_keys()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<ElaborationsContext>();
        // CET -7 has KPs P1, P2 and KR R1 (source=P1, target=P2).
        var updatedEntity = new ConceptElaborationTaskDto
        {
            Id = -7,
            UnitId = -2,
            Order = 4,
            Title = "Polymorphism Mechanics",
            ConceptRecord = new ConceptRecordDto
            {
                CanonicalDefinition = "Polymorphism resolves method calls at runtime via dynamic dispatch.",
                KeyPropositions = new List<KeyPropositionDto>
                {
                    new() { Key = "P1", Statement = "A subclass can override a parent method" },
                    new() { Key = "P2", Statement = "The runtime selects the implementation by the actual type" },
                    new() { Key = "P3", Statement = "Dispatch table resolves virtual calls" }
                },

                CommonMisconceptions = new List<CommonMisconceptionDto>(),
                KeyRelations = new List<KeyRelationDto>
                {
                    new()
                    {
                        Key = "R1", SourceKey = "P1", TargetKey = "P2",
                        Mechanism = "Override matters because dispatch happens at runtime"
                    },
                    new()
                    {
                        Key = "R2", SourceKey = "P2", TargetKey = "P3",
                        Mechanism = "Runtime dispatch uses vtable lookup"
                    }
                }
            }
        };
        dbContext.Database.BeginTransaction();

        var actionResult = controller.Update(-2, -7, updatedEntity).Result;
        var result = (actionResult as OkObjectResult)?.Value as ConceptElaborationTaskDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.ConceptRecord.KeyPropositions.Count.ShouldBe(3);
        result.ConceptRecord.KeyRelations.Count.ShouldBe(2);
        result.ConceptRecord.KeyRelations.ShouldContain(kr => kr.Mechanism.Contains("dispatch happens at runtime"));
        result.ConceptRecord.KeyRelations.ShouldContain(kr => kr.Mechanism.Contains("vtable lookup"));
    }

    [Fact]
    public void Removes_relation_and_referenced_kp()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<ElaborationsContext>();
        // CET -7 has KPs P1, P2 and KR R1. Remove KR and KP P2, keeping only P1.
        var updatedEntity = new ConceptElaborationTaskDto
        {
            Id = -7,
            UnitId = -2,
            Order = 4,
            Title = "Polymorphism Mechanics",
            ConceptRecord = new ConceptRecordDto
            {
                CanonicalDefinition = "Polymorphism resolves method calls at runtime via dynamic dispatch.",
                KeyPropositions = new List<KeyPropositionDto>
                {
                    new() { Key = "P1", Statement = "A subclass can override a parent method" }
                },

                CommonMisconceptions = new List<CommonMisconceptionDto>(),
                KeyRelations = new List<KeyRelationDto>()
            }
        };
        dbContext.Database.BeginTransaction();

        var actionResult = controller.Update(-2, -7, updatedEntity).Result;
        var result = (actionResult as OkObjectResult)?.Value as ConceptElaborationTaskDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.ConceptRecord.KeyPropositions.Count.ShouldBe(1);
        result.ConceptRecord.KeyRelations.Count.ShouldBe(0);
    }

    [Fact]
    public void Deletes()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<ElaborationsContext>();
        dbContext.Database.BeginTransaction();

        var result = (OkResult)controller.Delete(-2, -7);

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(200);
        var stored = dbContext.ConceptElaborationTasks.FirstOrDefault(cet => cet.Id == -7);
        stored.ShouldBeNull();
        var storedRecord = dbContext.ConceptRecords.FirstOrDefault(r => r.ConceptElaborationTaskId == -7);
        storedRecord.ShouldBeNull();
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
        var newEntity = new ConceptElaborationTaskDto
        {
            UnitId = -3,
            Order = 99,
            Title = "Should Fail",
            ConceptRecord = new ConceptRecordDto
            {
                CanonicalDefinition = "Fail",
                KeyPropositions = new List<KeyPropositionDto>(),

                CommonMisconceptions = new List<CommonMisconceptionDto>(),
                KeyRelations = new List<KeyRelationDto>()
            }
        };

        var actionResult = controller.Create(-3, newEntity).Result;
        var objectResult = actionResult as ObjectResult;

        objectResult.ShouldNotBeNull();
        objectResult.StatusCode.ShouldBe(403);
    }

    [Fact]
    public void Non_owner_fails_to_update()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var updatedEntity = new ConceptElaborationTaskDto
        {
            Id = -4,
            UnitId = -3,
            Order = 1,
            Title = "Should Fail",
            ConceptRecord = new ConceptRecordDto
            {
                CanonicalDefinition = "Fail",
                KeyPropositions = new List<KeyPropositionDto>(),

                CommonMisconceptions = new List<CommonMisconceptionDto>(),
                KeyRelations = new List<KeyRelationDto>()
            }
        };

        var actionResult = controller.Update(-3, -4, updatedEntity).Result;
        var objectResult = actionResult as ObjectResult;

        objectResult.ShouldNotBeNull();
        objectResult.StatusCode.ShouldBe(403);
    }

    [Fact]
    public void Non_owner_fails_to_delete()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);

        var actionResult = controller.Delete(-3, -4);
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
