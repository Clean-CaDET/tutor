using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems.CodeCompletionQuestions;
using Tutor.KnowledgeComponents.Infrastructure.Database;

namespace Tutor.KnowledgeComponents.Tests.Integration.Learning.Assessment;

[Collection("Sequential")]
public class SubmissionCcqTests : BaseAssessmentEvaluationIntegrationTest
{
    public SubmissionCcqTests(KnowledgeComponentsTestFactory factory) : base(factory) { }

    [Theory]
    [MemberData(nameof(CcqSubmissions))]
    public void Submits_short_answer_questions(int assessmentItemId, CcqSubmissionDto submission, CcqEvaluationDto expectedEvaluation)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-4");
        var dbContext = scope.ServiceProvider.GetRequiredService<KnowledgeComponentsContext>();
        dbContext.Database.BeginTransaction();

        var feedback = ((ObjectResult)controller.SubmitAssessmentAnswer(assessmentItemId, submission).Result).Value as FeedbackDto;

        feedback.ShouldNotBeNull();
        feedback.Evaluation.CorrectnessLevel.ShouldBe(expectedEvaluation.CorrectnessLevel);
    }

    public static IEnumerable<object[]> CcqSubmissions()
    {
        return new List<object[]>
        {
            new object[]
            {
                -41,
                new CcqSubmissionDto
                {
                    Items = new []
                    {
                        new CcqItemDto { Order = 1, Answer = "int brKuvara = 1" },
                        new CcqItemDto { Order = 2, Answer = "satnicaKonobara = 300.00" },
                        new CcqItemDto { Order = 3, Answer = "satnicaKonobara = 500.00" }
                    }
                },
                new CcqEvaluationDto
                {
                    CorrectnessLevel = 1
                }
            },
            new object[]
            {
                -41,
                new CcqSubmissionDto
                {
                    Items = new []
                    {
                        new CcqItemDto { Order = 1, Answer = "int brKuvara=1" },
                        new CcqItemDto { Order = 2, Answer = "satnicaKonobara=300.00" },
                        new CcqItemDto { Order = 3, Answer = "satnicaKonobara=500.00" }
                    }
                },
                new CcqEvaluationDto
                {
                    CorrectnessLevel = 0.33
                }
            },
            new object[]
            {
                -41,
                new CcqSubmissionDto
                {
                    Items = new CcqItemDto[]{}
                },
                new CcqEvaluationDto
                {
                    CorrectnessLevel = 0
                }
            },
            new object[]
            {
                -41,
                new CcqSubmissionDto
                {
                    Items = new []
                    {
                        new CcqItemDto { Order = 1, Answer = "int brKuvara=1" }
                    }
                },
                new CcqEvaluationDto
                {
                    CorrectnessLevel = 0
                }
            },
            new object[]
            {
                -41,
                new CcqSubmissionDto
                {
                    Items = new []
                    {
                        new CcqItemDto { Order = 1, Answer = "int brKuvara = 1" }
                    }
                },
                new CcqEvaluationDto
                {
                    CorrectnessLevel = 0.33
                }
            },
            new object[]
            {
                -41,
                new CcqSubmissionDto
                {
                    Items = new []
                    {
                        new CcqItemDto { Order = 1, Answer = "int brKuvara = 1" },
                        new CcqItemDto { Order = 2, Answer = "satnicaKonobara = 300.00" }
                    }
                },
                new CcqEvaluationDto
                {
                    CorrectnessLevel = 0.67
                }
            },
        };
    }
}