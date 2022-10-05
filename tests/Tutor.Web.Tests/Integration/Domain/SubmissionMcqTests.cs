using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Collections.Generic;
using Tutor.Web.Mappings.Domain.DTOs.AssessmentItems.MultiChoiceQuestions;
using Xunit;

namespace Tutor.Web.Tests.Integration.Domain
{
    [Collection("Sequential")]
    public class SubmissionMcqTests : BaseWebIntegrationTest
    {
        public SubmissionMcqTests(TutorApplicationTestFactory<Startup> factory) : base(factory) { }

        [Theory]
        [MemberData(nameof(McqSubmissions))]
        public void Submits_multi_choice_questions(McqSubmissionDto submission, McqEvaluationDto expectedEvaluation)
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupAssessmentsController(scope, "-3");

            var actualEvaluation = ((OkObjectResult)controller.SubmitMultiChoiceQuestion(submission).Result).Value as McqEvaluationDto;

            actualEvaluation.ShouldNotBeNull();
            actualEvaluation.CorrectnessLevel.ShouldBe(expectedEvaluation.CorrectnessLevel);
        }

        public static IEnumerable<object[]> McqSubmissions()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new McqSubmissionDto
                    {
                        AssessmentItemId = -10001,
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
                    new McqSubmissionDto
                    {
                        AssessmentItemId = -10001,
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
                    new McqSubmissionDto
                    {
                        AssessmentItemId = -10001,
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
