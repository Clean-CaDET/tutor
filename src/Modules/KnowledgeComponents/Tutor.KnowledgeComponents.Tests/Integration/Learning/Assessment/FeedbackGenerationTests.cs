using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems.MultiResponseQuestions;
using Tutor.KnowledgeComponents.Infrastructure.Database;
using Xunit;

namespace Tutor.KnowledgeComponents.Tests.Integration.Learning.Assessment;

[Collection("Sequential")]
public class FeedbackGenerationTests : BaseAssessmentEvaluationIntegrationTest
{
    public FeedbackGenerationTests(KnowledgeComponentsTestFactory factory) : base(factory) {}

    [Theory]
    [MemberData(nameof(MrqSubmissions))]
    public void Generates_suitable_feedback(string learnerId, int itemId, SubmissionDto submission, FeedbackDto expectedFeedback)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, learnerId);
        var dbContext = scope.ServiceProvider.GetRequiredService<KnowledgeComponentsContext>();
        dbContext.Database.BeginTransaction();

        var actualFeedback = ((ObjectResult)controller.SubmitAssessmentAnswer(itemId, submission).Result).Value as FeedbackDto;

        actualFeedback.ShouldNotBeNull();
        actualFeedback.Type.ShouldBe(expectedFeedback.Type);
        actualFeedback.Evaluation.CorrectnessLevel.ShouldBe(expectedFeedback.Evaluation.CorrectnessLevel);
        actualFeedback.Hint.ShouldBe(expectedFeedback.Hint);
    }

    // Learner -2
    // AIM -153 (1 hint), correct answers = -1532, -1535
    // Sub count 1, Hint count 1
    // AIM -155 (3 hints) correct answers = 1552, -1555
    // Sub count 2, Hint count 2

    // Learner -3
    // AIM -153 (1 hint)
    // Sub count 0, hint count 0
    // AIM -155 (3 hints)
    // Sub count 0, hint count 0
    public static IEnumerable<object[]> MrqSubmissions()
    {
        return new List<object[]>
        {
            new object[]
            {
                "-3",
                -153,
                new MrqSubmissionDto
                {
                    ReattemptCount = 0,
                    Answers = new List<MrqItemDto>
                    {
                        new() {Text = "-1531"},
                        new() {Text = "-1532"},
                        new() {Text = "-1533"},
                        new() {Text = "-1534"},
                        new() {Text = "-1535"}
                    }
                },
                new FeedbackDto
                {
                    Type = "Pump",
                    Evaluation = new MrqEvaluationDto
                    {
                        CorrectnessLevel = 0.4
                    }
                }
            },
            new object[]
            {
                "-3",
                -153,
                new MrqSubmissionDto
                {
                    ReattemptCount = 2,
                    Answers = new List<MrqItemDto>
                    {
                        new() {Text = "-1531"},
                        new() {Text = "-1532"},
                        new() {Text = "-1533"},
                        new() {Text = "-1534"},
                        new() {Text = "-1535"}
                    }
                },
                new FeedbackDto
                {
                    Type = "Correctness",
                    Evaluation = new MrqEvaluationDto
                    {
                        CorrectnessLevel = 0.4
                    }
                }
            },
            new object[]
            {
                "-3",
                -155,
                new MrqSubmissionDto
                {
                    ReattemptCount = 0,
                    Answers = new List<MrqItemDto>
                    {
                        new() {Text = "-1552"},
                        new() {Text = "-1555"}
                    }
                },
                new FeedbackDto
                {
                    Type = "Solution",
                    Evaluation = new MrqEvaluationDto
                    {
                        CorrectnessLevel = 1
                    }
                }
            },
            new object[]
            {
                "-2",
                -153,
                new MrqSubmissionDto
                {
                    ReattemptCount = 1,
                    Answers = new List<MrqItemDto>
                    {
                        new() {Text = "-1533"},
                        new() {Text = "-1535"}
                    }
                },
                new FeedbackDto
                {
                    Type = "Solution",
                    Evaluation = new MrqEvaluationDto
                    {
                        CorrectnessLevel = 0.6
                    }
                }
            },
            new object[]
            {
                "-2",
                -155,
                new MrqSubmissionDto(),
                new FeedbackDto
                {
                    Type = "Hint",
                    Evaluation = new MrqEvaluationDto
                    {
                        CorrectnessLevel = 0.6
                    },
                    Hint = "Hint 3"
                }
            },
            new object[]
            {
                "-2",
                -153,
                new MrqSubmissionDto
                {
                    ReattemptCount = 1,
                },
                new FeedbackDto
                {
                    Type = "Solution",
                    Evaluation = new MrqEvaluationDto
                    {
                        CorrectnessLevel = 0.6
                    }
                }
            }
        };
    }
}