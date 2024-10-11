using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Instructor.Monitoring;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Public.Authoring;
using Tutor.LearningTasks.API.Dtos.TaskProgress;
using Tutor.LearningTasks.API.Dtos.Tasks;
using Tutor.LearningTasks.API.Public.Authoring;
using Tutor.LearningTasks.API.Public.Monitoring;
using Tutor.LearningTasks.Infrastructure.Database;

namespace Tutor.LearningTasks.Tests.Integration.Monitoring;

[Collection("Sequential")]
public class TaskGradingTests : BaseLearningTasksIntegrationTest
{
    public TaskGradingTests(LearningTasksTestFactory factory) : base(factory) { }

    [Fact]
    public void Gets_weekly_units()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);

        DateTime date = new DateTime(2021, 12, 26, 0, 0, 0, DateTimeKind.Utc);
        var actionResult = controller.GetUnitsForWeek(-1, -2, date).Result;
        var okObjectResult = actionResult as OkObjectResult;
        var result = okObjectResult?.Value as List<KnowledgeUnitDto>;

        result.ShouldNotBeNull();
        result.Count.ShouldBe(2);
        result[0].Id.ShouldBe(-1);
        result[0].Code.ShouldBe("T-1");
        result[1].Id.ShouldBe(-2);
        result[1].Code.ShouldBe("T-2");
    }

    [Fact]
    public void Gets_empty_list_when_no_units_started_that_week()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);

        DateTime date = new DateTime(2021, 12, 30, 0, 0, 0, DateTimeKind.Utc);
        var actionResult = controller.GetUnitsForWeek(-1, -2, date).Result;
        var okObjectResult = actionResult as OkObjectResult;
        var result = okObjectResult?.Value as List<KnowledgeUnitDto>;

        result.ShouldNotBeNull();
        result.Count.ShouldBe(0);
    }

    [Fact]
    public void Non_owner_fails_to_get_units()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);

        DateTime date = new DateTime(2021, 12, 30, 0, 0, 0, DateTimeKind.Utc);
        var actionResult = controller.GetUnitsForWeek(-4, -4, date).Result;
        var objectResult = actionResult as ObjectResult;

        objectResult.ShouldNotBeNull();
        objectResult.StatusCode.ShouldBe(403);
    }

    [Fact]
    public void Gets_tasks_by_unit()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);

        var actionResult = controller.GetTasksByUnit(-1).Result;
        var okObjectResult = actionResult as OkObjectResult;
        var result = okObjectResult?.Value as List<LearningTaskDto>;

        result.ShouldNotBeNull();
        result.Count.ShouldBe(2);
        result[0].Id.ShouldBe(-2);
        result[0].UnitId.ShouldBe(-1);
        result[0].Name.ShouldBe("SecondTask");
        result[0].Steps?.Count.ShouldBe(2);
        result[0].Steps?[0].Name.ShouldBe("Activity2");
        result[0].Steps?[0].Standards?.Count.ShouldBe(1);
        result[0].Steps?[1].Name.ShouldBe("Activity1");
        result[0].Steps?[1].Standards?.Count.ShouldBe(1);
        result[1].Id.ShouldBe(-1);
        result[1].UnitId.ShouldBe(-1);
        result[1].Name.ShouldBe("FirstTask");
        result[1].Steps?.Count.ShouldBe(2);
    }


    [Fact]
    public void Non_owner_fails_to_get_tasks()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);

        var actionResult = controller.GetTasksByUnit(-3).Result;
        var objectResult = actionResult as ObjectResult;

        objectResult.ShouldNotBeNull();
        objectResult.StatusCode.ShouldBe(403);
    }

    [Fact]
    public void Gets_task_progresses_by_unit_and_learner()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);

        var actionResult = controller.GetByUnitAndLearner(-2, -3).Result as OkObjectResult;
        var result = actionResult!.Value as List<TaskProgressDto>;

        result.ShouldNotBeNull();
        result = result.OrderBy(p => p.Id).ToList();
        result.Count.ShouldBe(5);
        result[0].Id.ShouldBe(-5);
        result[0].StepProgresses?.Count.ShouldBe(1);
        result[0].StepProgresses?[0].Answer.ShouldBe("SomeAnswer");
        result[0].StepProgresses?[0].Evaluations?.Count.ShouldBe(1);
        result[1].Id.ShouldBe(-4);
        result[1].StepProgresses?.Count.ShouldBe(1);
        result[1].StepProgresses?[0].Answer.ShouldBe("SomeAnswer");
        result[1].StepProgresses?[0].Evaluations?.Count.ShouldBe(1);
        result[1].StepProgresses?[0].Evaluations?[0].StandardId.ShouldBe(-7);
        result[1].StepProgresses?[0].Evaluations?[0].Points.ShouldBe(5);
        result[1].StepProgresses?[0].Evaluations?[0].Comment.ShouldBe("Excellent");
        result[1].StepProgresses?[0].Comment.ShouldBe("Good job!");
        result[2].Id.ShouldBe(-3);
        result[3].Id.ShouldBe(-2);
        result[4].Id.ShouldBe(-1);
        result[4].StepProgresses?[0].Status.ShouldBe("Answered");
        result[4].StepProgresses?[0].Answer.ShouldBe("SomeAnswer");
    }

    [Fact]
    public void Non_owner_fails_to_get_task_progresses()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);

        var actionResult = controller.GetByUnitAndLearner(-3, -3).Result;
        var objectResult = actionResult as ObjectResult;

        objectResult.ShouldNotBeNull();
        objectResult.StatusCode.ShouldBe(403);
    }

    [Fact]
    public void Submits_grade()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();

        var stepProgressDto = new StepProgressDto
        {
            StepId = -10,
            Evaluations = new List<StandardEvaluationDto> { new() { StandardId = -8, Points = 10, Comment = "Great!" } },
            Comment = "Great job!"
        };

        var actionResult = controller.SubmitGrade(-2, -5, stepProgressDto).Result;
        var okObjectResult = actionResult as OkObjectResult;
        var result = okObjectResult?.Value as TaskProgressDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Id.ShouldBe(-5);
        result.Status.ShouldBe("Graded");
        result.StepProgresses.ShouldNotBeNull();
        result.StepProgresses.Count.ShouldBe(1);
        result.StepProgresses[0].ShouldNotBeNull();
        result.StepProgresses[0].Id.ShouldBe(-5);
        result.StepProgresses[0].Status.ShouldBe("Graded");
        result.StepProgresses[0].Evaluations?.ShouldNotBeNull();
        result.StepProgresses[0].Evaluations?.Count.ShouldBe(1);
        result.StepProgresses[0].Evaluations?[0].StandardId.ShouldBe(-8);
        result.StepProgresses[0].Evaluations?[0].Points.ShouldBe(10);
        result.StepProgresses[0].Evaluations?[0].Comment.ShouldBe("Great!");
        result.StepProgresses[0].Comment.ShouldBe("Great job!");
    }
    [Fact]
    public void Non_owner_fails_to_submit_grade()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);

        var stepProgressDto = new StepProgressDto
        {
            StepId = 0,
            Evaluations = new List<StandardEvaluationDto> { new() { StandardId = 0, Points = 10, Comment = "Great!" } },
            Comment = "Great job!"
        };

        var actionResult = controller.SubmitGrade(-3, 0, stepProgressDto).Result;
        var objectResult = actionResult as ObjectResult;

        objectResult.ShouldNotBeNull();
        objectResult.StatusCode.ShouldBe(403);
    }

    private static TaskGradingController CreateController(IServiceScope scope)
    {
        return new TaskGradingController(scope.ServiceProvider.GetRequiredService<ILearningTaskService>(), 
            scope.ServiceProvider.GetRequiredService<IGradingService>(), scope.ServiceProvider.GetRequiredService<IUnitService>())
        {
            ControllerContext = BuildContext("-51", "instructor")
        };
    }
}
