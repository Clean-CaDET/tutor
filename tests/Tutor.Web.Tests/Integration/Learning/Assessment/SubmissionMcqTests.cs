using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Collections.Generic;
using Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems.MultiChoiceQuestions;
using Xunit;

namespace Tutor.Web.Tests.Integration.Learning.Assessment
{
    [Collection("Sequential")]
    public class SubmissionMcqTests : BaseAssessmentEvaluationIntegrationTest
    {
        public SubmissionMcqTests(TutorApplicationTestFactory<Startup> factory) : base(factory) { }

        [Theory]
        [MemberData(nameof(McqSubmissions))]
        public void Submits_multi_choice_questions(int assessmentItemId, McqSubmissionDto submission, McqEvaluationDto expectedEvaluation)
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupAssessmentEvaluationController(scope, "-3");

            var actualEvaluation = ((ObjectResult)controller.SubmitAssessmentAnswer(assessmentItemId, submission).Result).Value
                as McqEvaluationDto;

            actualEvaluation.ShouldNotBeNull();
            actualEvaluation.CorrectnessLevel.ShouldBe(expectedEvaluation.CorrectnessLevel);
        }

        public static IEnumerable<object[]> McqSubmissions()
        {
            return new List<object[]>
            {
                new object[]
                {
                    -10001,
                    new McqSubmissionDto
                    {
                        Answer = "3"
                    },
                    new McqEvaluationDto
                    {
                        CorrectnessLevel = 0,
                        Feedback = "Feedback"
                    }
                },
                new object[]
                {
                    -10001,
                    new McqSubmissionDto
                    {
                        Answer = "4"
                    },
                    new McqEvaluationDto
                    {
                        CorrectnessLevel = 0,
                        Feedback = "Feedback"
                    }
                },
                new object[]
                {
                    -10001,
                    new McqSubmissionDto
                    {
                        Answer = "5"
                    },
                    new McqEvaluationDto
                    {
                        CorrectnessLevel = 1,
                        Feedback = "Feedback"
                    }
                }
            };
        }
    }
}
