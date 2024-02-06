using Microsoft.AspNetCore.Mvc;
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
    public void GetById()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();

        var actionResult = controller.Get(-1).Result;
        var okObjectResult = actionResult as OkObjectResult;
        var result = okObjectResult?.Value as LearningTaskDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Id.ShouldBe(-1);
        result.UnitId.ShouldBe(-1);
        result.Name.ShouldBe("FirstTask");
        result.Description.ShouldBe("FirstDescription");
        result.IsTemplate.ShouldBeFalse();
        result.DomainModel?.Description.ShouldBe("Description1");
        result.MaxPoints.ShouldBe(10);
        result.CaseStudies.ShouldNotBeNull();
        result.CaseStudies.Count.ShouldBe(1);
        result.CaseStudies[0].Name.ShouldBe("FirstCaseStudy");
        result.CaseStudies[0].Description.ShouldBe("Description1");
        result.Steps.ShouldNotBeNull();
        result.Steps.Count.ShouldBe(1);
        result.Steps[0].Id.ShouldBe(-1);
        result.Steps[0].Order.ShouldBe(1);
        result.Steps[0].ActivityId.ShouldBe(-1);
        result.Steps[0].ActivityName.ShouldBe("C1-A1");
        result.Steps[0].SubmissionFormat?.AnswerValidation.ShouldBe("Validation rules");
        result.Steps[0].SubmissionFormat?.SubmissionGuidelines.ShouldBe("Some guidelines");
        result.Steps[0].MaxPoints.ShouldBe(10);
        result.Steps[0].Standards.ShouldNotBeNull();
        result.Steps[0].Standards?.Count.ShouldBe(2);
        result.Steps[0].Standards?[0].Id.ShouldBe(-1);
        result.Steps[0].Standards?[0].Name.ShouldBe("FirstStandard");
        result.Steps[0].Standards?[0].Description.ShouldBe("Description1");
        result.Steps[0].Standards?[0].MaxPoints.ShouldBe(5);
        result.Steps[0].Standards?[1].Id.ShouldBe(-2);
        result.Steps[0].Standards?[1].Name.ShouldBe("SecondStandard");
        result.Steps[0].Standards?[1].Description.ShouldBe("Description2");
        result.Steps[0].Standards?[1].MaxPoints.ShouldBe(5);
    }

    [Fact]
    public void GetByUnit()
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
        result[0].Description.ShouldBe("SecondDescription");
        result[0].IsTemplate.ShouldBeFalse();
        result[0].DomainModel.ShouldNotBeNull();
        result[0].MaxPoints.ShouldBe(5);
        result[0].CaseStudies.ShouldBeEmpty();
        result[0].Steps.ShouldNotBeNull();
        result[0].Steps?.Count.ShouldBe(1);
        result[0].Steps?[0].MaxPoints.ShouldBe(5);
        result[0].Steps?[0].Standards.ShouldNotBeNull();
        result[0].Steps?[0].Standards?.Count.ShouldBe(1);
        result[1].Id.ShouldBe(-1);
        result[1].UnitId.ShouldBe(-1);
        result[1].Name.ShouldBe("FirstTask");
        result[1].Description.ShouldBe("FirstDescription");
        result[1].IsTemplate.ShouldBeFalse();
        result[1].DomainModel.ShouldNotBeNull();
        result[1].MaxPoints.ShouldBe(10);
        result[1].CaseStudies.ShouldNotBeNull();
        result[1].CaseStudies?.Count.ShouldBe(1);
        result[1].Steps.ShouldNotBeNull();
        result[1].Steps?.Count.ShouldBe(1);
        result[1].Steps?[0].MaxPoints.ShouldBe(10);
        result[1].Steps?[0].Standards.ShouldNotBeNull();
        result[1].Steps?[0].Standards?.Count.ShouldBe(2);
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
            DomainModel = new DomainModelDto { Description = "Domain model description" },
            CaseStudies = new List<CaseStudyDto> { new CaseStudyDto { Name = "Case study name", Description = "Some description" } },
            Steps = new List<StepDto> { new StepDto { Order = 1, ActivityId = -3, ActivityName = "C1-A3",
            SubmissionFormat = new SubmissionFormatDto() {SubmissionGuidelines = "Guidlnes", AnswerValidation = "Validation rules"},
            Standards = new List<StandardDto>() { new StandardDto { Name = "Standard name", Description = "Standard description", MaxPoints = 5 } }
            } }
        };
        dbContext.Database.BeginTransaction();

        var actionResult = controller.Create(-1, newEntity).Result;
        var okObjectResult = actionResult as OkObjectResult;
        var result = okObjectResult?.Value as LearningTaskDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Name.ShouldBe(newEntity.Name);
        result.Description.ShouldBe(newEntity.Description);
        result.IsTemplate.ShouldBe(newEntity.IsTemplate);
        result.DomainModel?.Description.ShouldBe(newEntity.DomainModel.Description);
        result.CaseStudies?.Count.ShouldBe(1);
        result.CaseStudies?[0].Name.ShouldBe(newEntity.CaseStudies[0].Name);
        result.CaseStudies?[0].Description.ShouldBe(newEntity.CaseStudies[0].Description);
        result.Steps?.Count.ShouldBe(1);
        result.Steps?[0].Order.ShouldBe(newEntity.Steps[0].Order);
        result.Steps?[0].ActivityId.ShouldBe(newEntity.Steps[0].ActivityId);
        result.Steps?[0].ActivityName.ShouldBe(newEntity.Steps[0].ActivityName);
        result.Steps?[0].SubmissionFormat?.SubmissionGuidelines.ShouldBe(newEntity.Steps[0].SubmissionFormat?.SubmissionGuidelines);
        result.Steps?[0].Standards?.Count.ShouldBe(1);
        result.Steps?[0].Standards?[0].Name.ShouldBe(newEntity.Steps[0].Standards?[0].Name);
        result.Steps?[0].Standards?[0].Description.ShouldBe(newEntity.Steps[0].Standards?[0].Description);
       
        var resultStandards = result.Steps?[0].Standards;
        resultStandards.ShouldNotBeNull();
        var newEntityStandards = newEntity.Steps?[0].Standards;
        newEntityStandards.ShouldNotBeNull();
        resultStandards.Count.ShouldBe(newEntityStandards.Count);
        var resultStandard = resultStandards[0];
        var newEntityStandard = newEntityStandards[0];
        resultStandard.MaxPoints.ShouldBe(newEntityStandard.MaxPoints);

        result.Steps?[0].MaxPoints.ShouldBe(5);
        result.MaxPoints.ShouldBe(5);
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
            DomainModel = new DomainModelDto { Description = "Domain model description" },
            CaseStudies = new List<CaseStudyDto> { new CaseStudyDto { Name = "Case study name", Description = "Some description" } },
            Steps = new List<StepDto> { new StepDto { Order = 1, ActivityId = -3, ActivityName = "C1-A3",
            SubmissionFormat = new SubmissionFormatDto() {SubmissionGuidelines = "Guidlnes", AnswerValidation = "Validation rules"},
            Standards = new List<StandardDto>() { new StandardDto { Name = "Standard name", Description = "Standard description", MaxPoints = 5 } }
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
    public void Creates_with_step_which_reference_unexisting_activity()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();
        var newEntity = new LearningTaskDto
        {
            Name = "New learning task",
            Description = "Some task description",
            IsTemplate = false,
            DomainModel = new DomainModelDto { Description = "Domain model description" },
            CaseStudies = new List<CaseStudyDto> { new CaseStudyDto { Name = "Case study name", Description = "Some description" } },
            Steps = new List<StepDto> { new StepDto { Order = 1, ActivityId = 0, ActivityName = "C1-A0",
            SubmissionFormat = new SubmissionFormatDto() {SubmissionGuidelines = "Guidlnes", AnswerValidation = "Validation rules"},
            Standards = new List<StandardDto>() { new StandardDto { Name = "Standard name", Description = "Standard description", MaxPoints = 5 } }
            } }
        };
        dbContext.Database.BeginTransaction();

        var actionResult = controller.Create(-1, newEntity).Result;
        var objectResult = actionResult as ObjectResult;

        dbContext.ChangeTracker.Clear();
        objectResult.ShouldNotBeNull();
        objectResult.StatusCode.ShouldBe(404);
    }

    [Fact]
    public void Updates()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();
        var newEntity = new LearningTaskDto
        {
            Id = -3,
            Name = "New name",
            Description = "New description",
            IsTemplate = false,
            DomainModel = new DomainModelDto { Description = "New domain model description" },
            CaseStudies = new List<CaseStudyDto> { new CaseStudyDto { Id = -2, Name = "New name", Description = "New description" } },
            Steps = new List<StepDto> { new StepDto { Id = -3, Order = 1, ActivityId = -3, ActivityName = "C1-A3",
            SubmissionFormat = new SubmissionFormatDto() {SubmissionGuidelines = "New guidlnes", AnswerValidation = "New validation rules"},
            Standards = new List<StandardDto>() { new StandardDto { Id = -4, Name = "New name", Description = "New description", MaxPoints = 5 } }
            } }
        };
        dbContext.Database.BeginTransaction();

        var actionResult = controller.Update(-2, newEntity).Result;
        var okObjectResult = actionResult as OkObjectResult;
        var result = okObjectResult?.Value as LearningTaskDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Id.ShouldBe(newEntity.Id);
        result.Name.ShouldBe(newEntity.Name);
        result.IsTemplate.ShouldBe(newEntity.IsTemplate);
        result.DomainModel.ShouldNotBeNull();
        result.DomainModel.Description.ShouldBe(newEntity.DomainModel.Description);
        result.CaseStudies.ShouldNotBeNull();
        result.CaseStudies.Count.ShouldBe(1);
        result.CaseStudies[0].Name.ShouldBe(newEntity.CaseStudies[0].Name);
        result.CaseStudies[0].Description.ShouldBe(newEntity.CaseStudies[0].Description);
        result.MaxPoints.ShouldBe(5);

        result.Steps.ShouldNotBeNull();
        result.Steps.Count.ShouldBe(1);
        var resultStep = result.Steps[0];
        var newEntityStep = newEntity.Steps[0];
        resultStep.Id.ShouldBe(newEntityStep.Id);
        resultStep.Order.ShouldBe(newEntityStep.Order);
        resultStep.ActivityId.ShouldBe(newEntityStep.ActivityId);
        resultStep.ActivityName.ShouldBe(newEntityStep.ActivityName);
        resultStep.SubmissionFormat.ShouldNotBeNull();
        resultStep.SubmissionFormat.SubmissionGuidelines.ShouldBe(newEntityStep.SubmissionFormat?.SubmissionGuidelines);
        resultStep.SubmissionFormat.AnswerValidation.ShouldBe(newEntityStep.SubmissionFormat?.AnswerValidation);
        resultStep.MaxPoints.ShouldBe(5);

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
    public void Wrong_instructor_updates_learning_task_returns_forbidden()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();
        var newEntity = new LearningTaskDto
        {
            Id = -3,
            Name = "New name",
            Description = "New description",
            IsTemplate = false,
            DomainModel = new DomainModelDto { Description = "New domain model description" },
            CaseStudies = new List<CaseStudyDto> { new CaseStudyDto { Id = -2, Name = "New name", Description = "New description" } },
            Steps = new List<StepDto> { new StepDto { Id = -3, Order = 1, ActivityId = -3, ActivityName = "C1-A3",
            SubmissionFormat = new SubmissionFormatDto() {SubmissionGuidelines = "New guidlnes", AnswerValidation = "New validation rules"},
            Standards = new List<StandardDto>() { new StandardDto { Id = -4, Name = "New name", Description = "New description", MaxPoints = 5 } }
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
    public void Updates_learning_task_with_step_which_reference_unexisting_activity()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();
        var newEntity = new LearningTaskDto
        {
            Id = -3,
            Name = "New name",
            Description = "New description",
            IsTemplate = false,
            DomainModel = new DomainModelDto { Description = "New domain model description" },
            CaseStudies = new List<CaseStudyDto> { new CaseStudyDto { Id = -2, Name = "New name", Description = "New description" } },
            Steps = new List<StepDto> { new StepDto { Id = -3, Order = 1, ActivityId = 0, ActivityName = "C1-A0",
            SubmissionFormat = new SubmissionFormatDto() {SubmissionGuidelines = "New guidlnes", AnswerValidation = "New validation rules"},
            Standards = new List<StandardDto>() { new StandardDto { Id = -4, Name = "New name", Description = "New description", MaxPoints = 5 } }
            } }
        };
        dbContext.Database.BeginTransaction();

        var actionResult = controller.Update(-1, newEntity).Result;
        var objectResult = actionResult as ObjectResult;

        dbContext.ChangeTracker.Clear();
        objectResult.ShouldNotBeNull();
        objectResult.StatusCode.ShouldBe(404);
        var storedEntity = dbContext.Activities.FirstOrDefault(i => i.Id == newEntity.Id);
        storedEntity.ShouldNotBeNull();
        storedEntity.Name.ShouldNotBe("test");
    }

    [Fact]
    public void Deletes()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();
        dbContext.Database.BeginTransaction();

        var result = (OkResult) controller.Delete(-2, -4);

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(200);
        var storedEntity = dbContext.LearningTasks.FirstOrDefault(i => i.Id == -4);
        storedEntity.ShouldBeNull();
        var storedStep1Entity = dbContext.Steps.FirstOrDefault(i => i.Id == -5);
        storedStep1Entity.ShouldBeNull();
        var storedStep2Entity = dbContext.Steps.FirstOrDefault(i => i.Id == -6);
        storedStep2Entity.ShouldBeNull();
        var storedStandard1Entity = dbContext.Standards.FirstOrDefault(i => i.Id == -7);
        storedStandard1Entity.ShouldBeNull();
        var storedStandard2Entity = dbContext.Standards.FirstOrDefault(i => i.Id == -8);
        storedStandard2Entity.ShouldBeNull();
    }

    [Fact]
    public void Wrong_instructor_deletes_learning_task_returns_forbidden()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();
        dbContext.Database.BeginTransaction();

        var result = (ObjectResult) controller.Delete(-3, -5);

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(403);
        var storedEntity = dbContext.Activities.FirstOrDefault(i => i.Id == -5);
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
