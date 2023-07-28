using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Instructor.Authoring;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems.MultiChoiceQuestions;
using Tutor.KnowledgeComponents.API.Interfaces.Authoring;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.AssessmentItems.MultiChoiceQuestions;
using Tutor.KnowledgeComponents.Infrastructure.Database;

namespace Tutor.KnowledgeComponents.Tests.Integration.Authoring;

[Collection("Sequential")]
public class AssessmentTests : BaseKnowledgeComponentsIntegrationTest
{
    public AssessmentTests(KnowledgeComponentsTestFactory factory) : base(factory) { }

    [Fact]
    public void Gets()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);

        var result = ((OkObjectResult)controller.GetForKc(-10).Result)?.Value as List<AssessmentItemDto>;

        result.ShouldNotBeNull();
        result.Count.ShouldBe(2);
        result.First(a => a.Id == -106).KnowledgeComponentId.ShouldBe(-10);
    }

    [Fact]
    public void Creates()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<KnowledgeComponentsContext>();
        var newEntity = new McqDto
        {
            KnowledgeComponentId = -11,
            Text = "TT-1",
            CorrectAnswer = "",
            Feedback = ""
        };
        dbContext.Database.BeginTransaction();

        var result = ((OkObjectResult)controller.Create(newEntity).Result)?.Value as McqDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Id.ShouldNotBe(0);
        result.KnowledgeComponentId.ShouldBe(newEntity.KnowledgeComponentId);
        result.Text.ShouldBe(newEntity.Text);
        var storedEntity = dbContext.AssessmentItems.FirstOrDefault(a => ((Mcq)a).Text == newEntity.Text);
        storedEntity.ShouldNotBeNull();
        storedEntity.Id.ShouldBe(result.Id);
        storedEntity.KnowledgeComponentId.ShouldBe(result.KnowledgeComponentId);
    }

    [Fact]
    public void Updates()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<KnowledgeComponentsContext>();
        var updatedEntity = new McqDto
        {
            Id = -10001,
            KnowledgeComponentId = -21,
            Feedback = "TT-1",
            CorrectAnswer = "",
            Text = ""
        };
        dbContext.Database.BeginTransaction();

        var result = ((OkObjectResult)controller.Update(updatedEntity).Result)?.Value as McqDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Id.ShouldBe(updatedEntity.Id);
        result.Feedback.ShouldBe(updatedEntity.Feedback);
        var savedEntity = (Mcq)dbContext.AssessmentItems.FirstOrDefault(i => i.Id == updatedEntity.Id);
        savedEntity.ShouldNotBeNull();
        savedEntity.Id.ShouldBe(updatedEntity.Id);
        savedEntity.Feedback.ShouldBe(updatedEntity.Feedback);
        var oldEntity = dbContext.AssessmentItems.FirstOrDefault(i => ((Mcq)i).Feedback == "Feedback");
        oldEntity.ShouldBeNull();
    }

    [Fact]
    public void Deletes()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<KnowledgeComponentsContext>();
        dbContext.Database.BeginTransaction();

        var result = (OkResult)controller.Delete(-15, -153);

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(200);
        var storedEntity = dbContext.AssessmentItems.FirstOrDefault(i => i.Id == -153);
        storedEntity.ShouldBeNull();
    }

    private static AssessmentController CreateController(IServiceScope scope)
    {
        return new AssessmentController(scope.ServiceProvider.GetRequiredService<IAssessmentService>())
        {
            ControllerContext = BuildContext("-51", "instructor")
        };
    }
}