using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Instructor.Authoring.Elaboration;
using Tutor.Elaborations.API.Dtos.Conversations;
using Tutor.Elaborations.API.Public.Authoring;
using Tutor.Elaborations.Infrastructure.Database;

namespace Tutor.Elaborations.Tests.Integration.Authoring;

[Collection("Sequential")]
public class ElaborationTaskCommandTests : BaseElaborationsIntegrationTest
{
    public ElaborationTaskCommandTests(ElaborationsTestFactory factory) : base(factory) { }

    [Fact]
    public void Creates()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<ElaborationsContext>();
        var newEntity = new ElaborationTaskDto
        {
            ConceptRecordId = -1,
            UnitId = -1,
            ExpectedLevel = "Beginner",
            Order = 10
        };
        dbContext.Database.BeginTransaction();

        var actionResult = controller.Create(-1, newEntity).Result;
        var result = (actionResult as OkObjectResult)?.Value as ElaborationTaskDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.ConceptRecordId.ShouldBe(-1);
        result.UnitId.ShouldBe(-1);
        result.ExpectedLevel.ShouldBe("Beginner");
        result.Order.ShouldBe(10);
    }

    [Fact]
    public void Updates()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<ElaborationsContext>();
        var updatedEntity = new ElaborationTaskDto
        {
            Id = -1,
            ConceptRecordId = -1,
            UnitId = -1,
            ExpectedLevel = "Intermediate",
            Order = 1
        };
        dbContext.Database.BeginTransaction();

        var actionResult = controller.Update(-1, -1, updatedEntity).Result;
        var result = (actionResult as OkObjectResult)?.Value as ElaborationTaskDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Id.ShouldBe(-1);
        result.ExpectedLevel.ShouldBe("Intermediate");
    }

    [Fact]
    public void Deletes()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<ElaborationsContext>();
        dbContext.Database.BeginTransaction();

        var result = (OkResult)controller.Delete(-1, -2);

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(200);
        var stored = dbContext.ElaborationTasks.FirstOrDefault(t => t.Id == -2);
        stored.ShouldBeNull();
    }

    [Fact]
    public void Non_owner_fails_to_create()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var newEntity = new ElaborationTaskDto
        {
            ConceptRecordId = -2, UnitId = -3, ExpectedLevel = "Beginner", Order = 1
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
        var updatedEntity = new ElaborationTaskDto
        {
            Id = -4, ConceptRecordId = -2, UnitId = -3, ExpectedLevel = "Beginner", Order = 1
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

    private static ElaborationTaskController CreateController(IServiceScope scope)
    {
        return new ElaborationTaskController(scope.ServiceProvider.GetRequiredService<IElaborationTaskService>())
        {
            ControllerContext = BuildContext("-51", "instructor")
        };
    }
}
