using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.Domain.Stakeholders;
using Tutor.Core.UseCases.Learning.Assessment;
using Tutor.Web.Controllers.Learners.Learning;
using Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems.Challenges;
using Tutor.Web.Tests.TestData;
using Xunit;

namespace Tutor.Web.Tests.Integration.Learning.Assessment
{
    [Collection("Sequential")]
    public class SubmissionChallengeTests : BaseWebIntegrationTest
    {
        public SubmissionChallengeTests(TutorApplicationTestFactory<Startup> factory) : base(factory) { }

        [Theory]
        [MemberData(nameof(ChallengeSubmissions))]
        public void Accepts_challenge_submission_and_produces_correct_evaluation(ChallengeSubmissionDto submission, ChallengeEvaluationDto expectedEvaluation)
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupChallengeEvaluationController(scope, submission.LearnerId.ToString());

            var actualEvaluation = ((OkObjectResult)controller.SubmitChallenge(submission).Result).Value as ChallengeEvaluationDto;

            actualEvaluation.ShouldNotBeNull();
            actualEvaluation.ApplicableHints.Count.ShouldBe(expectedEvaluation.ApplicableHints.Count);
            actualEvaluation.ApplicableHints.Select(h => h.Id)
                .All(expectedEvaluation.ApplicableHints.Select(i => i.Id).Contains).ShouldBeTrue();
            actualEvaluation.Correct.ShouldBe(expectedEvaluation.Correct);
        }

        public static IEnumerable<object[]> ChallengeSubmissions() => new List<object[]>
        {
            new object[]
            {
                new ChallengeSubmissionDto { AssessmentItemId = -211, LearnerId = -3, SourceCode = ChallengeSubmissionTestCode.GetFailingAchievement()},
                new ChallengeEvaluationDto
                {
                    Correct = false,
                    ApplicableHints = new List<ChallengeHintDto> { new()
                    {
                        Id = -1,
                        ApplicableToCodeSnippets = new List<string> { "ExamplesApp.Method.PaymentService.CreatePayment(int, int)" }
                    } }
                }
            },
            new object[]
            {
                new ChallengeSubmissionDto { AssessmentItemId = -211, LearnerId = -3, SourceCode = ChallengeSubmissionTestCode.GetPassingAchievement()},
                new ChallengeEvaluationDto
                {
                    Correct = true,
                    ApplicableHints = new List<ChallengeHintDto>()
                }
            },
            new object[]
            {
                new ChallengeSubmissionDto { AssessmentItemId = -154, LearnerId = -3, SourceCode = ChallengeSubmissionTestCode.GetFailingCourse()},
                new ChallengeEvaluationDto
                {
                    Correct = false,
                    ApplicableHints = new List<ChallengeHintDto> { new()
                    {
                        Id = -1541
                    } }
                }
            },
            new object[]
            {
                new ChallengeSubmissionDto { AssessmentItemId = -154, LearnerId = -3, SourceCode = ChallengeSubmissionTestCode.GetPassingCourse()},
                new ChallengeEvaluationDto
                {
                    Correct = true,
                    ApplicableHints = new List<ChallengeHintDto>()
                }
            },
            new object[]
            {
                new ChallengeSubmissionDto { AssessmentItemId = -956, LearnerId = -3, SourceCode = ChallengeSubmissionTestCode.GetFailingParams()},
                new ChallengeEvaluationDto
                {
                    Correct = false,
                    ApplicableHints = new List<ChallengeHintDto> { new() {Id = -51}, new() { Id = -52 } }
                }
            },
            new object[]
            {
                new ChallengeSubmissionDto { AssessmentItemId = -956, LearnerId = -2, SourceCode = ChallengeSubmissionTestCode.GetPassingParams()},
                new ChallengeEvaluationDto
                {
                    Correct = true,
                    ApplicableHints = new List<ChallengeHintDto>()
                }
            }
        };

        [Fact]
        public void Rejects_bad_challenge_submission()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupChallengeEvaluationController(scope, "-2");
            var submission = new ChallengeSubmissionDto
            {
                AssessmentItemId = -211,
                LearnerId = -2
            };

            var result = controller.SubmitChallenge(submission).Result;

            result.ShouldBeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public void Gets_syntax_error_hint()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupChallengeEvaluationController(scope, "-3");
            var submission = new ChallengeSubmissionDto
            {
                AssessmentItemId = -211,
                LearnerId = -3,
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

        private PluginController SetupChallengeEvaluationController(IServiceScope scope, string id)
        {
            return new PluginController(scope.ServiceProvider.GetRequiredService<ILearnerRepository>(),
                Factory.Services.GetRequiredService<IMapper>(),
                scope.ServiceProvider.GetRequiredService<IEvaluationService>(),
                scope.ServiceProvider.GetRequiredService<IHelpService>())
            {
                ControllerContext = BuildContext(id, "learner")
            };
        }
    }
}
