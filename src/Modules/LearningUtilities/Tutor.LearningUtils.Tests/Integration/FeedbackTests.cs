using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Learner.Utilities;
using Tutor.LearningUtils.API.Dtos.Feedback;
using Tutor.LearningUtils.API.Interfaces;
using Tutor.LearningUtils.Infrastructure.Database;

namespace Tutor.LearningUtils.Tests.Integration;

[Collection("Sequential")]
public class FeedbackTests : BaseLearningUtilsIntegrationTest
{
    public FeedbackTests(LearningUtilsTestFactory factory) : base(factory) {}

    [Theory]
    [MemberData(nameof(EmotionsFeedbackSubmission))]
    public void Stores_emotions_feedback(EmotionsFeedbackDto postedFeedback, EmotionsFeedbackDto expectedFeedback)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningUtilsContext>();
        dbContext.Database.BeginTransaction();

        var actualFeedback = ((OkObjectResult)controller.PostEmotionsFeedback(postedFeedback).Result).Value as EmotionsFeedbackDto;

        dbContext.ChangeTracker.Clear();
        actualFeedback.ShouldNotBeNull();
        actualFeedback.LearnerId.ShouldBe(expectedFeedback.LearnerId);
        actualFeedback.KnowledgeComponentId.ShouldBe(expectedFeedback.KnowledgeComponentId);
        actualFeedback.Comment.ShouldBe(expectedFeedback.Comment);
        var feedback = dbContext.EmotionsFeedbacks.OrderBy(s => s.TimeStamp).Last(c => c.Comment == postedFeedback.Comment);
        feedback.Comment.ShouldBe(expectedFeedback.Comment);
    }

    [Theory]
    [MemberData(nameof(TutorImprovementFeedbackSubmission))]
    public void Stores_tutor_improvement_feedback(ImprovementFeedbackDto postedFeedback, ImprovementFeedbackDto expectedFeedback)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningUtilsContext>();
        dbContext.Database.BeginTransaction();

        var actualFeedback = ((OkObjectResult)controller.PostImprovementFeedback(postedFeedback).Result).Value as ImprovementFeedbackDto;

        dbContext.ChangeTracker.Clear();
        actualFeedback.ShouldNotBeNull();
        actualFeedback.LearnerId.ShouldBe(expectedFeedback.LearnerId);
        actualFeedback.UnitId.ShouldBe(expectedFeedback.UnitId);
        actualFeedback.SoftwareComment.ShouldBe(expectedFeedback.SoftwareComment);
        actualFeedback.ContentComment.ShouldBe(expectedFeedback.ContentComment);
        var feedback = dbContext.ImprovementFeedbacks.OrderBy(s => s.TimeStamp).Last(c => c.SoftwareComment == postedFeedback.SoftwareComment && c.ContentComment == postedFeedback.ContentComment);
        feedback.SoftwareComment.ShouldBe(expectedFeedback.SoftwareComment);
        feedback.ContentComment.ShouldBe(expectedFeedback.ContentComment);
    }

    private static FeedbackController CreateController(IServiceScope scope)
    {
        return new FeedbackController(scope.ServiceProvider.GetRequiredService<IFeedbackService>())
        {
            ControllerContext = BuildContext("-1", "learner")
        };
    }

    public static IEnumerable<object[]> EmotionsFeedbackSubmission() => new List<object[]>
    {
        new object[]
        {
            new EmotionsFeedbackDto {LearnerId = -1, KnowledgeComponentId = -11, Comment = "I had a nice time studying using Smart Tutor"},
            new EmotionsFeedbackDto {LearnerId = -1, KnowledgeComponentId = -11, Comment = "I had a nice time studying using Smart Tutor"}
        },
        new object[]
        {
            new EmotionsFeedbackDto {LearnerId = -1, KnowledgeComponentId = -21, Comment = "I was bored"},
            new EmotionsFeedbackDto {LearnerId = -1, KnowledgeComponentId = -21, Comment = "I was bored"}
        }
    };

    public static IEnumerable<object[]> TutorImprovementFeedbackSubmission() => new List<object[]>
    {
        new object[]
        {
            new ImprovementFeedbackDto
            {
                LearnerId = -1,
                UnitId = -1,
                SoftwareComment = "There's a bug in rating mechanism",
                ContentComment = "I would like to see more images"
            },
            new ImprovementFeedbackDto
            {
                LearnerId = -1,
                UnitId = -1,
                SoftwareComment = "There's a bug in rating mechanism",
                ContentComment = "I would like to see more images"
            }
        },
        new object[]
        {
            new ImprovementFeedbackDto
            {
                LearnerId = -1,
                UnitId = -2,
                SoftwareComment = "I would like to have a highlighting tool",
                ContentComment = "There should be less videos"
            },
            new ImprovementFeedbackDto
            {
                LearnerId = -1,
                UnitId = -2,
                SoftwareComment = "I would like to have a highlighting tool",
                ContentComment = "There should be less videos"
            }
        }
    };
}