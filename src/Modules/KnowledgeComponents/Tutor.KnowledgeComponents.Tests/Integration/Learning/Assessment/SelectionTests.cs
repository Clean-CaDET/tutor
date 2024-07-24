using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Learner.Learning.Assessment;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems.MultiResponseQuestions;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems.ShortAnswerQuestions;
using Tutor.KnowledgeComponents.API.Public.Learning.Assessment;
using Tutor.KnowledgeComponents.Infrastructure.Database;

namespace Tutor.KnowledgeComponents.Tests.Integration.Learning.Assessment;

[Collection("Sequential")]
public class SelectionTests : BaseKnowledgeComponentsIntegrationTest
{
    public SelectionTests(KnowledgeComponentsTestFactory factory) : base(factory)
    {
    }

    [Theory]
    [MemberData(nameof(AssessmentItemRequest))]
    public void Gets_suitable_assessment_item(int knowledgeComponentId, int expectedSuitableAssessmentItemId)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-2");

        var actualSuitableAssessmentItem =
            ((OkObjectResult) controller.GetSuitableAssessmentItem(knowledgeComponentId, "M1").Result)?.Value as AssessmentItemDto;
        actualSuitableAssessmentItem.ShouldNotBeNull();
            
        actualSuitableAssessmentItem.Id.ShouldBe(expectedSuitableAssessmentItemId);
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
                -10,
                -106
            }
        };
    }

    [Fact]
    public void Gets_all_assessment_items()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-4");

        var actualItems =
            ((OkObjectResult)controller.GetAssessmentItems(-41, "M1").Result)?.Value as List<AssessmentItemDto>;

        actualItems.ShouldNotBeNull();
        actualItems.Count.ShouldBe(1);
    }

    [Fact]
    public void Fails_to_get_assessment_items_for_unsatisfied_kc()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-2");

        var response = (ObjectResult)controller.GetAssessmentItems(-15, "M1").Result;

        response.ShouldNotBeNull();
        response.StatusCode.ShouldBe(403);
    }

    [Fact]
    public void Verifies_Mrq_has_no_feedback()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-2");
        var dbContext = scope.ServiceProvider.GetRequiredService<KnowledgeComponentsContext>();
        dbContext.Database.BeginTransaction();

        var item = ((OkObjectResult)controller.GetSuitableAssessmentItem(-15, "M1").Result)?.Value as MrqDto;
        
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

        var response = controller.GetSuitableAssessmentItem(-21, "M1").Result;
        
        var item = ((OkObjectResult)response)?.Value as SaqDto;
        item.ShouldNotBeNull();
        item.Id.ShouldBe(-212);
        item.AcceptableAnswers.ShouldBeEmpty();
    }

    private static SelectionController CreateController(IServiceScope scope, string id)
    {
        return new SelectionController(scope.ServiceProvider.GetRequiredService<ISelectionService>())
        {
            ControllerContext = BuildContext(id, "learner")
        };
    }
}