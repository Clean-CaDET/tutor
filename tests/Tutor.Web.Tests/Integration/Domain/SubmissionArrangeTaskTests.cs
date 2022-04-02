using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Collections.Generic;
using Tutor.Core.DomainModel.AssessmentEvents;
using Tutor.Web.Controllers.Domain;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents.ArrangeTasks;
using Xunit;

namespace Tutor.Web.Tests.Integration.Domain
{
    [Collection("Sequential")]
    public class SubmissionArrangeTaskTests : BaseIntegrationTest
    {
        public SubmissionArrangeTaskTests(TutorApplicationTestFactory<Startup> factory) : base(factory) {}

        [Theory]
        [MemberData(nameof(AtSubmissions))]
        public void Submits_arrange_task(AtSubmissionDto submission, AtEvaluationDto expectedEvaluation)
        {
            using var scope = Factory.Services.CreateScope();
            var controller = new SubmissionController(Factory.Services.GetRequiredService<IMapper>(), scope.ServiceProvider.GetRequiredService<ISubmissionService>());

            var actualEvaluation = ((OkObjectResult)controller.SubmitArrangeTask(submission).Result).Value as AtEvaluationDto;

            actualEvaluation.ShouldNotBeNull();
            actualEvaluation.CorrectnessLevel.ShouldBe(expectedEvaluation.CorrectnessLevel);
            actualEvaluation.ContainerEvaluations.Count.ShouldBe(expectedEvaluation.ContainerEvaluations.Count);
        }

        [Theory]
        [MemberData(nameof(InvalidAtSubmissions))]
        public void Submits_invalid_arrange_task(AtSubmissionDto submission)
        {
            using var scope = Factory.Services.CreateScope();
            var controller = new SubmissionController(Factory.Services.GetRequiredService<IMapper>(), scope.ServiceProvider.GetRequiredService<ISubmissionService>());

            var actualEvaluation = ((BadRequestObjectResult)controller.SubmitArrangeTask(submission).Result).Value;

            actualEvaluation.ShouldNotBeNull();
        }

        public static IEnumerable<object[]> AtSubmissions()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new AtSubmissionDto
                    {
                        AssessmentEventId = -2111,
                        LearnerId = -1,
                        Containers= new List<AtContainerSubmissionDto>
                        {
                            new() {ArrangeTaskContainerId = -1, ElementIds = new List<int> {-1, -2, -3}},
                            new() {ArrangeTaskContainerId = -2},
                            new() {ArrangeTaskContainerId = -3},
                            new() {ArrangeTaskContainerId = -4, ElementIds = new List<int> {-4}},
                            new() {ArrangeTaskContainerId = -5, ElementIds = new List<int> {-5}}
                        }
                    },
                    new AtEvaluationDto
                    {
                        CorrectnessLevel = 0.6,
                        ContainerEvaluations = new List<AtContainerEvaluationDto>
                        {
                            new() {Id = -1},
                            new() {Id = -2},
                            new() {Id = -3},
                            new() {Id = -4},
                            new() {Id = -5}
                        }
                    }
                },
                new object[]
                {
                    new AtSubmissionDto
                    {
                        AssessmentEventId = -2111,
                        LearnerId = -1,
                        Containers= new List<AtContainerSubmissionDto>
                        {
                            new() {ArrangeTaskContainerId = -1, ElementIds = new List<int> {-1}},
                            new() {ArrangeTaskContainerId = -2, ElementIds = new List<int> {-2}},
                            new() {ArrangeTaskContainerId = -3, ElementIds = new List<int> {-3}},
                            new() {ArrangeTaskContainerId = -4, ElementIds = new List<int> {-4}},
                            new() {ArrangeTaskContainerId = -5, ElementIds = new List<int> {-5}}
                        }
                    },
                    new AtEvaluationDto
                    {
                        CorrectnessLevel = 1,
                        ContainerEvaluations = new List<AtContainerEvaluationDto>
                        {
                            new() {Id = -1},
                            new() {Id = -2},
                            new() {Id = -3},
                            new() {Id = -4},
                            new() {Id = -5}
                        }
                    }
                },
                new object[]
                {
                    new AtSubmissionDto
                    {
                        AssessmentEventId = -2111,
                        LearnerId = -1,
                        Containers= new List<AtContainerSubmissionDto>
                        {
                            new() {ArrangeTaskContainerId = -1, ElementIds = new List<int> {-1, -2, -3, -4, -5}},
                            new() {ArrangeTaskContainerId = -2},
                            new() {ArrangeTaskContainerId = -3},
                            new() {ArrangeTaskContainerId = -4},
                            new() {ArrangeTaskContainerId = -5}
                        }
                    },
                    new AtEvaluationDto
                    {
                        CorrectnessLevel = 0.2,
                        ContainerEvaluations = new List<AtContainerEvaluationDto>
                        {
                            new() {Id = -1},
                            new() {Id = -2},
                            new() {Id = -3},
                            new() {Id = -4},
                            new() {Id = -5}
                        }
                    }
                }
            };
        }

        public static IEnumerable<object[]> InvalidAtSubmissions()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new AtSubmissionDto
                    {
                        AssessmentEventId = -2111,
                        LearnerId = -1,
                        Containers= new List<AtContainerSubmissionDto>
                        {
                            new() {ArrangeTaskContainerId = -1},
                            new() {ArrangeTaskContainerId = -2},
                            new() {ArrangeTaskContainerId = -3},
                            new() {ArrangeTaskContainerId = -4},
                            new() {ArrangeTaskContainerId = -5}
                        }
                    }
                },
                new object[]
                {
                    new AtSubmissionDto
                    {
                        AssessmentEventId = -2111,
                        LearnerId = -1,
                        Containers= new List<AtContainerSubmissionDto>
                        {
                            new() {ArrangeTaskContainerId = -1},
                            new() {ArrangeTaskContainerId = -2}
                        }
                    }
                },
                new object[]
                {
                    new AtSubmissionDto
                    {
                        AssessmentEventId = -2112,
                        LearnerId = -1,
                        Containers= new List<AtContainerSubmissionDto>
                        {
                            new() {ArrangeTaskContainerId = -1, ElementIds = new List<int> {-1, -2, -3, -4, -5}},
                            new() {ArrangeTaskContainerId = -2},
                            new() {ArrangeTaskContainerId = -3},
                            new() {ArrangeTaskContainerId = -4},
                            new() {ArrangeTaskContainerId = -5}
                        }
                    }
                }
            };
        }
    }
}
