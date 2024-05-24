using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Instructor.Authoring;
using Tutor.LearningTasks.API.Dtos.LearningTasks;
using Tutor.LearningTasks.API.Public.Authoring;
using Tutor.LearningTasks.Infrastructure.Database;

namespace Tutor.LearningTasks.Tests.Integration.Authoring;

[Collection("Sequential")]
public class LearningTaskCommandTests : BaseLearningTasksIntegrationTest
{
    public LearningTaskCommandTests(LearningTasksTestFactory factory) : base(factory) { }

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
            Steps = new List<ActivityDto> { new()
            {
                Order = 1,
                Code = "U1-A1",
                Name = "test",
                Guidance = "guidance",
                Examples = new List<ExampleDto> { new() { Code = "U1A1E1", Url = "test" } },
                SubmissionFormat = new SubmissionFormatDto {  Type = "Link", ValidationRule = "validation1", Guidelines = "guidlanes"},
                Standards = new List<StandardDto> { new() { Name = "Standard", Description = "Standard description" , MaxPoints = 10} },
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
        resultStep.SubmissionFormat?.Type.ShouldBe(newEntityStep.SubmissionFormat?.Type);
        resultStep.SubmissionFormat?.ValidationRule.ShouldBe(newEntityStep.SubmissionFormat?.ValidationRule);
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
    public void Fails_to_create_steps_with_non_unique_code()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();
        var newEntity = new LearningTaskDto
        {
            Name = "New learning task",
            Description = "Some task description",
            IsTemplate = false,
            Steps = new List<ActivityDto> { new()
            {
                Order = 1,
                Code = "U1-LT2-A1",
                Name = "test",
                Guidance = "guidance",
                Examples = new List<ExampleDto> { new() { Code = "U1-LT2-A1-E1", Url = "test" } },
                SubmissionFormat = new SubmissionFormatDto {Type = "Link", ValidationRule = "validation", Guidelines = "guidlanes"},
                Standards = new List<StandardDto> { new() { Name = "Standard", Description = "Standard description", MaxPoints = 10 } },
            }, new()
            {
                Order = 2,
                Code = "U1-LT2-A1",
                Name = "test",
                Guidance = "guidance",
                Examples = new List<ExampleDto> { new() { Code = "U1-LT2-A1-E1", Url = "test" } },
                SubmissionFormat = new SubmissionFormatDto {Type = "Link", ValidationRule = "validation", Guidelines = "guidlanes"},
                Standards = new List<StandardDto> { new() { Name = "Standard", Description = "Standard description", MaxPoints = 10 } },
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
    public void Non_owner_fails_to_create_task()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();
        var newEntity = new LearningTaskDto
        {
            Name = "New learning task",
            Description = "Some task description",
            IsTemplate = false,
            Steps = new List<ActivityDto> { new()
            {
                Order = 1,
                Code = "U1-A1",
                Name = "test",
                Guidance = "guidance",
                Examples = new List<ExampleDto> { new() { Code = "U1A1E1", Url = "test" } },
                SubmissionFormat = new SubmissionFormatDto {Type = "Link", ValidationRule = "validation", Guidelines = "guidlanes"},
                Standards = new List<StandardDto> { new() { Name = "Standard", Description = "Standard description" , MaxPoints = 10} },
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
    public void Clones()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();
        var newEntity = new LearningTaskDto
        {
            Id = -5,
            Name = "New learning task",
            Description = "Some task description",
            IsTemplate = false
        };

        var actionResult = controller.Clone(-2, newEntity).Result;
        var okObjectResult = actionResult as OkObjectResult;
        var result = okObjectResult?.Value as LearningTaskDto;

        dbContext.ChangeTracker.Clear();
        AssertResultIsCorrect(result, newEntity);

        var task = dbContext.LearningTasks.Where(l => l.Id == result!.Id)
            .Include(l => l.Steps!).ThenInclude(s => s.Standards).FirstOrDefault();
        task.ShouldNotBeNull();
        task.Name.ShouldBe(newEntity.Name);
        task.MaxPoints.ShouldBe(10);
        task.Steps?.Count.ShouldBe(2);
        task.Steps?[1].Code.ShouldBe("U3-LT5-A1");
        task.Steps?[0].Code.ShouldBe("U3-LT5-A11");
        task.Steps?[0].ParentId.ShouldBe(task.Steps[1].Id);
        task.Steps?[1].Standards?.Count.ShouldBe(1);
        task.Steps?[0].Standards?.Count.ShouldBe(1);
    }

    private static void AssertResultIsCorrect(LearningTaskDto? result, LearningTaskDto newEntity)
    {
        result.ShouldNotBeNull();
        result.Name.ShouldBe(newEntity.Name);
        result.Description.ShouldBe(newEntity.Description);
        result.IsTemplate.ShouldBe(newEntity.IsTemplate);
        result.MaxPoints.ShouldBe(10);
        result.Steps.ShouldNotBeNull();
        result.Steps.Count.ShouldBe(2);
        result.Steps[1].Code.ShouldBe("U3-LT5-A1");
        result.Steps[0].Code.ShouldBe("U3-LT5-A11");
        result.Steps[0].ParentId.ShouldBe(result.Steps[1].Id);
        result.Steps[1].Standards?.Count.ShouldBe(1);
        result.Steps[0].Standards?.Count.ShouldBe(1);
        result.Description.ShouldBe(newEntity.Description);
        result.IsTemplate.ShouldBe(newEntity.IsTemplate);
    }

    [Fact]
    public void Non_owner_fails_to_clone_task()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();
        var newEntity = new LearningTaskDto
        {
            Id = -2,
            Name = "New learning task",
            Description = "Some task description",
            IsTemplate = false
        };

        var actionResult = controller.Clone(-3, newEntity).Result;
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
            Steps = new List<ActivityDto> { new()
            {
                Id = -1,
                Order = 1,
                Code = "U1-A1",
                Name = "test",
                Guidance = "guidance",
                Examples = new List<ExampleDto> { new() { Code = "Code1", Url = "test" } },
                SubmissionFormat = new SubmissionFormatDto {Type = "Code", ValidationRule = "validation", Guidelines = "guidlanes"},
                Standards = new List<StandardDto> { new() { Name = "Standard", Description = "Standard description" , MaxPoints = 10} },
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
        resultStep.SubmissionFormat.Type.ShouldBe(newEntityStep.SubmissionFormat?.Type);
        resultStep.SubmissionFormat.ValidationRule.ShouldBe(newEntityStep.SubmissionFormat?.ValidationRule);
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
    public void Fails_to_update_steps_with_non_unique_code()
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
            Steps = new List<ActivityDto> { new()
            {
                Order = 1,
                Code = "U1-LT2-A1",
                Name = "test",
                Guidance = "guidance",
                Examples = new List<ExampleDto> { new() { Code = "U1-LT2-A1-E1", Url = "test" } },
                SubmissionFormat = new SubmissionFormatDto {Type = "Link", ValidationRule = "validation", Guidelines = "guidlanes"},
                Standards = new List<StandardDto> { new() { Name = "Standard", Description = "Standard description", MaxPoints = 10 } },
            }, new()
            {
                Order = 2,
                Code = "U1-LT2-A1",
                Name = "test",
                Guidance = "guidance",
                Examples = new List<ExampleDto> { new() { Code = "U1-LT2-A1-E1", Url = "test" } },
                SubmissionFormat = new SubmissionFormatDto {Type = "Link", ValidationRule = "validation", Guidelines = "guidlanes"},
                Standards = new List<StandardDto> { new() { Name = "Standard", Description = "Standard description", MaxPoints = 10 } },
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
    public void Non_owner_fails_to_update_task()
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
            Steps = new List<ActivityDto> { new()
            {
                Id = -5,
                Order = 1,
                Code = "U1-A1",
                Name = "test",
                Guidance = "guidance",
                Examples = new List<ExampleDto> { new() { Code = "Code1", Url = "test" } },
                SubmissionFormat = new SubmissionFormatDto {Type = "Link", ValidationRule = "validation", Guidelines = "guidlanes"},
                Standards = new List<StandardDto> { new() { Name = "Standard", Description = "Standard description" , MaxPoints = 10} },
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
    public void Moves()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();

        var result = (OkResult)controller.Move(-2, -2, -4);

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(200);
        var task = dbContext.LearningTasks.FirstOrDefault(l => l.Id == -2);
        task.ShouldNotBeNull();
        task.UnitId.ShouldBe(-4);
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
    public void Non_owner_fails_to_delete_task()
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