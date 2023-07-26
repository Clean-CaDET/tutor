using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems.MultiResponseQuestions;
using Tutor.KnowledgeComponents.Infrastructure.Database;
using Xunit;

namespace Tutor.KnowledgeComponents.Tests.Integration.Learning.Assessment;

[Collection("Sequential")]
public class SubmissionMrqTests : BaseAssessmentEvaluationIntegrationTest
{
    public SubmissionMrqTests(KnowledgeComponentsTestFactory factory) : base(factory) { }

    [Theory]
    [MemberData(nameof(MrqSubmissions))]
    public void Submits_multiple_response_questions(int assessmentItemId, MrqSubmissionDto submission, MrqEvaluationDto expectedEvaluation)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-3");
        var dbContext = scope.ServiceProvider.GetRequiredService<KnowledgeComponentsContext>();
        dbContext.Database.BeginTransaction();

        var actualEvaluation = ((ObjectResult)controller.SubmitAssessmentAnswer(assessmentItemId, submission).Result).Value as FeedbackDto;

        actualEvaluation.ShouldNotBeNull();
        actualEvaluation.Evaluation.CorrectnessLevel.ShouldBe(expectedEvaluation.CorrectnessLevel);
    }

    public static IEnumerable<object[]> MrqSubmissions()
    {
        return new List<object[]>
        {
            new object[]
            {
                -153,
                new MrqSubmissionDto
                {
                    Answers = new List<MrqItemDto>
                    {
                        new() {Text = "-1531"},
                        new() {Text = "-1532"},
                        new() {Text = "-1533"},
                        new() {Text = "-1534"},
                        new() {Text = "-1535"}
                    }
                },
                new MrqEvaluationDto
                {
                    CorrectnessLevel = 0.4,
                    ItemEvaluations = new List<MrqItemEvaluationDto>
                    {
                        new() {Text = "-1531", SubmissionWasCorrect = false},
                        new() {Text = "-1532", SubmissionWasCorrect = true},
                        new() {Text = "-1533", SubmissionWasCorrect = false},
                        new() {Text = "-1534", SubmissionWasCorrect = false},
                        new() {Text = "-1535", SubmissionWasCorrect = true}
                    }
                }
            },
            new object[]
            {
                -153,
                new MrqSubmissionDto
                {
                    Answers = new List<MrqItemDto>
                    {
                        new() {Text = "-1532"},
                        new() {Text = "-1535"}
                    }
                },
                new MrqEvaluationDto
                {
                    CorrectnessLevel = 1,
                    ItemEvaluations = new List<MrqItemEvaluationDto>
                    {
                        new() {Text = "-1531", SubmissionWasCorrect = true},
                        new() {Text = "-1532", SubmissionWasCorrect = true},
                        new() {Text = "-1533", SubmissionWasCorrect = true},
                        new() {Text = "-1534", SubmissionWasCorrect = true},
                        new() {Text = "-1535", SubmissionWasCorrect = true}
                    }
                }
            },
            new object[]
            { 
                -153,
                new MrqSubmissionDto(),
                new MrqEvaluationDto
                {
                    CorrectnessLevel = 0.6,
                    ItemEvaluations = new List<MrqItemEvaluationDto>
                    {
                        new() {Text = "-1531", SubmissionWasCorrect = true},
                        new() {Text = "-1532", SubmissionWasCorrect = false},
                        new() {Text = "-1533", SubmissionWasCorrect = true},
                        new() {Text = "-1534", SubmissionWasCorrect = true},
                        new() {Text = "-1535", SubmissionWasCorrect = false}
                    }
                }
            }
        };
    }
}