using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Collections.Generic;
using Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems.ShortAnswerQuestions;
using Xunit;

namespace Tutor.Web.Tests.Integration.Learning.Assessment;

[Collection("Sequential")]
public class SubmissionSaqTests : BaseAssessmentEvaluationIntegrationTest
{
    public SubmissionSaqTests(TutorApplicationTestFactory<Startup> factory) : base(factory) { }

    [Theory]
    [MemberData(nameof(SaqSubmissions))]
    public void Submits_short_answer_questions(int assessmentItemId, SaqSubmissionDto submission, SaqEvaluationDto expectedEvaluation)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupAssessmentEvaluationController(scope, "-3");

        var actualEvaluation = ((ObjectResult)controller.SubmitAssessmentAnswer(assessmentItemId, submission).Result).Value as SaqEvaluationDto;

        actualEvaluation.ShouldNotBeNull();
        actualEvaluation.CorrectnessLevel.ShouldBe(expectedEvaluation.CorrectnessLevel);
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
            }
        };
    }
}