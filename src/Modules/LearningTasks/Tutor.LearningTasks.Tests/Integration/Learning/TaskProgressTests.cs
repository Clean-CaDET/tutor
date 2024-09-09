using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Learner.Learning;
using Tutor.LearningTasks.API.Dtos.TaskProgress;
using Tutor.LearningTasks.API.Public.Learning;
using Tutor.LearningTasks.Infrastructure.Database;

namespace Tutor.LearningTasks.Tests.Integration.Learning;

[Collection("Sequential")]
public class TaskProgressTests : BaseLearningTasksIntegrationTest
{
    public TaskProgressTests(LearningTasksTestFactory factory) : base(factory) { }

    [Fact]
    public void Creates_progress_on_get()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();

        var actionResult = controller.GetOrCreate(-2, -3).Result;
        var okObjectResult = actionResult as OkObjectResult;
        var result = okObjectResult?.Value as TaskProgressDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Id.ShouldBe(-1);
        result.LearningTaskId.ShouldBe(-3);
        result.Status.ShouldBe("Assigned");
        result.TotalScore.ShouldBe(0);
        result.StepProgresses.ShouldNotBeNull();
        result.StepProgresses.Count.ShouldBe(1);
        result.StepProgresses[0].ShouldNotBeNull();
        result.StepProgresses[0].Id.ShouldBe(-1);
        result.StepProgresses[0].Answer.ShouldBe("SomeAnswer");
        result.StepProgresses[0].Status.ShouldBe("Answered");
        result.StepProgresses[0].StepId.ShouldBe(-4);
    }

    [Fact]
    public void Fails_to_create_progress_for_template()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);

        var result = controller.GetOrCreate(-2, -2).Result as ObjectResult;

        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(403);
    }

    [Fact]
    public void Fails_to_get_task_progress_for_unenrolled_learner()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();

        var actionResult = controller.GetOrCreate(-3, -5).Result;
        var objectResult = actionResult as ObjectResult;

        dbContext.ChangeTracker.Clear();
        objectResult.ShouldNotBeNull();
        objectResult.StatusCode.ShouldBe(403);
    }

    [Fact]
    public void Creates()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();

        var actionResult = controller.GetOrCreate(-2, -4).Result;
        var okObjectResult = actionResult as OkObjectResult;
        var result = okObjectResult?.Value as TaskProgressDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.LearningTaskId.ShouldBe(-4);
        result.Status.ShouldBe("Initialized");
        result.TotalScore.ShouldBe(0);
        result.StepProgresses.ShouldNotBeNull();
        result.StepProgresses.Count.ShouldBe(1);
        result.StepProgresses[0].ShouldNotBeNull();
        result.StepProgresses[0].Answer.ShouldBeNull();
        result.StepProgresses[0].Status.ShouldBe("Initialized");
        result.StepProgresses[0].StepId.ShouldBe(-5);

        var storedTask = dbContext.TaskProgresses.Where(p => p.LearningTaskId == result.LearningTaskId && p.LearnerId == -3)
            .Include(l => l.StepProgresses).FirstOrDefault();
        storedTask.ShouldNotBeNull();
        storedTask.LearningTaskId.ShouldBe(-4);
        storedTask.TotalScore.ShouldBe(0);
        storedTask.StepProgresses.ShouldNotBeNull();
        storedTask.StepProgresses.Count.ShouldBe(1);
        result.StepProgresses[0].ShouldNotBeNull();
        storedTask.StepProgresses[0].Answer.ShouldBeNull();
        storedTask.StepProgresses[0].StepId.ShouldBe(-5);
    }

    [Fact]
    public void Fails_to_create_task_progress_for_missing_task()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();

        var actionResult = controller.GetOrCreate(-2, -100).Result;
        var objectResult = actionResult as ObjectResult;

        dbContext.ChangeTracker.Clear();
        objectResult.ShouldNotBeNull();
        objectResult.StatusCode.ShouldBe(404);
    }

    [Fact]
    public void Fails_to_change_step_status_for_view_answered_step()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();

        var actionResult = controller.ViewStep(-2, -1, -4).Result;
        var okObjectResult = actionResult as OkObjectResult;
        var result = okObjectResult?.Value as TaskProgressDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Id.ShouldBe(-1);
        result.LearningTaskId.ShouldBe(-3);
        result.StepProgresses.ShouldNotBeNull();
        result.StepProgresses.Count.ShouldBe(1);
        result.StepProgresses[0].ShouldNotBeNull();
        result.StepProgresses[0].Id.ShouldBe(-1);
        result.StepProgresses[0].Status.ShouldBe("Answered");
        result.StepProgresses[0].StepId.ShouldBe(-4);
    }

    [Fact]
    public void Viewing_initialized_step_changes_step_progress_status()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();

        var actionResult = controller.ViewStep(-2, -3, -8).Result;
        var okObjectResult = actionResult as OkObjectResult;
        var result = okObjectResult?.Value as TaskProgressDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Id.ShouldBe(-3);
        result.LearningTaskId.ShouldBe(-7);
        result.StepProgresses.ShouldNotBeNull();
        result.StepProgresses.Count.ShouldBe(1);
        result.StepProgresses[0].ShouldNotBeNull();
        result.StepProgresses[0].Id.ShouldBe(-3);
        result.StepProgresses[0].Status.ShouldBe("Viewed");
        result.StepProgresses[0].StepId.ShouldBe(-8);
    }

    [Fact]
    public void Fails_to_view_step_for_unenrolled_learner()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();

        var actionResult = controller.ViewStep(-3, -5, -6).Result;
        var objectResult = actionResult as ObjectResult;

        dbContext.ChangeTracker.Clear();
        objectResult.ShouldNotBeNull();
        objectResult.StatusCode.ShouldBe(403);
    }

    [Fact]
    public void Submits_answer()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();

        var stepProgressDto = new StepProgressDto
        {
            Answer = "Answer",
            StepId = -7
        };

        var actionResult = controller.SubmitAnswer(-2, -2, stepProgressDto).Result;
        var okObjectResult = actionResult as OkObjectResult;
        var result = okObjectResult?.Value as TaskProgressDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Id.ShouldBe(-2);
        result.LearningTaskId.ShouldBe(-6);
        result.Status.ShouldBe("Completed");
        result.StepProgresses.ShouldNotBeNull();
        result.StepProgresses.Count.ShouldBe(1);
        result.StepProgresses[0].ShouldNotBeNull();
        result.StepProgresses[0].Id.ShouldBe(-2);
        result.StepProgresses[0].Answer.ShouldBe("Answer");
        result.StepProgresses[0].Status.ShouldBe("Answered");
        result.StepProgresses[0].StepId.ShouldBe(-7);
    }

    [Fact]
    public void Fails_to_submit_answer_for_unenrolled_learner()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();

        var stepProgressDto = new StepProgressDto
        {
            Answer = "Answer",
            StepId = -7
        };

        var actionResult = controller.SubmitAnswer(-3, -5, stepProgressDto).Result;
        var objectResult = actionResult as ObjectResult;

        dbContext.ChangeTracker.Clear();
        objectResult.ShouldNotBeNull();
        objectResult.StatusCode.ShouldBe(403);
    }

    [Fact]
    public void Fails_to_submit_answer_for_missing_task()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();

        var stepProgressDto = new StepProgressDto
        {
            Answer = "Answer",
            StepId = -7
        };

        var actionResult = controller.SubmitAnswer(-2, -100, stepProgressDto).Result;
        var objectResult = actionResult as ObjectResult;

        dbContext.ChangeTracker.Clear();
        objectResult.ShouldNotBeNull();
        objectResult.StatusCode.ShouldBe(404);
    }

    private static TaskProgressController CreateController(IServiceScope scope)
    {
        return new TaskProgressController(scope.ServiceProvider.GetRequiredService<ITaskProgressService>())
        {
            ControllerContext = BuildContext("-3", "learner")
        };
    }
}
