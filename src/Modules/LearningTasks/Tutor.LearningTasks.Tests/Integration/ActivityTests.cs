using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Instructor.Authoring.LearningTasks;
using Tutor.LearningTasks.API.Dtos.LearningTasks;
using Tutor.LearningTasks.API.Public.Authoring;
using Tutor.LearningTasks.Infrastructure.Database;

namespace Tutor.LearningTasks.Tests.Integration;

public class ActivityTests : BaseLearningTasksIntegrationTest
{
    public ActivityTests(LearningTasksTestFactory factory) : base(factory) { }

    [Fact]
    public void Creates()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();
        var newEntity = new ActivityDto
        {
            Order = 1,
            Code = "U1-A1",
            Name = "test",
            Guidance = "guidance",
            Examples = new List<ExampleDto> { new ExampleDto { Code = "U1A1E1", Url = "test" } },
            SubmissionFormat = new SubmissionFormatDto { Guidelines = "guidlanes", AnswerValidation = "validation1"},
            Standards = new List<StandardDto> { new StandardDto { Name = "Standard", Description = "Standard description" , MaxPoints = 10} },
        };
        dbContext.Database.BeginTransaction();

        var actionResult = controller.Create(-1, -1, newEntity).Result;
        var okObjectResult = actionResult as OkObjectResult;
        var result = okObjectResult?.Value as ActivityDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Code.ShouldBe(newEntity.Code);
        result.Name.ShouldBe(newEntity.Name);
        result.UnitId.ShouldBe(-1);
        result.Guidance.ShouldBe(newEntity.Guidance);
        result.Examples.ShouldNotBeNull();
        result.Examples.Count.ShouldBe(1);
        result.Examples[0].Code.ShouldBe(newEntity.Examples[0].Code);
        result.Examples[0].Url.ShouldBe(newEntity.Examples[0].Url);
        result.SubmissionFormat?.Guidelines.ShouldBe(newEntity.SubmissionFormat.Guidelines);
        result.SubmissionFormat?.AnswerValidation.ShouldBe(newEntity.SubmissionFormat.AnswerValidation);
        result.Standards.ShouldNotBeNull();
        result.Standards.Count.ShouldBe(1);
        result.Standards[0].Name.ShouldBe(newEntity.Standards[0].Name);
        result.Standards[0].Description.ShouldBe(newEntity.Standards[0].Description);
        result.MaxPoints.ShouldBe(10);
        var storedEntity = dbContext.Activities.Where(i => i.Id == result.Id).Include(s => s.Standards).FirstOrDefault();
        storedEntity.ShouldNotBeNull();
        storedEntity.Name.ShouldBe(newEntity.Name);
        storedEntity.Examples.ShouldNotBeNull();
        storedEntity.Examples.Count.ShouldBe(1);
        storedEntity.Examples[0].Code.ShouldBe(result.Examples[0].Code);
        storedEntity.Examples[0].Url.ShouldBe(result.Examples[0].Url);
        storedEntity.SubmissionFormat.ShouldNotBeNull();
        storedEntity.Standards.ShouldNotBeNull();
        storedEntity.Standards.Count.ShouldBe(1);
        storedEntity.Standards[0].Name.ShouldBe(result.Standards[0].Name);
        storedEntity.Standards[0].Description.ShouldBe(result.Standards[0].Description);
        storedEntity.Standards[0].MaxPoints.ShouldBe(result.Standards[0].MaxPoints);
    }

    [Fact]
    public void Creates_with_existing_value_for_code()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();
        var newEntity = new ActivityDto
        {
            Order = 2,
            Code = "U1-LT2-A1",
            Name = "test",
            Guidance = "guidance",
            Examples = new List<ExampleDto> { new ExampleDto { Code = "U1-LT2-A1-E1", Url = "test" } },
            SubmissionFormat = new SubmissionFormatDto { Guidelines = "guidlanes", AnswerValidation = "validation1" },
            Standards = new List<StandardDto> { new StandardDto { Name = "Standard", Description = "Standard description", MaxPoints = 10 } },
        };
        dbContext.Database.BeginTransaction();

        var actionResult = controller.Create(-1, -2, newEntity).Result;
        var objectResult = actionResult as ObjectResult;

        dbContext.ChangeTracker.Clear();
        objectResult.ShouldNotBeNull();
        objectResult.StatusCode.ShouldBe(409);
    }

    [Fact]
    public void Wrong_instructor_creates_activity_returns_forbidden()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();
        var newEntity = new ActivityDto
        {
            Order = 1,
            Code = "U3-LT5-A1",
            Name = "test",
            Guidance = "guidance",
            Examples = new List<ExampleDto> { new ExampleDto { Code = "U3-LT5-A1-E1", Url = "test" } },
            SubmissionFormat = new SubmissionFormatDto { Guidelines = "guidlanes", AnswerValidation = "validation1" },
            Standards = new List<StandardDto> { new StandardDto { Name = "Standard", Description = "Standard description", MaxPoints = 10 } },
        };
        dbContext.Database.BeginTransaction();

        var actionResult = controller.Create(-3, -5, newEntity).Result;
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
        var newEntity = new ActivityDto
        {
            Id = -2,
            Order = 2,
            Code = "U1-A2",
            Name = "test",
            Guidance = "guidance",
            Examples = new List<ExampleDto> { new ExampleDto { Code = "U1A2E1", Url = "test" } },
            SubmissionFormat = new SubmissionFormatDto { Guidelines = "guidlanes", AnswerValidation = "validation2" },
            Standards = new List<StandardDto> { new StandardDto { Name = "Standard", Description = "Standard description", MaxPoints = 20 } },
        };
        dbContext.Database.BeginTransaction();

        var actionResult = controller.Update(-1, -2, newEntity).Result;
        var okObjectResult = actionResult as OkObjectResult;
        var result = okObjectResult?.Value as ActivityDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Code.ShouldBe(newEntity.Code);
        result.Name.ShouldBe(newEntity.Name);
        result.UnitId.ShouldBe(-1);
        result.Guidance.ShouldBe(newEntity.Guidance);
        result.Examples.ShouldNotBeNull();
        result.Examples.Count.ShouldBe(1);
        result.Examples[0].Code.ShouldBe(newEntity.Examples[0].Code);
        result.Examples[0].Url.ShouldBe(newEntity.Examples[0].Url);
        result.SubmissionFormat?.Guidelines.ShouldBe(newEntity.SubmissionFormat.Guidelines);
        result.SubmissionFormat?.AnswerValidation.ShouldBe(newEntity.SubmissionFormat.AnswerValidation);
        result.Standards.ShouldNotBeNull();
        result.Standards.Count.ShouldBe(1);
        result.Standards[0].Name.ShouldBe(newEntity.Standards[0].Name);
        result.Standards[0].Description.ShouldBe(newEntity.Standards[0].Description);
        result.MaxPoints.ShouldBe(newEntity.Standards[0].MaxPoints);
        var storedEntity = dbContext.Activities.Where(i => i.Id == result.Id).Include(s => s.Standards).FirstOrDefault();
        storedEntity.ShouldNotBeNull();
        storedEntity.Name.ShouldBe(newEntity.Name);
        storedEntity.Examples.ShouldNotBeNull();
        storedEntity.Examples.Count.ShouldBe(1);
        storedEntity.Examples[0].Code.ShouldBe(result.Examples[0].Code);
        storedEntity.Examples[0].Url.ShouldBe(result.Examples[0].Url);
        storedEntity.SubmissionFormat.ShouldNotBeNull();
        storedEntity.Standards.ShouldNotBeNull();
        storedEntity.Standards.Count.ShouldBe(1);
        storedEntity.Standards[0].Name.ShouldBe(result.Standards[0].Name);
        storedEntity.Standards[0].Description.ShouldBe(result.Standards[0].Description);
        storedEntity.Standards[0].MaxPoints.ShouldBe(result.Standards[0].MaxPoints);
        var learningTask = dbContext.LearningTasks.Where(l => l.Id == -2).First();
        learningTask.MaxPoints.ShouldBe(30);
    }

    [Fact]
    public void Updates_with_existing_value_for_code()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();
        var newEntity = new ActivityDto
        {
            Id = -2,
            Order = 2,
            Code = "U1-LT2-A1",
            Name = "test",
            Guidance = "guidance",
            Examples = new List<ExampleDto> { new ExampleDto { Code = "U1-LT2-A1-E1", Url = "test" } },
            SubmissionFormat = new SubmissionFormatDto { Guidelines = "guidlanes", AnswerValidation = "validation1" },
            Standards = new List<StandardDto> { new StandardDto { Name = "Standard", Description = "Standard description", MaxPoints = 10 } },
        };
        dbContext.Database.BeginTransaction();

        var actionResult = controller.Update(-1, -2, newEntity).Result;
        var objectResult = actionResult as ObjectResult;

        dbContext.ChangeTracker.Clear();
        objectResult.ShouldNotBeNull();
        objectResult.StatusCode.ShouldBe(409);
    }

    [Fact]
    public void Wrong_instructor_updates_activity_returns_forbidden()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();
        var newEntity = new ActivityDto
        {
            Id = -3,
            Order = 1,
            Code = "U3-LT5-A1",
            Name = "test",
            Guidance = "guidance",
            Examples = new List<ExampleDto> { new ExampleDto { Code = "U3-LT5-A1-E1", Url = "test" } },
            SubmissionFormat = new SubmissionFormatDto { Guidelines = "guidlanes", AnswerValidation = "validation1" },
            Standards = new List<StandardDto> { new StandardDto { Name = "Standard", Description = "Standard description", MaxPoints = 10 } },
        };
        dbContext.Database.BeginTransaction();

        var actionResult = controller.Update(-3, -5, newEntity).Result;
        var objectResult = actionResult as ObjectResult;

        dbContext.ChangeTracker.Clear();
        objectResult.ShouldNotBeNull();
        objectResult.StatusCode.ShouldBe(403);
    }

    [Fact]
    public void Deletes()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();
        dbContext.Database.BeginTransaction();

        var result = (OkResult)controller.Delete(-2, -3, -4);

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(200);
        var storedEntity = dbContext.Activities.FirstOrDefault(i => i.Id == -4);
        storedEntity.ShouldBeNull();
        var storedStep1 = dbContext.Standards.FirstOrDefault(i => i.Id == -4);
        storedStep1.ShouldBeNull();
        var learningTask = dbContext.LearningTasks.Where(l => l.Id == -3).First();
        learningTask.MaxPoints.ShouldBe(0);
    }

    [Fact]
    public void Wrong_instructor_deletes_activity_returns_forbidden()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();
        dbContext.Database.BeginTransaction();

        var result = (ObjectResult)controller.Delete(-3, -5, -3);

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(403);
        var storedEntity = dbContext.Activities.FirstOrDefault(i => i.Id == -3);
        storedEntity.ShouldNotBeNull();
    }

    private static ActivityController CreateController(IServiceScope scope)
    {
        return new ActivityController(scope.ServiceProvider.GetRequiredService<IActivityService>())
        {
            ControllerContext = BuildContext("-51", "instructor")
        };
    }
}
