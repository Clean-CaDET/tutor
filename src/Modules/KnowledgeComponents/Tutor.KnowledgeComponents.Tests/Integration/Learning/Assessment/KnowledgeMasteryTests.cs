using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems.MultiResponseQuestions;
using Tutor.KnowledgeComponents.Infrastructure.Database;

namespace Tutor.KnowledgeComponents.Tests.Integration.Learning.Assessment;

[Collection("Sequential")]
public class KnowledgeMasteryTests : BaseAssessmentEvaluationIntegrationTest
{
    public KnowledgeMasteryTests(KnowledgeComponentsTestFactory factory) : base(factory) {}

    [Theory]
    [MemberData(nameof(MrqSubmission))]
    public void Updates_Kc_Mastery(int learnerId, int assessmentItemId, MrqSubmissionDto submission, double expectedKcMastery)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, learnerId.ToString());
        var dbContext = scope.ServiceProvider.GetRequiredService<KnowledgeComponentsContext>();
        var assessmentItem = dbContext.AssessmentItems.FirstOrDefault(ae => ae.Id == assessmentItemId);
        var knowledgeComponent =
            dbContext.KnowledgeComponents.FirstOrDefault(kc => kc.Id == assessmentItem.KnowledgeComponentId);

        controller.SubmitAssessmentAnswer(assessmentItemId, submission);

        dbContext.ChangeTracker.Clear();
        var actualKcMastery = dbContext.KcMasteries.FirstOrDefault(kcm => kcm.LearnerId == learnerId
                                                                          && kcm.KnowledgeComponentId == knowledgeComponent.Id);
        actualKcMastery.Mastery.ShouldBe(expectedKcMastery);
    }

    public static IEnumerable<object[]> MrqSubmission()
    {
        return new List<object[]>
        {
            new object[]
            {
                -3,
                -106,
                new MrqSubmissionDto
                {
                    Answers = new List<MrqItemDto>
                    {
                        new() {Text = "-1062"},
                        new() {Text = "-1065"}
                    }
                },
                0.5
            },
            new object[]
            {
                -3,
                -106,
                new MrqSubmissionDto
                {
                    Answers = new List<MrqItemDto>
                    {
                        new() {Text = "-1061"},
                        new() {Text = "-1065"}
                    }
                },
                0.5
            },
            new object[]
            {
                -3,
                -107,
                new MrqSubmissionDto
                {
                    Answers = new List<MrqItemDto>
                    {
                        new() {Text = "-1071"},
                        new() {Text = "-1073"},
                        new() {Text = "-1074"}
                    }
                },
                0.5
            },
            new object[]
            {
                -3,
                -107,
                new MrqSubmissionDto
                {
                    Answers = new List<MrqItemDto>
                    {
                        new() {Text = "-1072"},
                        new() {Text = "-1074"}
                    }
                },
                0.8
            },
            new object[]
            {
                -3,
                -107,
                new MrqSubmissionDto
                {
                    Answers = new List<MrqItemDto>
                    {
                        new() {Text = "-1072"},
                        new() {Text = "-1075"}
                    }
                },
                1.0
            },
            new object[]
            {
                -2,
                -106,
                new MrqSubmissionDto
                {
                    Answers = new List<MrqItemDto>
                    {
                        new() {Text = "-1062"},
                        new() {Text = "-1065"}
                    }
                },
                0.5
            },
            new object[]
            {
                -2,
                -106,
                new MrqSubmissionDto
                {
                    Answers = new List<MrqItemDto>
                    {
                        new() {Text = "-1061"},
                        new() {Text = "-1065"}
                    }
                },
                0.5
            },
            new object[]
            {
                -2,
                -107,
                new MrqSubmissionDto
                {
                    Answers = new List<MrqItemDto>
                    {
                        new() {Text = "-1071"},
                        new() {Text = "-1073"},
                        new() {Text = "-1074"}
                    }
                },
                0.5
            },
            new object[]
            {
                -2,
                -107,
                new MrqSubmissionDto
                {
                    Answers = new List<MrqItemDto>
                    {
                        new() {Text = "-1072"},
                        new() {Text = "-1074"}
                    }
                },
                0.8
            },
            new object[]
            {
                -2,
                -107,
                new MrqSubmissionDto
                {
                    Answers = new List<MrqItemDto>
                    {
                        new() {Text = "-1072"},
                        new() {Text = "-1075"}
                    }
                },
                1.0
            }
        };
    }
}