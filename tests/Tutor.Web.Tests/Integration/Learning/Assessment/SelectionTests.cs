using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.UseCases.Learning.Assessment;
using Tutor.Web.Controllers.Learners.Learning.Assessment;
using Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems;
using Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems.MultiChoiceQuestions;
using Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems.MultiResponseQuestions;
using Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems.ShortAnswerQuestions;
using Xunit;

namespace Tutor.Web.Tests.Integration.Learning.Assessment;

[Collection("Sequential")]
public class SelectionTests : BaseWebIntegrationTest
{
    public SelectionTests(TutorApplicationTestFactory<Startup> factory) : base(factory)
    {
    }

    [Theory]
    [MemberData(nameof(AssessmentItemRequest))]
    public void Gets_suitable_assessment_event(int knowledgeComponentId, int expectedSuitableAssessmentItemId)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupAssessmentSelectionController(scope, "-2");

        var actualSuitableAssessmentItem =
            ((OkObjectResult) controller.GetSuitableAssessmentItem(knowledgeComponentId).Result)?.Value as AssessmentItemDto;
        actualSuitableAssessmentItem.ShouldNotBeNull();
            
        actualSuitableAssessmentItem.Id.ShouldBe(expectedSuitableAssessmentItemId);
    }

    private SelectionController SetupAssessmentSelectionController(IServiceScope scope, string id)
    {
        return new SelectionController(Factory.Services.GetRequiredService<IMapper>(),
            scope.ServiceProvider.GetRequiredService<ISelectionService>())
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
        var controller = SetupAssessmentSelectionController(scope, "-2");

        var item = ((OkObjectResult)controller.GetSuitableAssessmentItem(-15).Result)?.Value as MrqDto;
        
        item.ShouldNotBeNull();
        item.Id.ShouldBe(-153);
        item.Items.All(i => i.Feedback.Equals(string.Empty)).ShouldBeTrue();
    }

    [Fact]
    public void Verifies_Saq_has_no_feedback()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupAssessmentSelectionController(scope, "-3");

        var response = controller.GetSuitableAssessmentItem(-21).Result;
        
        var item = ((OkObjectResult)response)?.Value as SaqDto;
        item.ShouldNotBeNull();
        item.Id.ShouldBe(-212);
        item.AcceptableAnswers.ShouldBeEmpty();
    }
}