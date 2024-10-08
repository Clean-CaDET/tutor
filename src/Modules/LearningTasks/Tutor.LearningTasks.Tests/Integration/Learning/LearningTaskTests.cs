﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Learner.Learning;
using Tutor.LearningTasks.API.Dtos.TaskProgress;
using Tutor.LearningTasks.API.Dtos.Tasks;
using Tutor.LearningTasks.API.Public.Learning;
using Tutor.LearningTasks.Infrastructure.Database;

namespace Tutor.LearningTasks.Tests.Integration.Learning;

[Collection("Sequential")]
public class LearningTaskTests : BaseLearningTasksIntegrationTest
{
    public LearningTaskTests(LearningTasksTestFactory factory) : base(factory) { }

    [Fact]
    public void Gets()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();

        var actionResult = controller.Get(-2, -4).Result;
        var okObjectResult = actionResult as OkObjectResult;
        var result = okObjectResult?.Value as LearningTaskDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Id.ShouldBe(-4);
        result.UnitId.ShouldBe(-2);
        result.Name.ShouldBe("FourthTask");
        result.IsTemplate.ShouldBeFalse();
        result.MaxPoints.ShouldBe(10);
        result.Steps.ShouldNotBeNull();
        result.Steps.Count.ShouldBe(1);
        result.Steps[0].Id.ShouldBe(-5);
        result.Steps[0].Order.ShouldBe(1);
        result.Steps[0].SubmissionFormat?.Type.ShouldBe("Link");
        result.Steps[0].Standards?.Count.ShouldBe(1);
        result.Steps[0].Standards?[0].Id.ShouldBe(-5);
        result.Steps[0].Standards?[0].Name.ShouldBe("Standard");
    }

    [Fact]
    public void Fails_to_get_task_for_unenrolled_learner()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();

        var actionResult = controller.Get(-3, -5).Result;
        var objectResult = actionResult as ObjectResult;

        dbContext.ChangeTracker.Clear();
        objectResult.ShouldNotBeNull();
        objectResult.StatusCode.ShouldBe(403);
    }

    [Fact]
    public void Fails_to_get_missing_task()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();

        var actionResult = controller.Get(-2, -100).Result;
        var objectResult = actionResult as ObjectResult;

        dbContext.ChangeTracker.Clear();
        objectResult.ShouldNotBeNull();
        objectResult.StatusCode.ShouldBe(404);
    }

    [Fact]
    public void Gets_by_unit()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();

        var actionResult = controller.GetByUnit(-1).Result;
        var okObjectResult = actionResult as OkObjectResult;
        var result = okObjectResult?.Value as List<TaskProgressSummaryDto>;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Count.ShouldBe(1);
        result[0].Id.ShouldBe(-1);
        result[0].Order.ShouldBe(1);
        result[0].Name.ShouldBe("FirstTask");
        result[0].Status.ShouldBe("Graded");
        result[0].CompletedSteps.ShouldBe(1);
        result[0].TotalSteps.ShouldBe(1);
        result[0].TotalScore.ShouldBe(10);
        result[0].MaxPoints.ShouldBe(10);
    }

    [Fact]
    public void Fails_to_get_tasks_by_unit_for_unenrolled_learner()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();

        var actionResult = controller.GetByUnit(-3).Result;
        var objectResult = actionResult as ObjectResult;

        dbContext.ChangeTracker.Clear();
        objectResult.ShouldNotBeNull();
        objectResult.StatusCode.ShouldBe(403);
    }

    private static LearningTaskController CreateController(IServiceScope scope)
    {
        return new LearningTaskController(scope.ServiceProvider.GetRequiredService<ITaskService>())
        {
            ControllerContext = BuildContext("-3", "learner")
        };
    }
}
