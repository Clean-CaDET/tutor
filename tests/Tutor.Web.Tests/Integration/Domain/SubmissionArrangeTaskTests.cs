using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Collections.Generic;
using Tutor.Core.DomainModel.AssessmentEvents;
using Tutor.Web.Controllers.Domain;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents.ArrangeTask;
using Xunit;

namespace Tutor.Web.Tests.Integration.Domain
{
    public class SubmissionArrangeTaskTests : BaseIntegrationTest
    {
        public SubmissionArrangeTaskTests(TutorApplicationTestFactory<Startup> factory) : base(factory) {}

        [Theory]
        [MemberData(nameof(ATSubmissions))]
        public void Submits_multiple_response_questions(ArrangeTaskSubmissionDTO submission, ArrangeTaskEvaluationDTO expectedEvaluation)
        {
            using var scope = Factory.Services.CreateScope();
            var controller = new SubmissionController(Factory.Services.GetRequiredService<IMapper>(),
                scope.ServiceProvider.GetRequiredService<ISubmissionService>());

            var actualEvaluation = ((OkObjectResult)controller.SubmitArrangeTask(submission).Result).Value as ArrangeTaskEvaluationDTO;

            actualEvaluation.ShouldNotBeNull();
            actualEvaluation.ContainerEvaluations.Count.ShouldBe(expectedEvaluation.ContainerEvaluations.Count);
            foreach (var actualContainer in actualEvaluation.ContainerEvaluations)
            {
                var relatedContainer = expectedEvaluation.ContainerEvaluations.Find(i => i.Id == actualContainer.Id);
                relatedContainer.ShouldNotBeNull();
                relatedContainer.SubmissionWasCorrect.ShouldBe(actualContainer.SubmissionWasCorrect);
            }
        }

        public static IEnumerable<object[]> ATSubmissions()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new ArrangeTaskSubmissionDTO
                    {
                        AssessmentEventId = -2111,
                        Containers= new List<ArrangeTaskContainerSubmissionDTO>
                        {
                            new() {Id = -1, ElementIds = new List<int> {-1, -2, -3}},
                            new() {Id = -2},
                            new() {Id = -3},
                            new() {Id = -4, ElementIds = new List<int> {-4}},
                            new() {Id = -5, ElementIds = new List<int> {-5}}
                        }
                    },
                    new ArrangeTaskEvaluationDTO
                    {
                        ContainerEvaluations = new List<ArrangeTaskContainerEvaluationDTO>
                        {
                            new() {Id = -1, SubmissionWasCorrect = false},
                            new() {Id = -2, SubmissionWasCorrect = false},
                            new() {Id = -3, SubmissionWasCorrect = false},
                            new() {Id = -4, SubmissionWasCorrect = true},
                            new() {Id = -5, SubmissionWasCorrect = true}
                        }
                    }
                },
                new object[]
                {
                    new ArrangeTaskSubmissionDTO
                    {
                        AssessmentEventId = -2111,
                        Containers= new List<ArrangeTaskContainerSubmissionDTO>
                        {
                            new() {Id = -1, ElementIds = new List<int> {-1}},
                            new() {Id = -2, ElementIds = new List<int> {-2}},
                            new() {Id = -3, ElementIds = new List<int> {-3}},
                            new() {Id = -4, ElementIds = new List<int> {-4}},
                            new() {Id = -5, ElementIds = new List<int> {-5}}
                        }
                    },
                    new ArrangeTaskEvaluationDTO
                    {
                        ContainerEvaluations = new List<ArrangeTaskContainerEvaluationDTO>
                        {
                            new() {Id = -1, SubmissionWasCorrect = true},
                            new() {Id = -2, SubmissionWasCorrect = true},
                            new() {Id = -3, SubmissionWasCorrect = true},
                            new() {Id = -4, SubmissionWasCorrect = true},
                            new() {Id = -5, SubmissionWasCorrect = true}
                        }
                    }
                },
                new object[]
                {
                    new ArrangeTaskSubmissionDTO
                    {
                        AssessmentEventId = -2111,
                        Containers= new List<ArrangeTaskContainerSubmissionDTO>
                        {
                            new() {Id = -1, ElementIds = new List<int> {-1, -2, -3, -4, -5}},
                            new() {Id = -2},
                            new() {Id = -3},
                            new() {Id = -4},
                            new() {Id = -5}
                        }
                    },
                    new ArrangeTaskEvaluationDTO
                    {
                        ContainerEvaluations = new List<ArrangeTaskContainerEvaluationDTO>
                        {
                            new() {Id = -1, SubmissionWasCorrect = false},
                            new() {Id = -2, SubmissionWasCorrect = false},
                            new() {Id = -3, SubmissionWasCorrect = false},
                            new() {Id = -4, SubmissionWasCorrect = false},
                            new() {Id = -5, SubmissionWasCorrect = false}
                        }
                    }
                },
                new object[]
                {
                    new ArrangeTaskSubmissionDTO
                    {
                        AssessmentEventId = -2111,
                        Containers= new List<ArrangeTaskContainerSubmissionDTO>
                        {
                            new() {Id = -1},
                            new() {Id = -2},
                            new() {Id = -3},
                            new() {Id = -4},
                            new() {Id = -5}
                        }
                    },
                    new ArrangeTaskEvaluationDTO
                    {
                        ContainerEvaluations = new List<ArrangeTaskContainerEvaluationDTO>
                        {
                            new() {Id = -1, SubmissionWasCorrect = false},
                            new() {Id = -2, SubmissionWasCorrect = false},
                            new() {Id = -3, SubmissionWasCorrect = false},
                            new() {Id = -4, SubmissionWasCorrect = false},
                            new() {Id = -5, SubmissionWasCorrect = false}
                        }
                    }
                }
            };
        }
    }
}
