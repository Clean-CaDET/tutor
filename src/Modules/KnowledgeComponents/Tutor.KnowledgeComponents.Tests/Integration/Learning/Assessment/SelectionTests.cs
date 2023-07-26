using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Learner.Learning.Assessment;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems.MultiResponseQuestions;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems.ShortAnswerQuestions;
using Tutor.KnowledgeComponents.API.Interfaces.Learning.Assessment;
using Tutor.KnowledgeComponents.Infrastructure.Database;
using Xunit;

namespace Tutor.KnowledgeComponents.Tests.Integration.Learning.Assessment;

[Collection("Sequential")]
public class SelectionTests : BaseKnowledgeComponentsIntegrationTest
{
    public SelectionTests(KnowledgeComponentsTestFactory factory) : base(factory)
    {
    }

    [Theory]
    [MemberData(nameof(AssessmentItemRequest))]
    public void Gets_suitable_assessment_event(int knowledgeComponentId, int expectedSuitableAssessmentItemId)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-2");

        var actualSuitableAssessmentItem =
            ((OkObjectResult) controller.GetSuitableAssessmentItem(knowledgeComponentId).Result)?.Value as AssessmentItemDto;
        actualSuitableAssessmentItem.ShouldNotBeNull();
            
        actualSuitableAssessmentItem.Id.ShouldBe(expectedSuitableAssessmentItemId);
    }

    private static SelectionController CreateController(IServiceScope scope, string id)
    {
        return new SelectionController(scope.ServiceProvider.GetRequiredService<ISelectionService>())
        {
            ControllerContext = BuildContext(id, "learner")
        };
    }

    public static IEnumerable<object[]> AssessmentItemRequest()
    {
        return new List<object[]>
        {
            new object[]
            {
                -14,
                -144
            },
            new object[]
            {
                -15,
                -153
            },
            new object[]
            {
                -13,
                -134
            }
        };
    }

    [Fact]
    public void Verifies_Mrq_has_no_feedback()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-2");
        var dbContext = scope.ServiceProvider.GetRequiredService<KnowledgeComponentsContext>();
        dbContext.Database.BeginTransaction();

        var item = ((OkObjectResult)controller.GetSuitableAssessmentItem(-15).Result)?.Value as MrqDto;
        
        item.ShouldNotBeNull();
        item.Id.ShouldBe(-153);
        item.Items.All(i => i.Feedback.Equals(string.Empty)).ShouldBeTrue();
    }

    [Fact]
    public void Verifies_Saq_has_no_feedback()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-3");
        var dbContext = scope.ServiceProvider.GetRequiredService<KnowledgeComponentsContext>();
        dbContext.Database.BeginTransaction();

        var response = controller.GetSuitableAssessmentItem(-21).Result;
        
        var item = ((OkObjectResult)response)?.Value as SaqDto;
        item.ShouldNotBeNull();
        item.Id.ShouldBe(-212);
        item.AcceptableAnswers.ShouldBeEmpty();
    }
}