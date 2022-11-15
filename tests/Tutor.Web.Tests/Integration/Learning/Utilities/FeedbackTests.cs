using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.UseCases.Learning.Utilities;
using Tutor.Infrastructure.Database;
using Tutor.Web.Controllers.Learners.Learning.Utilities.Feedback;
using Xunit;

namespace Tutor.Web.Tests.Integration.Learning.Utilities
{
    [Collection("Sequential")]
    public class FeedbackTests : BaseWebIntegrationTest
    {
        public FeedbackTests(TutorApplicationTestFactory<Startup> factory) : base(factory) { }

        [Theory]
        [MemberData(nameof(EmotionsFeedbackSubmission))]
        public void Stores_emotions_feedback(EmotionsFeedbackDto postedFeedback, EmotionsFeedbackDto expectedFeedback)
        {
            using var scope = Factory.Services.CreateScope();
            var controller = new FeedbackController(Factory.Services.GetRequiredService<IMapper>(), scope.ServiceProvider.GetRequiredService<IFeedbackService>())
            {
                ControllerContext = BuildContext("-1", "learner")
            };
            var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();

            var actualFeedback = ((OkObjectResult)controller.PostEmotionsFeedback(postedFeedback).Result).Value as EmotionsFeedbackDto;

            actualFeedback.ShouldNotBeNull();
            actualFeedback.LearnerId.ShouldBe(expectedFeedback.LearnerId);
            actualFeedback.KnowledgeComponentId.ShouldBe(expectedFeedback.KnowledgeComponentId);
            actualFeedback.Comment.ShouldBe(expectedFeedback.Comment);

            var feedback = dbContext.EmotionsFeedbacks.OrderBy(s => s.TimeStamp).Last(c => c.Comment == postedFeedback.Comment);
            feedback.Comment.ShouldBe(expectedFeedback.Comment);
        }

        [Theory]
        [MemberData(nameof(TutorImprovementFeedbackSubmission))]
        public void Stores_tutor_improvement_feedback(TutorImprovementFeedbackDto postedFeedback, TutorImprovementFeedbackDto expectedFeedback)
        {
            using var scope = Factory.Services.CreateScope();
            var controller = new FeedbackController(Factory.Services.GetRequiredService<IMapper>(), scope.ServiceProvider.GetRequiredService<IFeedbackService>())
            {
                ControllerContext = BuildContext("-1", "learner")
            };
            var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();

            var actualFeedback = ((OkObjectResult)controller.PostTutorImprovementFeedback(postedFeedback).Result).Value as TutorImprovementFeedbackDto;

            actualFeedback.ShouldNotBeNull();
            actualFeedback.LearnerId.ShouldBe(expectedFeedback.LearnerId);
            actualFeedback.UnitId.ShouldBe(expectedFeedback.UnitId);
            actualFeedback.SoftwareComment.ShouldBe(expectedFeedback.SoftwareComment);
            actualFeedback.ContentComment.ShouldBe(expectedFeedback.ContentComment);

            var feedback = dbContext.TutorImprovementFeedbacks.OrderBy(s => s.TimeStamp).Last(c => c.SoftwareComment == postedFeedback.SoftwareComment && c.ContentComment == postedFeedback.ContentComment);
            feedback.SoftwareComment.ShouldBe(expectedFeedback.SoftwareComment);
            feedback.ContentComment.ShouldBe(expectedFeedback.ContentComment);
        }

        public static IEnumerable<object[]> EmotionsFeedbackSubmission() => new List<object[]>
        {
            new object[]
            {
                new EmotionsFeedbackDto {LearnerId = -1, KnowledgeComponentId = -1, Comment = "I had a nice time studying using Smart Tutor"},
                new EmotionsFeedbackDto {LearnerId = -1, KnowledgeComponentId = -1, Comment = "I had a nice time studying using Smart Tutor"}
            },
            new object[]
            {
                new EmotionsFeedbackDto {LearnerId = -1, KnowledgeComponentId = -2, Comment = "I was bored"},
                new EmotionsFeedbackDto {LearnerId = -1, KnowledgeComponentId = -2, Comment = "I was bored"}
            }
        };

        public static IEnumerable<object[]> TutorImprovementFeedbackSubmission() => new List<object[]>
        {
            new object[]
            {
                new TutorImprovementFeedbackDto
                {
                    LearnerId = -1,
                    UnitId = -1,
                    SoftwareComment = "There's a bug in rating mechanism",
                    ContentComment = "I would like to see more images"
                },
                new TutorImprovementFeedbackDto
                {
                    LearnerId = -1,
                    UnitId = -1,
                    SoftwareComment = "There's a bug in rating mechanism",
                    ContentComment = "I would like to see more images"
                }
            },
            new object[]
            {
                new TutorImprovementFeedbackDto
                {
                    LearnerId = -1,
                    UnitId = -2,
                    SoftwareComment = "I would like to have a highlighting tool",
                    ContentComment = "There should be less videos"
                },
                new TutorImprovementFeedbackDto
                {
                    LearnerId = -1,
                    UnitId = -2,
                    SoftwareComment = "I would like to have a highlighting tool",
                    ContentComment = "There should be less videos"
                }
            }
        };
    }
}
