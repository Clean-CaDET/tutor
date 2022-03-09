using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutor.Core.DomainModel.Feedback;
using Tutor.Infrastructure.Database;
using Tutor.Web.Controllers.Domain;
using Tutor.Web.Controllers.Domain.DTOs.Feedback;
using Xunit;

namespace Tutor.Web.Tests.Integration.Domain
{
    [Collection("Sequential")]
    public class FeedbackTests : BaseIntegrationTest
    {
        public FeedbackTests(TutorApplicationTestFactory<Startup> factory) : base(factory) {}

        [Theory]
        [MemberData(nameof(EmotionsFeedbackSubmission))]
        public void Stores_emotions_feedback(EmotionsFeedbackDto postedFeedback, EmotionsFeedbackDto expectedFeedback)
        {
            using var scope = Factory.Services.CreateScope();
            var controller = new FeedbackController(Factory.Services.GetRequiredService<IMapper>(), scope.ServiceProvider.GetRequiredService<IFeedbackService>());
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
        [MemberData(nameof(CrowdReFeedbackSubmission))]
        public void Stores_crowdre_feedback(CrowdReFeedbackDto postedFeedback, CrowdReFeedbackDto expectedFeedback)
        {
            using var scope = Factory.Services.CreateScope();
            var controller = new FeedbackController(Factory.Services.GetRequiredService<IMapper>(), scope.ServiceProvider.GetRequiredService<IFeedbackService>());
            var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();

            var actualFeedback = ((OkObjectResult)controller.PostCrowdReFeedback(postedFeedback).Result).Value as CrowdReFeedbackDto;

            actualFeedback.ShouldNotBeNull();
            actualFeedback.LearnerId.ShouldBe(expectedFeedback.LearnerId);
            actualFeedback.UnitId.ShouldBe(expectedFeedback.UnitId);
            actualFeedback.SoftwareComment.ShouldBe(expectedFeedback.SoftwareComment);
            actualFeedback.ContentComment.ShouldBe(expectedFeedback.ContentComment);

            var feedback = dbContext.CrowdReFeedbacks.OrderBy(s => s.TimeStamp).Last(c => c.SoftwareComment == postedFeedback.SoftwareComment && c.ContentComment == postedFeedback.ContentComment);
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
                new EmotionsFeedbackDto {LearnerId = -2, KnowledgeComponentId = -2, Comment = "I was bored"},
                new EmotionsFeedbackDto {LearnerId = -2, KnowledgeComponentId = -2, Comment = "I was bored"}
            }
        };

        public static IEnumerable<object[]> CrowdReFeedbackSubmission() => new List<object[]>
        {
            new object[]
            {
                new CrowdReFeedbackDto 
                {
                    LearnerId = -1, 
                    UnitId = -1, 
                    SoftwareComment = "There's a bug in rating mechanism",
                    ContentComment = "I would like to see more images"
                },
                new CrowdReFeedbackDto 
                {
                    LearnerId = -1,
                    UnitId = -1,
                    SoftwareComment = "There's a bug in rating mechanism",
                    ContentComment = "I would like to see more images"
                }
            },
            new object[]
            {
                new CrowdReFeedbackDto 
                {
                    LearnerId = -2, 
                    UnitId = -2,
                    SoftwareComment = "I would like to have a highlighting tool", 
                    ContentComment = "There should be less videos"
                },
                new CrowdReFeedbackDto
                {
                    LearnerId = -2,
                    UnitId = -2,
                    SoftwareComment = "I would like to have a highlighting tool",
                    ContentComment = "There should be less videos"
                }
            }
        };
    }
}
