using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems.ShortAnswerQuestions;
using Tutor.KnowledgeComponents.Infrastructure.Database;

namespace Tutor.KnowledgeComponents.Tests.Integration.Learning.Assessment;

[Collection("Sequential")]
public class SubmissionSaqTests : BaseAssessmentEvaluationIntegrationTest
{
    public SubmissionSaqTests(KnowledgeComponentsTestFactory factory) : base(factory) { }

    [Theory]
    [MemberData(nameof(SaqSubmissions))]
    public void Submits_short_answer_questions(int assessmentItemId, SaqSubmissionDto submission, SaqEvaluationDto expectedEvaluation)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-3");
        var dbContext = scope.ServiceProvider.GetRequiredService<KnowledgeComponentsContext>();
        dbContext.Database.BeginTransaction();

        var feedback = ((ObjectResult)controller.SubmitAssessmentAnswer(assessmentItemId, submission).Result).Value as FeedbackDto;

        feedback.ShouldNotBeNull();
        feedback.Evaluation.CorrectnessLevel.ShouldBe(expectedEvaluation.CorrectnessLevel);
        VerifyEventGenerated(dbContext, "AssessmentItemAnswered");
    }

    public static IEnumerable<object[]> SaqSubmissions()
    {
        return new List<object[]>
        {
            new object[]
            {
                -212,
                new SaqSubmissionDto
                {
                    Answer = "Words, word_parts, idx, abc"
                },
                new SaqEvaluationDto
                {
                    CorrectnessLevel = 1
                }
            },
            new object[]
            {
                -212,
                new SaqSubmissionDto
                {
                    Answer = "Words, word_parts, idx"
                },
                new SaqEvaluationDto
                {
                    CorrectnessLevel = 0.75
                }
            },
            new object[]
            {
                -212,
                new SaqSubmissionDto
                {
                    Answer = "Words, word_parts, idx, abc, cba"
                },
                new SaqEvaluationDto
                {
                    CorrectnessLevel = 0.8
                }
            },
            new object[]
            {
                -212,
                new SaqSubmissionDto
                {
                    Answer = ""
                },
                new SaqEvaluationDto
                {
                    CorrectnessLevel = 0
                }
            },
            new object[]
            {
                -212,
                new SaqSubmissionDto
                {
                    Answer = "cba"
                },
                new SaqEvaluationDto
                {
                    CorrectnessLevel = 0
                }
            },
            new object[]
            {
                -212,
                new SaqSubmissionDto
                {
                    Answer = "abc, cba"
                },
                new SaqEvaluationDto
                {
                    CorrectnessLevel = 0.25
                }
            },
            new object[]
            {
                -995,
                new SaqSubmissionDto
                {
                    Answer = "MedicalRecordService"
                },
                new SaqEvaluationDto
                {
                    CorrectnessLevel = 0.5
                }
            },
            new object[]
            { 
                -995,
                new SaqSubmissionDto(),
                new SaqEvaluationDto
                {
                    CorrectnessLevel = 0
                }
            },
            new object[]
            {
                -995,
                new SaqSubmissionDto
                {
                    Answer = " "
                },
                new SaqEvaluationDto
                {
                    CorrectnessLevel = 0
                }
            },
            new object[]
            {
                -213,
                new SaqSubmissionDto
                {
                    Answer = "odgovor"
                },
                new SaqEvaluationDto
                {
                    CorrectnessLevel = 1
                }
            },
            new object[]
            {
                -213,
                new SaqSubmissionDto
                {
                    Answer = "Odgovor"
                },
                new SaqEvaluationDto
                {
                    CorrectnessLevel = 1
                }
            },
            new object[]
            {
                -213,
                new SaqSubmissionDto
                {
                    Answer = "Odgovor."
                },
                new SaqEvaluationDto
                {
                    CorrectnessLevel = 1
                }
            },
            new object[]
            {
                -213,
                new SaqSubmissionDto
                {
                    Answer = "odfivor"
                },
                new SaqEvaluationDto
                {
                    CorrectnessLevel = 1
                }
            },
            new object[]
            {
                -213,
                new SaqSubmissionDto
                {
                    Answer = "ODGOVOR"
                },
                new SaqEvaluationDto
                {
                    CorrectnessLevel = 0
                }
            },
            new object[]
            {
                -214,
                new SaqSubmissionDto
                {
                    Answer = "prva,druga,treca,cetvrta"
                },
                new SaqEvaluationDto
                {
                    CorrectnessLevel = 1
                }
            },
            new object[]
            {
                -214,
                new SaqSubmissionDto
                {
                    Answer = "prvaa,druuga,ttreca,cetvrrta"
                },
                new SaqEvaluationDto
                {
                    CorrectnessLevel = 1
                }
            },
            new object[]
            {
                -214,
                new SaqSubmissionDto
                {
                    Answer = "PRva,DRugi,treci,cetvrta"
                },
                new SaqEvaluationDto
                {
                    CorrectnessLevel = 0.5
                }
            }
        };
    }
}