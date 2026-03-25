using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Learner.Learning.Elaboration;
using Tutor.Elaborations.API.Dtos.Conversations;
using Tutor.Elaborations.API.Public.Learning;

namespace Tutor.Elaborations.Tests.Integration.Learning;

[Collection("Sequential")]
public class ConversationQueryTests : BaseElaborationsIntegrationTest
{
    public ConversationQueryTests(ElaborationsTestFactory factory) : base(factory) { }

    [Fact]
    public void Gets_tasks_for_enrolled_unit()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-2");

        var actionResult = controller.GetTasksForUnit(-1).Result;
        var result = (actionResult as OkObjectResult)?.Value as List<ElaborationTaskDto>;

        result.ShouldNotBeNull();
        result.Count.ShouldBe(2);
    }

    [Fact]
    public void Unenrolled_fails_to_get_tasks()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-1");

        var actionResult = controller.GetTasksForUnit(-1).Result;
        var objectResult = actionResult as ObjectResult;

        objectResult.ShouldNotBeNull();
        objectResult.StatusCode.ShouldBe(403);
    }

    [Fact]
    public void Gets_attempt()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-2");

        var actionResult = controller.GetAttempt(-1).Result;
        var result = (actionResult as OkObjectResult)?.Value as ConversationAttemptDto;

        result.ShouldNotBeNull();
        result.Id.ShouldBe(-1);
        result.Status.ShouldBe("Completed");
        result.Summary.ShouldNotBeNullOrEmpty();
        result.Turns.Count.ShouldBe(3);
    }

    [Fact]
    public void Gets_attempts_for_task()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-2");

        var actionResult = controller.GetAttempts(-1).Result;
        var result = (actionResult as OkObjectResult)?.Value as List<ConversationAttemptDto>;

        result.ShouldNotBeNull();
        result.Count.ShouldBe(2);
        result.Any(a => a.Status == "Completed").ShouldBeTrue();
        result.Any(a => a.Status == "Abandoned").ShouldBeTrue();
    }

    [Fact]
    public void Fails_to_get_nonexistent_attempt()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-2");

        var actionResult = controller.GetAttempt(-999).Result;
        var objectResult = actionResult as ObjectResult;

        objectResult.ShouldNotBeNull();
        objectResult.StatusCode.ShouldBe(404);
    }

    [Fact]
    public void Wrong_learner_fails_to_get_attempt()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-3");

        var actionResult = controller.GetAttempt(-1).Result;
        var objectResult = actionResult as ObjectResult;

        objectResult.ShouldNotBeNull();
        objectResult.StatusCode.ShouldBe(403);
    }

    private static ConversationController CreateController(IServiceScope scope, string learnerId)
    {
        return new ConversationController(scope.ServiceProvider.GetRequiredService<IConversationService>())
        {
            ControllerContext = BuildContext(learnerId, "learner")
        };
    }
}
