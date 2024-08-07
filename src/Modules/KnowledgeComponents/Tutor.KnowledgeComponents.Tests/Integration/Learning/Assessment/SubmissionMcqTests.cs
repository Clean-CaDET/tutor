﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems.MultiChoiceQuestions;
using Tutor.KnowledgeComponents.Infrastructure.Database;

namespace Tutor.KnowledgeComponents.Tests.Integration.Learning.Assessment;

[Collection("Sequential")]
public class SubmissionMcqTests : BaseAssessmentEvaluationIntegrationTest
{
    public SubmissionMcqTests(KnowledgeComponentsTestFactory factory) : base(factory) { }

    [Theory]
    [MemberData(nameof(McqSubmissions))]
    public void Submits_multi_choice_questions(int assessmentItemId, McqSubmissionDto submission, McqEvaluationDto expectedEvaluation)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-3");
        var dbContext = scope.ServiceProvider.GetRequiredService<KnowledgeComponentsContext>();
        dbContext.Database.BeginTransaction();

        var actualEvaluation = ((ObjectResult)controller.SubmitAssessmentAnswer(assessmentItemId, submission).Result).Value
            as FeedbackDto;

        actualEvaluation.ShouldNotBeNull();
        actualEvaluation.Evaluation.CorrectnessLevel.ShouldBe(expectedEvaluation.CorrectnessLevel);
        VerifyEventGenerated(dbContext, "AssessmentItemAnswered");
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