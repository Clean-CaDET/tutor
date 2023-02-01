using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.UseCases.Management.Knowledge;
using Tutor.Infrastructure.Database;
using Tutor.Web.Controllers.Instructors.Authoring;
using Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems;
using Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems.MultiChoiceQuestions;
using Xunit;

namespace Tutor.Web.Tests.Integration.Authoring;

[Collection("Sequential")]
public class AssessmentTests : BaseWebIntegrationTest
{
    public AssessmentTests(TutorApplicationTestFactory<Startup> factory) : base(factory) { }

    [Fact]
    public void Gets()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupController(scope);

        var result = ((OkObjectResult)controller.GetForKc(-10).Result)?.Value as List<AssessmentItemDto>;

        result.ShouldNotBeNull();
        result.Count.ShouldBe(2);
        result.First(a => a.Id == -106).KnowledgeComponentId.ShouldBe(-10);
    }

    [Fact]
    public void Creates()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();
        var newEntity = new McqDto
        {
            KnowledgeComponentId = -11,
            Text = "TT-1"
        };
        dbContext.Database.BeginTransaction();

        var result = ((OkObjectResult)controller.Create(newEntity).Result)?.Value as McqDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Id.ShouldNotBe(0);
        result.KnowledgeComponentId.ShouldBe(newEntity.KnowledgeComponentId);
        result.Text.ShouldBe(newEntity.Text);
        var storedEntity = dbContext.MultiChoiceQuestions.FirstOrDefault(i => i.Text == newEntity.Text);
        storedEntity.ShouldNotBeNull();
        storedEntity.Id.ShouldBe(result.Id);
        storedEntity.KnowledgeComponentId.ShouldBe(result.KnowledgeComponentId);
    }

    [Fact]
    public void Updates()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();
        var updatedEntity = new McqDto
        {
            Id = -10001,
            KnowledgeComponentId = -21,
            Feedback = "TT-1"
        };
        dbContext.Database.BeginTransaction();

        var result = ((OkObjectResult)controller.Update(updatedEntity).Result)?.Value as McqDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Id.ShouldBe(updatedEntity.Id);
        result.Feedback.ShouldBe(updatedEntity.Feedback);
        var savedEntity = dbContext.MultiChoiceQuestions.FirstOrDefault(i => i.Id == updatedEntity.Id);
        savedEntity.ShouldNotBeNull();
        savedEntity.Id.ShouldBe(updatedEntity.Id);
        savedEntity.Feedback.ShouldBe(updatedEntity.Feedback);
        var oldEntity = dbContext.MultiChoiceQuestions.FirstOrDefault(i => i.Feedback == "Feedback");
        oldEntity.ShouldBeNull();
    }

    [Fact]
    public void Deletes()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();
        dbContext.Database.BeginTransaction();

        var result = (OkResult)controller.Delete(-15, -153);

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(200);
        var storedEntity = dbContext.MultiResponseQuestions.FirstOrDefault(i => i.Id == -153);
        storedEntity.ShouldBeNull();
    }

    private AssessmentController SetupController(IServiceScope scope)
    {
        return new AssessmentController(Factory.Services.GetRequiredService<IMapper>(),
            scope.ServiceProvider.GetRequiredService<IAssessmentService>())
        {
            ControllerContext = BuildContext("-51", "instructor")
        };
    }
}