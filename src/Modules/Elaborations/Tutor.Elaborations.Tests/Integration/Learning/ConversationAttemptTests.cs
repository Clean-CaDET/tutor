using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Learner.Learning.Elaboration;
using Tutor.Elaborations.API.Dtos.Conversations;
using Tutor.Elaborations.API.Public.Learning;
using Tutor.Elaborations.Infrastructure.Database;

namespace Tutor.Elaborations.Tests.Integration.Learning;

[Collection("Sequential")]
public class ConversationAttemptTests : BaseElaborationsIntegrationTest
{
    public ConversationAttemptTests(ElaborationsTestFactory factory) : base(factory) { }

    [Fact]
    public void Abandons_in_progress()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-3");
        var dbContext = scope.ServiceProvider.GetRequiredService<ElaborationsContext>();

        var actionResult = controller.AbandonAttempt(-7).Result;
        var result = (actionResult as OkObjectResult)?.Value as ConversationAttemptDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Status.ShouldBe("Abandoned");
        result.CompletedAt.ShouldNotBeNull();
    }

    [Fact]
    public void Cannot_abandon_completed()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-2");

        var actionResult = controller.AbandonAttempt(-1).Result;
        var objectResult = actionResult as ObjectResult;

        objectResult.ShouldNotBeNull();
        objectResult.StatusCode.ShouldBe(409);
    }

    [Fact]
    public void Wrong_learner_cannot_abandon()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-2");

        var actionResult = controller.AbandonAttempt(-3).Result;
        var objectResult = actionResult as ObjectResult;

        objectResult.ShouldNotBeNull();
        objectResult.StatusCode.ShouldBe(403);
    }

    [Fact]
    public void Fails_to_abandon_nonexistent()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-2");

        var actionResult = controller.AbandonAttempt(-999).Result;
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
