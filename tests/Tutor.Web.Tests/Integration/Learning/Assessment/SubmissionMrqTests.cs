using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Collections.Generic;
using Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems.MultiResponseQuestions;
using Xunit;

namespace Tutor.Web.Tests.Integration.Learning.Assessment
{
    [Collection("Sequential")]
    public class SubmissionMrqTests : BaseAssessmentEvaluationIntegrationTest
    {
        public SubmissionMrqTests(TutorApplicationTestFactory<Startup> factory) : base(factory) { }

        [Theory]
        [MemberData(nameof(MrqSubmissions))]
        public void Submits_multiple_response_questions(int assessmentItemId, MrqSubmissionDto submission, MrqEvaluationDto expectedEvaluation)
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupAssessmentEvaluationController(scope, "-3");

            var actualEvaluation = ((ObjectResult)controller.SubmitAssessmentAnswer(assessmentItemId, submission).Result).Value as MrqEvaluationDto;

            actualEvaluation.ShouldNotBeNull();
            actualEvaluation.ItemEvaluations.Count.ShouldBe(expectedEvaluation.ItemEvaluations.Count);
            foreach (var actualItem in actualEvaluation.ItemEvaluations)
            {
                var relatedItem = expectedEvaluation.ItemEvaluations.Find(i => i.Id == actualItem.Id);
                relatedItem.ShouldNotBeNull();
                relatedItem.SubmissionWasCorrect.ShouldBe(actualItem.SubmissionWasCorrect);
            }
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
                            new() {Id = -1531},
                            new() {Id = -1532},
                            new() {Id = -1533},
                            new() {Id = -1534},
                            new() {Id = -1535}
                        }
                    },
                    new MrqEvaluationDto
                    {
                        ItemEvaluations = new List<MrqItemEvaluationDto>
                        {
                            new() {Id = -1531, SubmissionWasCorrect = false},
                            new() {Id = -1532, SubmissionWasCorrect = true},
                            new() {Id = -1533, SubmissionWasCorrect = false},
                            new() {Id = -1534, SubmissionWasCorrect = false},
                            new() {Id = -1535, SubmissionWasCorrect = true}
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
                            new() {Id = -1532},
                            new() {Id = -1535}
                        }
                    },
                    new MrqEvaluationDto
                    {
                        ItemEvaluations = new List<MrqItemEvaluationDto>
                        {
                            new() {Id = -1531, SubmissionWasCorrect = true},
                            new() {Id = -1532, SubmissionWasCorrect = true},
                            new() {Id = -1533, SubmissionWasCorrect = true},
                            new() {Id = -1534, SubmissionWasCorrect = true},
                            new() {Id = -1535, SubmissionWasCorrect = true}
                        }
                    }
                },
                new object[]
                { 
                    -153,
                    new MrqSubmissionDto(),
                    new MrqEvaluationDto
                    {
                        ItemEvaluations = new List<MrqItemEvaluationDto>
                        {
                            new() {Id = -1531, SubmissionWasCorrect = true},
                            new() {Id = -1532, SubmissionWasCorrect = false},
                            new() {Id = -1533, SubmissionWasCorrect = true},
                            new() {Id = -1534, SubmissionWasCorrect = true},
                            new() {Id = -1535, SubmissionWasCorrect = false}
                        }
                    }
                }
            };
        }
    }
}
