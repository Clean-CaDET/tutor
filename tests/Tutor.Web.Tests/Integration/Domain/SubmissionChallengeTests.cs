using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.DomainModel.AssessmentEvents;
using Tutor.Core.DomainModel.KnowledgeComponents;
using Tutor.Infrastructure.Database;
using Tutor.Web.Controllers.Domain;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents.Challenge;
using Tutor.Web.Tests.TestData;
using Xunit;

namespace Tutor.Web.Tests.Integration.Domain
{
    [Collection("Sequential")]
    public class SubmissionChallengeTests : BaseIntegrationTest
    {
        public SubmissionChallengeTests(TutorApplicationTestFactory<Startup> factory) : base(factory) {}

        [Theory]
        [MemberData(nameof(ChallengeSubmissions))]
        public void Accepts_challenge_submission_and_produces_correct_evaluation(ChallengeSubmissionDto submission, ChallengeEvaluationDto expectedEvaluation)
        {
            using var scope = Factory.Services.CreateScope();
            var controller = new SubmissionController(Factory.Services.GetRequiredService<IMapper>(), scope.ServiceProvider.GetRequiredService<ISubmissionService>());
            var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();

            var actualEvaluation = ((OkObjectResult)controller.SubmitChallenge(submission).Result).Value as ChallengeEvaluationDto;

            actualEvaluation.ShouldNotBeNull();
            actualEvaluation.AssessmentEventId.ShouldBe(expectedEvaluation.AssessmentEventId);
            actualEvaluation.ApplicableHints.Count.ShouldBe(expectedEvaluation.ApplicableHints.Count);
            actualEvaluation.ApplicableHints.Select(h => h.Id)
                .All(expectedEvaluation.ApplicableHints.Select(i => i.Id).Contains).ShouldBeTrue();
            actualEvaluation.Correct.ShouldBe(expectedEvaluation.Correct);

            var actualSubmission = dbContext.ChallengeSubmissions.OrderBy(s => s.TimeStamp).Last(c => c.AssessmentEventId == submission.AssessmentEventId);
            actualSubmission.IsCorrect.ShouldBe(expectedEvaluation.Correct);
        }

        public static IEnumerable<object[]> ChallengeSubmissions() => new List<object[]>
        {
            new object[]
            {
                new ChallengeSubmissionDto { AssessmentEventId = -211, LearnerId = -1, SourceCode = IntegrationTestCode.GetFailingAchievement()},
                new ChallengeEvaluationDto
                {
                    Correct = false, AssessmentEventId = -211,
                    ApplicableHints = new List<ChallengeHintDto> { new()
                    {
                        Id = -1,
                        ApplicableToCodeSnippets = new List<string> { "ExamplesApp.Method.PaymentService.CreatePayment(int, int)" }
                    } }
                }
            },
            new object[]
            {
                new ChallengeSubmissionDto { AssessmentEventId = -211, LearnerId = -1, SourceCode = IntegrationTestCode.GetPassingAchievement()},
                new ChallengeEvaluationDto
                {
                    Correct = true, AssessmentEventId = -211,
                    ApplicableHints = new List<ChallengeHintDto>()
                }
            },
            new object[]
            {
                new ChallengeSubmissionDto { AssessmentEventId = -154, LearnerId = -1, SourceCode = IntegrationTestCode.GetFailingCourse()},
                new ChallengeEvaluationDto
                {
                    Correct = false, AssessmentEventId = -154,
                    ApplicableHints = new List<ChallengeHintDto> { new()
                    {
                        Id = -1541
                    } }
                }
            },
            new object[]
            {
                new ChallengeSubmissionDto { AssessmentEventId = -154, LearnerId = -1, SourceCode = IntegrationTestCode.GetPassingCourse()},
                new ChallengeEvaluationDto
                {
                    Correct = true, AssessmentEventId = -154,
                    ApplicableHints = new List<ChallengeHintDto>()
                }
            }
        };

        [Fact]
        public void Rejects_bad_challenge_submission()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = new SubmissionController(Factory.Services.GetRequiredService<IMapper>(), scope.ServiceProvider.GetRequiredService<ISubmissionService>());
            var submission = new ChallengeSubmissionDto
            {
                AssessmentEventId = -211,
                LearnerId = -1
            };

            var result = controller.SubmitChallenge(submission).Result;
            
            result.ShouldBeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public void Gets_syntax_error_hint()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = new SubmissionController(Factory.Services.GetRequiredService<IMapper>(), scope.ServiceProvider.GetRequiredService<ISubmissionService>());
            var submission = new ChallengeSubmissionDto
            {
                AssessmentEventId = -211,
                LearnerId = -1,
                SourceCode = new[]
                {
                    @"public class Test
                    {
                        private string name;
                        public Test() { name = test }
                    }"
                }
            };

            var actualEvaluation = ((OkObjectResult)controller.SubmitChallenge(submission).Result).Value as ChallengeEvaluationDto;

            actualEvaluation.ShouldNotBeNull();
            actualEvaluation.ApplicableHints.Count.ShouldBe(1);
            var errors = actualEvaluation.ApplicableHints[0].Content;
            errors.Split("\n").Length.ShouldBe(1);
        }
    }
}
