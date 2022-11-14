using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Collections.Generic;
using Tutor.Web.Mappings.Domain.DTOs.AssessmentItems.ShortAnswerQuestions;
using Xunit;

namespace Tutor.Web.Tests.Integration.Domain
{
    [Collection("Sequential")]
    public class SubmissionSaqTests : BaseWebIntegrationTest
    {
        public SubmissionSaqTests(TutorApplicationTestFactory<Startup> factory) : base(factory) { }

        [Theory]
        [MemberData(nameof(SaqSubmissions))]
        public void Submits_short_answer_questions(SaqSubmissionDto submission, SaqEvaluationDto expectedEvaluation)
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupAssessmentEvaluationController(scope, "-3");

            var actualEvaluation = ((OkObjectResult)controller.SubmitShortAnswerQuestion(submission).Result).Value as SaqEvaluationDto;

            actualEvaluation.ShouldNotBeNull();
            actualEvaluation.CorrectnessLevel.ShouldBe(expectedEvaluation.CorrectnessLevel);
        }

        public static IEnumerable<object[]> SaqSubmissions()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new SaqSubmissionDto
                    {
                        AssessmentItemId = -212,
                        Answer = "Words, word_parts, idx, abc"
                    },
                    new SaqEvaluationDto
                    {
                        CorrectnessLevel = 1
                    }
                },
                new object[]
                {
                    new SaqSubmissionDto
                    {
                        AssessmentItemId = -212,
                        Answer = "Words, word_parts, idx"
                    },
                    new SaqEvaluationDto
                    {
                        CorrectnessLevel = 0.75
                    }
                },
                new object[]
                {
                    new SaqSubmissionDto
                    {
                        AssessmentItemId = -212,
                        Answer = "Words, word_parts, idx, abc, cba"
                    },
                    new SaqEvaluationDto
                    {
                        CorrectnessLevel = 0.8
                    }
                },
                new object[]
                {
                    new SaqSubmissionDto
                    {
                        AssessmentItemId = -212,
                        Answer = ""
                    },
                    new SaqEvaluationDto
                    {
                        CorrectnessLevel = 0
                    }
                },
                new object[]
                {
                    new SaqSubmissionDto
                    {
                        AssessmentItemId = -212,
                        Answer = "cba"
                    },
                    new SaqEvaluationDto
                    {
                        CorrectnessLevel = 0
                    }
                },
                new object[]
                {
                    new SaqSubmissionDto
                    {
                        AssessmentItemId = -212,
                        Answer = "abc, cba"
                    },
                    new SaqEvaluationDto
                    {
                        CorrectnessLevel = 0.25
                    }
                },
                new object[]
                {
                    new SaqSubmissionDto
                    {
                        AssessmentItemId = -995,
                        Answer = "MedicalRecordService"
                    },
                    new SaqEvaluationDto
                    {
                        CorrectnessLevel = 0.5
                    }
                },
                new object[]
                {
                    new SaqSubmissionDto
                    {
                        AssessmentItemId = -995
                    },
                    new SaqEvaluationDto
                    {
                        CorrectnessLevel = 0
                    }
                },
                new object[]
                {
                    new SaqSubmissionDto
                    {
                        AssessmentItemId = -995,
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
}
