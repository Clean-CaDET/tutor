using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Collections.Generic;
using Tutor.Infrastructure.Database;
using Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems;
using Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems.ArrangeTasks;
using Xunit;

namespace Tutor.Web.Tests.Integration.Learning.Assessment;

[Collection("Sequential")]
public class SubmissionArrangeTaskTests : BaseAssessmentEvaluationIntegrationTest
{
    public SubmissionArrangeTaskTests(TutorApplicationTestFactory<Startup> factory) : base(factory) { }

    [Theory]
    [MemberData(nameof(AtSubmissions))]
    public void Submits_arrange_task(int assessmentItemId, AtSubmissionDto submission, AtEvaluationDto expectedEvaluation)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupAssessmentEvaluationController(scope, "-3");
        var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();
        dbContext.Database.BeginTransaction();

        var actualEvaluation = ((ObjectResult)controller.SubmitAssessmentAnswer(assessmentItemId, submission).Result).Value as FeedbackDto;

        actualEvaluation.ShouldNotBeNull();
        actualEvaluation.Evaluation.CorrectnessLevel.ShouldBe(expectedEvaluation.CorrectnessLevel);
    }

    [Theory]
    [MemberData(nameof(InvalidAtSubmissions))]
    public void Submits_invalid_arrange_task(int assessmentItemId, AtSubmissionDto submission, int expectedStatusCode)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupAssessmentEvaluationController(scope, "-3");
        var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();
        dbContext.Database.BeginTransaction();

        var response = (ObjectResult)controller.SubmitAssessmentAnswer(assessmentItemId, submission).Result;

        response.ShouldNotBeNull();
        response.StatusCode.ShouldBe(expectedStatusCode);
    }

    public static IEnumerable<object[]> AtSubmissions()
    {
        return new List<object[]>
        {
            new object[]
            {
                -2111,
                new AtSubmissionDto
                {
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
                -2111,
                new AtSubmissionDto
                {
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
                -2111,
                new AtSubmissionDto
                {
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
                -2111,
                new AtSubmissionDto
                {
                    Containers= new List<AtContainerSubmissionDto>
                    {
                        new() {ArrangeTaskContainerId = -1},
                        new() {ArrangeTaskContainerId = -2},
                        new() {ArrangeTaskContainerId = -3},
                        new() {ArrangeTaskContainerId = -4},
                        new() {ArrangeTaskContainerId = -5}
                    }
                },
                400
            },
            new object[]
            {
                -2111,
                new AtSubmissionDto
                {
                    Containers= new List<AtContainerSubmissionDto>
                    {
                        new() {ArrangeTaskContainerId = -1},
                        new() {ArrangeTaskContainerId = -2}
                    }
                },
                400
            },
            new object[]
            {
                -2112,
                new AtSubmissionDto
                {
                    Containers= new List<AtContainerSubmissionDto>
                    {
                        new() {ArrangeTaskContainerId = -1, ElementIds = new List<int> {-1, -2, -3, -4, -5}},
                        new() {ArrangeTaskContainerId = -2},
                        new() {ArrangeTaskContainerId = -3},
                        new() {ArrangeTaskContainerId = -4},
                        new() {ArrangeTaskContainerId = -5}
                    }
                },
                404
            }
        };
    }
}