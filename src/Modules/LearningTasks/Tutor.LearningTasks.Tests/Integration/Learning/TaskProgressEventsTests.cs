using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Learner.Learning;
using Tutor.LearningTasks.API.Public.Learning;
using Tutor.LearningTasks.Infrastructure.Database;

namespace Tutor.LearningTasks.Tests.Integration.Learning;

[Collection("Sequential")]
public class TaskProgressEventsTests : BaseLearningTasksIntegrationTest
{
    public TaskProgressEventsTests(LearningTasksTestFactory factory) : base(factory) { }
    
    [Fact]
    public void OpenSubmission()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();
        
        var result = controller.OpenSubmission(-2, -2, -4);

        result.ShouldBeOfType<OkResult>();
        VerifyEventGenerated(dbContext, "SubmissionOpened");
    }

    [Fact]
    public void OpenGuidance()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();

        var result = controller.OpenGuidance(-2, -2, -4);

        result.ShouldBeOfType<OkResult>();
        VerifyEventGenerated(dbContext, "GuidanceOpened");
    }

    [Fact]
    public void OpenExample()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();

        var result = controller.OpenExample(-2, -2, -4);

        result.ShouldBeOfType<OkResult>();
        VerifyEventGenerated(dbContext, "ExampleOpened");
    }

    [Fact]
    public void PlayExampleVideo()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();

        var result = controller.PlayExampleVideo(-2, -2, -4, "videoUrl");

        result.ShouldBeOfType<OkResult>();
        VerifyEventGenerated(dbContext, "ExampleVideoPlayed");
    }

    [Fact]
    public void StopExampleVideo()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();

        var result = controller.PauseExampleVideo(-2, -2, -4, "videoUrl");

        result.ShouldBeOfType<OkResult>();
        VerifyEventGenerated(dbContext, "ExampleVideoPaused");
    }

    [Fact]
    public void FinishExampleVideo()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();

        var result = controller.FinishExampleVideo(-2, -2, -4, "videoUrl");

        result.ShouldBeOfType<OkResult>();
        VerifyEventGenerated(dbContext, "ExampleVideoFinished");
    }

    private static TaskProgressController CreateController(IServiceScope scope)
    {
        return new TaskProgressController(scope.ServiceProvider.GetRequiredService<ITaskProgressService>())
        {
            ControllerContext = BuildContext("-3", "learner")
        };
    }

    private static void VerifyEventGenerated(LearningTasksContext dbContext, string eventType)
    {
        var generatedEvent = dbContext.Events.OrderBy(e => e.TimeStamp).LastOrDefault();
        generatedEvent.ShouldNotBeNull();
        generatedEvent.TimeStamp.ShouldBeInRange(DateTime.UtcNow.AddMinutes(-1), DateTime.UtcNow);
        generatedEvent.DomainEvent.RootElement.GetProperty("$discriminator").GetString().ShouldBe(eventType);
    }
}
