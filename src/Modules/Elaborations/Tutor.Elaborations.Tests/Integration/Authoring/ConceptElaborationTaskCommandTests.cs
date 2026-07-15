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
            Description = "A new concept for testing.",
            ConceptRecord = new ConceptRecordDto
            {
                CanonicalDefinition = "A new concept definition.",
                KeyPropositions = new List<KeyPropositionDto>
                {
                    new()
                    {
                        Key = "P1", Statement = "First proposition",
                        Misconception = new MisconceptionDto
                        {
                            Description = "A misconception", Correction = "The correction"
                        }
                    },
                    new() { Key = "P2", Statement = "Second proposition" }
                }
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
        result.ConceptRecord.ShouldNotBeNull();
        result.ConceptRecord.KeyPropositions.Count.ShouldBe(2);
        var created = result.ConceptRecord.KeyPropositions.First(p => p.Key == "P1");
        created.Misconception.ShouldNotBeNull();
        created.Misconception.Description.ShouldBe("A misconception");
        created.Misconception.Correction.ShouldBe("The correction");
        result.ConceptRecord.KeyPropositions.First(p => p.Key == "P2").Misconception.ShouldBeNull();
    }

    [Fact]
    public void Creates_without_misconception_leaves_it_null()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<ElaborationsContext>();
        var newEntity = new ConceptElaborationTaskDto
        {
            UnitId = -1,
            Order = 11,
            Title = "Concept Without Misconceptions",
            Description = "A concept created with plain propositions.",
            ConceptRecord = new ConceptRecordDto
            {
                CanonicalDefinition = "A concept created with two plain propositions.",
                KeyPropositions = new List<KeyPropositionDto>
                {
                    new() { Key = "P1", Statement = "First proposition" },
                    new() { Key = "P2", Statement = "Second proposition" }
                }
            }
        };
        dbContext.Database.BeginTransaction();

        var actionResult = controller.Create(-1, newEntity).Result;
        var result = (actionResult as OkObjectResult)?.Value as ConceptElaborationTaskDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.ConceptRecord.ShouldNotBeNull();
        result.ConceptRecord.KeyPropositions.Count.ShouldBe(2);
        result.ConceptRecord.KeyPropositions.ShouldAllBe(p => p.Misconception == null);
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
            Description = "Updated description.",
            ConceptRecord = new ConceptRecordDto
            {
                CanonicalDefinition = "Updated definition.",
                KeyPropositions = new List<KeyPropositionDto>
                {
                    new() { Key = "P1", Statement = "Updated proposition" }
                }
            }
        };
        dbContext.Database.BeginTransaction();

        var actionResult = controller.Update(-1, -1, updatedEntity).Result;
        var result = (actionResult as OkObjectResult)?.Value as ConceptElaborationTaskDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Id.ShouldBe(-1);
        result.Title.ShouldBe("Updated Encapsulation");
        result.ConceptRecord.ShouldNotBeNull();
        result.ConceptRecord.KeyPropositions.Count.ShouldBe(1);
        result.ConceptRecord.KeyPropositions[0].Statement.ShouldBe("Updated proposition");
    }

    [Fact]
    public void Updates_changes_kp_misconception()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<ElaborationsContext>();
        // CET -7 has KPs P1, P2 with no misconceptions. Give P1 a scoped misconception.
        var updatedEntity = new ConceptElaborationTaskDto
        {
            Id = -7,
            UnitId = -2,
            Order = 4,
            Title = "Polymorphism Mechanics",
            Description = "Runtime method dispatch and virtual call mechanics.",
            ConceptRecord = new ConceptRecordDto
            {
                CanonicalDefinition = "Polymorphism resolves method calls at runtime via dynamic dispatch.",
                KeyPropositions = new List<KeyPropositionDto>
                {
                    new()
                    {
                        Key = "P1", Statement = "A subclass can override a parent method",
                        Misconception = new MisconceptionDto
                        {
                            Description = "Overriding and overloading are the same thing",
                            Correction = "Overriding replaces behavior at runtime; overloading is resolved at compile time"
                        }
                    },
                    new() { Key = "P2", Statement = "The runtime selects the implementation by the actual type" }
                }
            }
        };
        dbContext.Database.BeginTransaction();

        var actionResult = controller.Update(-2, -7, updatedEntity).Result;
        var result = (actionResult as OkObjectResult)?.Value as ConceptElaborationTaskDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.ConceptRecord.ShouldNotBeNull();
        result.ConceptRecord.KeyPropositions.Count.ShouldBe(2);
        var p1 = result.ConceptRecord.KeyPropositions.First(p => p.Key == "P1");
        p1.Misconception.ShouldNotBeNull();
        p1.Misconception.Description.ShouldBe("Overriding and overloading are the same thing");
        result.ConceptRecord.KeyPropositions.First(p => p.Key == "P2").Misconception.ShouldBeNull();
    }

    [Fact]
    public void Removes_kp()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<ElaborationsContext>();
        // CET -7 has KPs P1, P2. Remove KP P2, keeping only P1.
        var updatedEntity = new ConceptElaborationTaskDto
        {
            Id = -7,
            UnitId = -2,
            Order = 4,
            Title = "Polymorphism Mechanics",
            Description = "Runtime method dispatch and virtual call mechanics.",
            ConceptRecord = new ConceptRecordDto
            {
                CanonicalDefinition = "Polymorphism resolves method calls at runtime via dynamic dispatch.",
                KeyPropositions = new List<KeyPropositionDto>
                {
                    new() { Key = "P1", Statement = "A subclass can override a parent method" }
                }
            }
        };
        dbContext.Database.BeginTransaction();

        var actionResult = controller.Update(-2, -7, updatedEntity).Result;
        var result = (actionResult as OkObjectResult)?.Value as ConceptElaborationTaskDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.ConceptRecord.ShouldNotBeNull();
        result.ConceptRecord.KeyPropositions.Count.ShouldBe(1);
        result.ConceptRecord.KeyPropositions[0].Key.ShouldBe("P1");
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
            Description = "Should not be created.",
            ConceptRecord = new ConceptRecordDto
            {
                CanonicalDefinition = "Fail",
                KeyPropositions = new List<KeyPropositionDto>()
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
            Description = "Should not be updated.",
            ConceptRecord = new ConceptRecordDto
            {
                CanonicalDefinition = "Fail",
                KeyPropositions = new List<KeyPropositionDto>()
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
