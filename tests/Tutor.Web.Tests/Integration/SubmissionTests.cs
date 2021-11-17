using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.ProgressModel.Submissions;
using Tutor.Infrastructure.Database;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents;
using Tutor.Web.Controllers.Domain.DTOs.InstructionalEvents;
using Tutor.Web.Controllers.Progress;
using Tutor.Web.Controllers.Progress.DTOs.SubmissionEvaluation;
using Tutor.Web.Tests.TestData;
using Xunit;

namespace Tutor.Web.Tests.Integration
{
    public class SubmissionTests: IClassFixture<TutorApplicationTestFactory<Startup>>
    {
        private readonly TutorApplicationTestFactory<Startup> _factory;

        public SubmissionTests(TutorApplicationTestFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [MemberData(nameof(QuestionSubmissions))]
        public void Accepts_question_submission_and_produces_correct_evaluation(QuestionSubmissionDTO submission, bool expectedCorrectness)
        {
            using var scope = _factory.Services.CreateScope();
            var controller = new SubmissionController(_factory.Services.GetRequiredService<IMapper>(), scope.ServiceProvider.GetRequiredService<ISubmissionService>());
            var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();

            controller.SubmitQuestionAnswers(submission);

            var actualSubmission = dbContext.QuestionSubmissions.OrderBy(s => s.TimeStamp).Last(q => q.QuestionId == submission.QuestionId);
            actualSubmission.IsCorrect.ShouldBe(expectedCorrectness);
        }

        public static IEnumerable<object[]> QuestionSubmissions() => new List<object[]>
        {
            new object[]
            {
                new QuestionSubmissionDTO
                {
                    QuestionId = 17, Answers = new List<QuestionAnswerDTO>
                    {
                        new() {Id = 2},
                        new() {Id = 5}
                    },
                    LearnerId = 1
                },
                true
            },
            new object[]
            {
                new QuestionSubmissionDTO
                {
                    QuestionId = 17, Answers = new List<QuestionAnswerDTO>
                    {
                        new() {Id = 11},
                        new() {Id = 12},
                        new() {Id = 14},
                        new() {Id = 15}
                    },
                    LearnerId = 1
                },
                false
            },
            new object[]
            {
                new QuestionSubmissionDTO
                {
                    QuestionId = 17, Answers = new List<QuestionAnswerDTO>(),
                    LearnerId = 1
                },
                false
            }
        };
        
        [Theory]
        [MemberData(nameof(ArrangeTaskSubmissions))]
        public void Accepts_arrange_task_submission_and_produces_correct_evaluation(ArrangeTaskSubmissionDTO submission, bool expectedCorrectness)
        {
            using var scope = _factory.Services.CreateScope();
            var controller = new SubmissionController(_factory.Services.GetRequiredService<IMapper>(), scope.ServiceProvider.GetRequiredService<ISubmissionService>());
            var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();

            controller.SubmitArrangeTask(submission);

            var actualSubmission = dbContext.ArrangeTaskSubmissions.OrderBy(s => s.TimeStamp).Last(a => a.ArrangeTaskId == submission.ArrangeTaskId);
            actualSubmission.IsCorrect.ShouldBe(expectedCorrectness);
        }

        public static IEnumerable<object[]> ArrangeTaskSubmissions() => new List<object[]>
        {
            new object[]
            {
                new ArrangeTaskSubmissionDTO
                {
                    ArrangeTaskId = 32, Containers = new List<ArrangeTaskContainerDTO>
                    {
                        new() {Id = 1, Elements = new List<ArrangeTaskElementDTO>()},
                        new() {Id = 2, Elements = new List<ArrangeTaskElementDTO>()},
                        new() {Id = 3, Elements = new List<ArrangeTaskElementDTO>()},
                        new() {Id = 4, Elements = new List<ArrangeTaskElementDTO>()},
                        new()
                        {Id = 5, Elements = new List<ArrangeTaskElementDTO>
                        {
                            new() { Id = 1 },
                            new() { Id = 2 },
                            new() { Id = 3 },
                            new() { Id = 4 },
                            new() { Id = 5 }
                        }}
                    },
                    LearnerId = 1
                },
                false
            },
            new object[]
            {
                new ArrangeTaskSubmissionDTO
                {
                    ArrangeTaskId = 32, Containers = new List<ArrangeTaskContainerDTO>
                    {
                        new() {Id = 1, Elements = new List<ArrangeTaskElementDTO> {new() { Id = 1 }}},
                        new() {Id = 2, Elements = new List<ArrangeTaskElementDTO> {new() { Id = 2 }}},
                        new() {Id = 3, Elements = new List<ArrangeTaskElementDTO> {new() { Id = 3 }}},
                        new() {Id = 4, Elements = new List<ArrangeTaskElementDTO> {new() { Id = 4 }}},
                        new() {Id = 5, Elements = new List<ArrangeTaskElementDTO> {new() { Id = 5 }}}
                    },
                    LearnerId = 1
                },
                true
            }
        };
        
        [Fact]
        public void Rejects_bad_arrange_task_submission()
        {
            using var scope = _factory.Services.CreateScope();
            var controller = new SubmissionController(_factory.Services.GetRequiredService<IMapper>(), scope.ServiceProvider.GetRequiredService<ISubmissionService>());
            var submission = new ArrangeTaskSubmissionDTO
            {
                ArrangeTaskId = 32, LearnerId = 1,
                Containers = new List<ArrangeTaskContainerDTO>
                {
                    new()
                    {
                        Id = 1, Elements = new List<ArrangeTaskElementDTO>
                        {
                            new() {Id = 1}
                        }
                    }
                }
            };

            Should.Throw<InvalidOperationException>(() => controller.SubmitArrangeTask(submission));
        }

        [Theory]
        [MemberData(nameof(ChallengeSubmissions))]
        public void Accepts_challenge_submission_and_produces_correct_evaluation(ChallengeSubmissionDTO submission, ChallengeEvaluationDTO expectedEvaluation)
        {
            using var scope = _factory.Services.CreateScope();
            var controller = new SubmissionController(_factory.Services.GetRequiredService<IMapper>(), scope.ServiceProvider.GetRequiredService<ISubmissionService>());
            var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();

            var actualEvaluation = ((OkObjectResult)controller.SubmitChallenge(submission).Result).Value as ChallengeEvaluationDTO;
            
            actualEvaluation.SolutionLO.Id.ShouldBe(expectedEvaluation.SolutionLO.Id);
            actualEvaluation.ChallengeId.ShouldBe(expectedEvaluation.ChallengeId);
            actualEvaluation.ApplicableHints.Count.ShouldBe(expectedEvaluation.ApplicableHints.Count);
            actualEvaluation.ApplicableHints.Select(h => h.LearningObject.Id)
                .All(expectedEvaluation.ApplicableHints.Select(i => i.LearningObject.Id).Contains).ShouldBeTrue();

            var actualSubmission = dbContext.ChallengeSubmissions.OrderBy(s => s.TimeStamp).Last(c => c.ChallengeId == submission.ChallengeId);
            actualSubmission.IsCorrect.ShouldBe(expectedEvaluation.ChallengeCompleted);
        }

        public static IEnumerable<object[]> ChallengeSubmissions() => new List<object[]>
        {
            new object[]
            {
                new ChallengeSubmissionDTO { LearnerId = 1, ChallengeId = 41, SourceCode = ChallengeTestData.GetFailingAchievement()},
                new ChallengeEvaluationDTO
                {
                    ChallengeCompleted = false, ChallengeId = 41, SolutionLO = new VideoDTO {Id = 42},
                    ApplicableHints = new List<ChallengeHintDTO> { new()
                    {
                        Id = 1, LearningObject = new TextDTO {Id = 43},
                        ApplicableToCodeSnippets = new List<string> { "Methods.Small.AchievementService.AwardAchievement(int, int)" }
                    } }
                }
            },
            new object[]
            {
                new ChallengeSubmissionDTO { LearnerId = 1, ChallengeId = 41, SourceCode = ChallengeTestData.GetPassingAchievement()},
                new ChallengeEvaluationDTO
                {
                    ChallengeCompleted = true, ChallengeId = 41, SolutionLO = new VideoDTO {Id = 42},
                    ApplicableHints = new List<ChallengeHintDTO> { new()
                    {
                        Id = 1, LearningObject = new TextDTO {Id = 43},
                        ApplicableToCodeSnippets = new List<string> { "Methods.Small.AchievementService.AwardAchievement(int, int)" }
                    } }
                }
            }
        };

        [Fact]
        public void Rejects_bad_challenge_submission()
        {
            using var scope = _factory.Services.CreateScope();
            var controller = new SubmissionController(_factory.Services.GetRequiredService<IMapper>(), scope.ServiceProvider.GetRequiredService<ISubmissionService>());
            var submission = new ChallengeSubmissionDTO
            {
                ChallengeId = 41,
                LearnerId = 1
            };

            controller.SubmitChallenge(submission).Result.ShouldBeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public void Gets_syntax_error_hint()
        {
            using var scope = _factory.Services.CreateScope();
            var controller = new SubmissionController(_factory.Services.GetRequiredService<IMapper>(), scope.ServiceProvider.GetRequiredService<ISubmissionService>());
            var submission = new ChallengeSubmissionDTO
            {
                ChallengeId = 41,
                LearnerId = 1,
                SourceCode = new []
                {
                    @"public class Test
                    {
                        private string name;
                        public Test() { name = test }
                    }"
                }
            };

            var actualEvaluation = ((OkObjectResult)controller.SubmitChallenge(submission).Result).Value as ChallengeEvaluationDTO;

            actualEvaluation.ApplicableHints.Count.ShouldBe(1);
            var errors = actualEvaluation.ApplicableHints[0].Content;
            errors.Split("\n").Length.ShouldBe(1);
        }
    }
}
