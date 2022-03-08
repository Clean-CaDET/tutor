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
            actualFeedback.KnowledgeComponentId.ShouldBe(expectedFeedback.LearnerId);
            actualFeedback.Comment.ShouldBe(expectedFeedback.Comment);

            var feedback = dbContext.EmotionsFeedbacks.OrderBy(s => s.TimeStamp).Last(c => c.Comment == postedFeedback.Comment);
            feedback.Comment.ShouldBe(expectedFeedback.Comment);
        }

        public static IEnumerable<object[]> EmotionsFeedbackSubmission() => new List<object[]>
        {
            new object[]
            {
                new EmotionsFeedbackDto {LearnerId = -1, KnowledgeComponentId = -10, Comment = "I had a nice time studying using Smart Tutor"},
                new EmotionsFeedbackDto {LearnerId = -1, KnowledgeComponentId = -10, Comment = "I had a nice time studying using Smart Tutor"}
            },
            new object[]
            {
                new EmotionsFeedbackDto {LearnerId = -1, KnowledgeComponentId = -13, Comment = "I was bored"},
                new EmotionsFeedbackDto {LearnerId = -1, KnowledgeComponentId = -13, Comment = "I was bored"}
            }
        };
    }
}
