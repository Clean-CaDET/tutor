using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Instructor.Authoring;
using Tutor.LearningTasks.API.Dtos.LearningTasks;
using Tutor.LearningTasks.API.Public.Authoring;
using Tutor.LearningTasks.Infrastructure.Database;

namespace Tutor.LearningTasks.Tests.Integration;

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
        result.Steps?.Count.ShouldBe(1);
        result.Steps?[0].Id.ShouldBe(-5);
        result.Steps?[0].Order.ShouldBe(1);
        result.Steps?[0].Standards?.Count.ShouldBe(1);
        result.Steps?[0].Standards?[0].Id.ShouldBe(-5);
        result.Steps?[0].Standards?[0].Name.ShouldBe("Standard");
    }

    [Fact]
    public void Wrong_instructor_gets_returns_forbidden()
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
    public void Gets_by_unit()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();

        var actionResult = controller.GetByUnit(-1).Result;
        var okObjectResult = actionResult as OkObjectResult;
        var result = okObjectResult?.Value as List<LearningTaskDto>;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Count.ShouldBe(2);
        result[0].Id.ShouldBe(-2);
        result[0].UnitId.ShouldBe(-1);
        result[0].Name.ShouldBe("SecondTask");
        result[0].Steps?.Count.ShouldBe(2);
        result[0].Steps?[0].Standards?.Count.ShouldBe(1);
        result[1].Id.ShouldBe(-1);
        result[1].UnitId.ShouldBe(-1);
        result[1].Name.ShouldBe("FirstTask");
        result[1].Steps?.Count.ShouldBe(0);
    }

    [Fact]
    public void Wrong_instructor_gets_by_unit()
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

    [Fact]
    public void Creates()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();
        var newEntity = new LearningTaskDto
        {
            Name = "New learning task",
            Description = "Some task description",
            IsTemplate = false,
            Steps = new List<ActivityDto> { new ActivityDto
        {
                Order = 1,
                Code = "U1-A1",
                Name = "test",
                Guidance = "guidance",
                Examples = new List<ExampleDto> { new ExampleDto { Code = "U1A1E1", Url = "test" } },
                SubmissionFormat = new SubmissionFormatDto { Guidelines = "guidlanes", AnswerValidation = "validation1"},
                Standards = new List<StandardDto> { new StandardDto { Name = "Standard", Description = "Standard description" , MaxPoints = 10} },
            } }
        };
        dbContext.Database.BeginTransaction();

        var actionResult = controller.Create(-2, newEntity).Result;
        var okObjectResult = actionResult as OkObjectResult;
        var result = okObjectResult?.Value as LearningTaskDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Name.ShouldBe(newEntity.Name);
        result.IsTemplate.ShouldBe(newEntity.IsTemplate);
        result.MaxPoints.ShouldBe(10);

        result.Steps.ShouldNotBeNull();
        result.Steps.Count.ShouldBe(1);
        var resultStep = result.Steps[0];
        var newEntityStep = newEntity.Steps[0];
        resultStep.Order.ShouldBe(newEntityStep.Order);
        resultStep.SubmissionFormat?.AnswerValidation.ShouldBe(newEntityStep.SubmissionFormat?.AnswerValidation);
        resultStep.MaxPoints.ShouldBe(10);

        var resultStandards = resultStep.Standards;
        resultStandards.ShouldNotBeNull();
        var newEntityStandards = newEntityStep.Standards;
        newEntityStandards.ShouldNotBeNull();
        resultStandards.Count.ShouldBe(newEntityStandards.Count);
        var resultStandard = resultStandards[0];
        var newEntityStandard = newEntityStandards[0];
        resultStandard.MaxPoints.ShouldBe(newEntityStandard.MaxPoints);
    }

    [Fact]
    public void Creates_with_steps_that_have_same_value_for_code()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();
        var newEntity = new LearningTaskDto
        {
            Name = "New learning task",
            Description = "Some task description",
            IsTemplate = false,
            Steps = new List<ActivityDto> { new ActivityDto
            {
                Order = 1,
                Code = "U1-LT2-A1",
                Name = "test",
                Guidance = "guidance",
                Examples = new List<ExampleDto> { new ExampleDto { Code = "U1-LT2-A1-E1", Url = "test" } },
                SubmissionFormat = new SubmissionFormatDto { Guidelines = "guidlanes", AnswerValidation = "validation1" },
                Standards = new List<StandardDto> { new StandardDto { Name = "Standard", Description = "Standard description", MaxPoints = 10 } },

            },
            new ActivityDto
            {
                Order = 2,
                Code = "U1-LT2-A1",
                Name = "test",
                Guidance = "guidance",
                Examples = new List<ExampleDto> { new ExampleDto { Code = "U1-LT2-A1-E1", Url = "test" } },
                SubmissionFormat = new SubmissionFormatDto { Guidelines = "guidlanes", AnswerValidation = "validation1" },
                Standards = new List<StandardDto> { new StandardDto { Name = "Standard", Description = "Standard description", MaxPoints = 10 } },

            }}
        };
        dbContext.Database.BeginTransaction();

        var actionResult = controller.Create(-1, newEntity).Result;
        var objectResult = actionResult as ObjectResult;

        dbContext.ChangeTracker.Clear();
        objectResult.ShouldNotBeNull();
        objectResult.StatusCode.ShouldBe(409);
    }

    [Fact]
    public void Wrong_instructor_creates_learning_task_returns_forbidden()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();
        var newEntity = new LearningTaskDto
        {
            Name = "New learning task",
            Description = "Some task description",
            IsTemplate = false,
            Steps = new List<ActivityDto> { new ActivityDto
            {
                Order = 1,
                Code = "U1-A1",
                Name = "test",
                Guidance = "guidance",
                Examples = new List<ExampleDto> { new ExampleDto { Code = "U1A1E1", Url = "test" } },
                SubmissionFormat = new SubmissionFormatDto { Guidelines = "guidlanes", AnswerValidation = "validation1"},
                Standards = new List<StandardDto> { new StandardDto { Name = "Standard", Description = "Standard description" , MaxPoints = 10} },
            } }
        };
        dbContext.Database.BeginTransaction();

        var actionResult = controller.Create(-3, newEntity).Result;
        var objectResult = actionResult as ObjectResult;

        dbContext.ChangeTracker.Clear();
        objectResult.ShouldNotBeNull();
        objectResult.StatusCode.ShouldBe(403);
    }

    [Fact]
    public void Updates()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();
        var newEntity = new LearningTaskDto
        {
            Id = -2,
            Name = "Learning task",
            Description = "Some task description",
            IsTemplate = false,
            Steps = new List<ActivityDto> { new ActivityDto
            {
                Id = -1,
                Order = 1,
                Code = "U1-A1",
                Name = "test",
                Guidance = "guidance",
                Examples = new List<ExampleDto> { new ExampleDto { Code = "Code1", Url = "test" } },
                SubmissionFormat = new SubmissionFormatDto { Guidelines = "guidlanes", AnswerValidation = "validation1"},
                Standards = new List<StandardDto> { new StandardDto { Name = "Standard", Description = "Standard description" , MaxPoints = 10} },
            } }
        };
        dbContext.Database.BeginTransaction();

        var actionResult = controller.Update(-1, newEntity).Result;
        var okObjectResult = actionResult as OkObjectResult;
        var result = okObjectResult?.Value as LearningTaskDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Id.ShouldBe(newEntity.Id);
        result.Name.ShouldBe(newEntity.Name);
        result.IsTemplate.ShouldBe(newEntity.IsTemplate);
        result.MaxPoints.ShouldBe(10);

        result.Steps.ShouldNotBeNull();
        result.Steps.Count.ShouldBe(1);
        var resultStep = result.Steps[0];
        var newEntityStep = newEntity.Steps[0];
        resultStep.Id.ShouldBe(newEntityStep.Id);
        resultStep.Order.ShouldBe(newEntityStep.Order);
        resultStep.SubmissionFormat.ShouldNotBeNull();
        resultStep.SubmissionFormat.AnswerValidation.ShouldBe(newEntityStep.SubmissionFormat?.AnswerValidation);
        resultStep.MaxPoints.ShouldBe(10);

        var resultStandards = resultStep.Standards;
        resultStandards.ShouldNotBeNull();
        var newEntityStandards = newEntityStep.Standards;
        newEntityStandards.ShouldNotBeNull();
        resultStandards.Count.ShouldBe(newEntityStandards.Count);
        var resultStandard = resultStandards[0];
        var newEntityStandard = newEntityStandards[0];
        resultStandard.MaxPoints.ShouldBe(newEntityStandard.MaxPoints);

        var storedEntity = dbContext.LearningTasks.Where(l => l.Id == result.Id).Include(l => l.Steps!)
                .ThenInclude(s => s.Standards).FirstOrDefault();
        storedEntity.ShouldNotBeNull();
        storedEntity.Id.ShouldBe(newEntity.Id);
        storedEntity.Name.ShouldBe(newEntity.Name);
        storedEntity.IsTemplate.ShouldBe(newEntity.IsTemplate);
        storedEntity.MaxPoints.ShouldBe(10);
        storedEntity.Steps.ShouldNotBeNull();
        storedEntity.Steps.Count.ShouldBe(1);
        storedEntity.Steps?[0].MaxPoints.ShouldBe(10);
    }

    [Fact]
    public void Updates_with_steps_that_have_same_value_for_code()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();
        var newEntity = new LearningTaskDto
        {
            Id = -2,
            Name = "Learning task",
            Description = "Some task description",
            IsTemplate = false,
            Steps = new List<ActivityDto> { new ActivityDto
            {
                Order = 1,
                Code = "U1-LT2-A1",
                Name = "test",
                Guidance = "guidance",
                Examples = new List<ExampleDto> { new ExampleDto { Code = "U1-LT2-A1-E1", Url = "test" } },
                SubmissionFormat = new SubmissionFormatDto { Guidelines = "guidlanes", AnswerValidation = "validation1" },
                Standards = new List<StandardDto> { new StandardDto { Name = "Standard", Description = "Standard description", MaxPoints = 10 } },

            },
            new ActivityDto
            {
                Order = 2,
                Code = "U1-LT2-A1",
                Name = "test",
                Guidance = "guidance",
                Examples = new List<ExampleDto> { new ExampleDto { Code = "U1-LT2-A1-E1", Url = "test" } },
                SubmissionFormat = new SubmissionFormatDto { Guidelines = "guidlanes", AnswerValidation = "validation1" },
                Standards = new List<StandardDto> { new StandardDto { Name = "Standard", Description = "Standard description", MaxPoints = 10 } },
            }}
        };
        dbContext.Database.BeginTransaction();

        var actionResult = controller.Update(-1, newEntity).Result;
        var objectResult = actionResult as ObjectResult;

        dbContext.ChangeTracker.Clear();
        objectResult.ShouldNotBeNull();
        objectResult.StatusCode.ShouldBe(409);
    }

    [Fact]
    public void Wrong_instructor_updates_learning_task_returns_forbidden()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();
        var newEntity = new LearningTaskDto
        {
            Id = -2,
            Name = "New name",
            Description = "Some task description",
            IsTemplate = false,
            Steps = new List<ActivityDto> { new ActivityDto
            {
                Id = -5,
                Order = 1,
                Code = "U1-A1",
                Name = "test",
                Guidance = "guidance",
                Examples = new List<ExampleDto> { new ExampleDto { Code = "Code1", Url = "test" } },
                SubmissionFormat = new SubmissionFormatDto { Guidelines = "guidlanes", AnswerValidation = "validation1"},
                Standards = new List<StandardDto> { new StandardDto { Name = "Standard", Description = "Standard description" , MaxPoints = 10} },
            } }
        };
        dbContext.Database.BeginTransaction();

        var actionResult = controller.Update(-3, newEntity).Result;
        var objectResult = actionResult as ObjectResult;

        dbContext.ChangeTracker.Clear();
        objectResult.ShouldNotBeNull();
        objectResult.StatusCode.ShouldBe(403);
        var storedEntity = dbContext.LearningTasks.FirstOrDefault(i => i.Id == newEntity.Id);
        storedEntity.ShouldNotBeNull();
        storedEntity.Name.ShouldNotBe("New name");
    }

    [Fact]
    public void Deletes()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();
        dbContext.Database.BeginTransaction();

        var result = (OkResult)controller.Delete(-1, -2);

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(200);
        var storedEntity = dbContext.LearningTasks.FirstOrDefault(i => i.Id == -2);
        storedEntity.ShouldBeNull();
        var storedStep1Entity = dbContext.Activities.FirstOrDefault(i => i.Id == -1);
        storedStep1Entity.ShouldBeNull();
        var storedStep2Entity = dbContext.Activities.FirstOrDefault(i => i.Id == -2);
        storedStep2Entity.ShouldBeNull();
        var storedStandard1Entity = dbContext.Standards.FirstOrDefault(i => i.Id == -1);
        storedStandard1Entity.ShouldBeNull();
        var storedStandard2Entity = dbContext.Standards.FirstOrDefault(i => i.Id == -2);
        storedStandard2Entity.ShouldBeNull();
    }

    [Fact]
    public void Wrong_instructor_deletes_learning_task_returns_forbidden()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();
        dbContext.Database.BeginTransaction();

        var result = (ObjectResult)controller.Delete(-3, -5);

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(403);
        var storedEntity = dbContext.LearningTasks.FirstOrDefault(i => i.Id == -5);
        storedEntity.ShouldNotBeNull();
    }

    private static LearningTaskController CreateController(IServiceScope scope)
    {
        return new LearningTaskController(scope.ServiceProvider.GetRequiredService<ILearningTaskService>())
        {
            ControllerContext = BuildContext("-51", "instructor")
        };
    }
}