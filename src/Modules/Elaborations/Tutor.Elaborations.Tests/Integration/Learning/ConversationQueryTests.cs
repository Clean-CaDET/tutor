using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Learner.Learning.Elaboration;
using Tutor.Elaborations.API.Dtos.ConceptElaborationTasks;
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
        var result = (actionResult as OkObjectResult)?.Value as List<LearnerElaborationSummaryDto>;

        result.ShouldNotBeNull();
        result.Count.ShouldBe(2);
        result.First(t => t.Id == -1).HasCompletedAttempt.ShouldBeTrue();
        result.First(t => t.Id == -2).HasCompletedAttempt.ShouldBeFalse();
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
    public void Gets_task_detail()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-2");

        var actionResult = controller.GetTaskWithAttempts(-1).Result;
        var result = (actionResult as OkObjectResult)?.Value as ConceptElaborationTaskDto;

        result.ShouldNotBeNull();
        result.Id.ShouldBe(-1);
        result.Title.ShouldNotBeNullOrEmpty();
        result.CanonicalDefinition.ShouldNotBeNullOrEmpty();
        result.Attempts.ShouldNotBeNull();
        result.Attempts.Count.ShouldBe(2);
        result.Attempts.Any(a => a.Status == "Completed").ShouldBeTrue();
        result.Attempts.Any(a => a.Status == "Abandoned").ShouldBeTrue();
    }

    [Fact]
    public void Gets_task_detail_with_active_attempt()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-3");

        var actionResult = controller.GetTaskWithAttempts(-2).Result;
        var result = (actionResult as OkObjectResult)?.Value as ConceptElaborationTaskDto;

        result.ShouldNotBeNull();
        result.Attempts.ShouldNotBeNull();
        result.Attempts.Any(a => a.Status == "InProgress").ShouldBeTrue();
    }

    [Fact]
    public void Gets_task_detail_unenrolled_fails()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-1");

        var actionResult = controller.GetTaskWithAttempts(-1).Result;
        var objectResult = actionResult as ObjectResult;

        objectResult.ShouldNotBeNull();
        objectResult.StatusCode.ShouldBe(403);
    }

    [Fact]
    public void Gets_task_detail_nonexistent_fails()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-2");

        var actionResult = controller.GetTaskWithAttempts(-999).Result;
        var objectResult = actionResult as ObjectResult;

        objectResult.ShouldNotBeNull();
        objectResult.StatusCode.ShouldBe(404);
    }

    private static ConversationController CreateController(IServiceScope scope, string learnerId)
    {
        return new ConversationController(scope.ServiceProvider.GetRequiredService<IConversationService>())
        {
            ControllerContext = BuildContext(learnerId, "learner")
        };
    }
}
