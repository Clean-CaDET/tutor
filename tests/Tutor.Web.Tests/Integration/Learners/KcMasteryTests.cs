using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using Tutor.Infrastructure.Database;
using Tutor.Web.Mappings.Domain.DTOs.AssessmentItems;
using Tutor.Web.Mappings.Domain.DTOs.AssessmentItems.MultiResponseQuestions;
using Tutor.Web.Mappings.Domain.DTOs.InstructionalItems;
using Tutor.Web.Mappings.Mastery;
using Xunit;

namespace Tutor.Web.Tests.Integration.Learners
{
    [Collection("Sequential")]
    public class KcMasteryTests : BaseWebIntegrationTest
    {
        public KcMasteryTests(TutorApplicationTestFactory<Startup> factory) : base(factory)
        {
        }

        [Theory]
        [MemberData(nameof(InstructionalItems))]
        public void Retrieves_instructional_events(int knowledgeComponentId, int expectedIEsCount)
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupKcmController(scope, "-2");

            var items = ((OkObjectResult)controller.GetInstructionalItems(knowledgeComponentId).Result).Value as List<InstructionalItemDto>;

            items.ShouldNotBeNull();
            items.Count.ShouldBe(expectedIEsCount);
        }

        public static IEnumerable<object[]> InstructionalItems()
        {
            return new List<object[]>
            {
                new object[]
                {
                    -11,
                    2
                },
                new object[]
                {
                    -15,
                    2
                }
            };
        }

        [Theory]
        [MemberData(nameof(AssessmentItemRequest))]
        public void Gets_suitable_assessment_event(int knowledgeComponentId, int expectedSuitableAssessmentItemId)
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupKcmController(scope, "-2");

            var actualSuitableAssessmentItem =
                ((OkObjectResult) controller.GetSuitableAssessmentItem(knowledgeComponentId).Result)?.Value as AssessmentItemDto;
            actualSuitableAssessmentItem.ShouldNotBeNull();
            
            actualSuitableAssessmentItem.Id.ShouldBe(expectedSuitableAssessmentItemId);
        }

        public static IEnumerable<object[]> AssessmentItemRequest()
        {
            return new List<object[]>
            {
                new object[]
                {
                    -14,
                    -144
                },
                new object[]
                {
                    -15,
                    -153
                },
                new object[]
                {
                    -13,
                    -134
                }
            };
        }

        [Theory]
        [MemberData(nameof(MrqSubmission))]
        public void Updates_Kc_Mastery(int learnerId, MrqSubmissionDto submission, double expectedKcMastery)
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupAssessmentsController(scope, learnerId.ToString());
            var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();
            var assessmentItem = dbContext.AssessmentItems.FirstOrDefault(ae => ae.Id == submission.AssessmentItemId);
            var knowledgeComponent =
                dbContext.KnowledgeComponents.FirstOrDefault(kc => kc.Id == assessmentItem.KnowledgeComponentId);
            
            controller.SubmitMultipleResponseQuestion(submission);
            
            var actualKcMastery = dbContext.KcMasteries.FirstOrDefault(kcm => kcm.LearnerId == learnerId
            && kcm.KnowledgeComponent.Id == knowledgeComponent.Id);
            
            actualKcMastery.Mastery.ShouldBe(expectedKcMastery);
        }

        public static IEnumerable<object[]> MrqSubmission()
        {
            return new List<object[]>
            {
                new object[]
                {
                    -3,
                    new MrqSubmissionDto
                    {
                        AssessmentItemId = -106,
                        Answers = new List<MrqItemDto>
                        {
                            new() {Id = -1062},
                            new() {Id = -1065}
                        }
                    },
                    0.5
                },
                new object[]
                {
                    -3,
                    new MrqSubmissionDto
                    {
                        AssessmentItemId = -106,
                        Answers = new List<MrqItemDto>
                        {
                            new() {Id = -1061},
                            new() {Id = -1065}
                        }
                    },
                    0.5
                },
                new object[]
                {
                    -3,
                    new MrqSubmissionDto
                    {
                        AssessmentItemId = -107,
                        Answers = new List<MrqItemDto>
                        {
                            new() {Id = -1071},
                            new() {Id = -1074},
                            new() {Id = -1073}
                        }
                    },
                    0.5
                },
                new object[]
                {
                    -3,
                    new MrqSubmissionDto
                    {
                        AssessmentItemId = -107,
                        Answers = new List<MrqItemDto>
                        {
                            new() {Id = -1071},
                            new() {Id = -1074},
                            new() {Id = -1073}
                        }
                    },
                    0.5
                },
                new object[]
                {
                    -3,
                    new MrqSubmissionDto
                    {
                        AssessmentItemId = -107,
                        Answers = new List<MrqItemDto>
                        {
                            new() {Id = -1072},
                            new() {Id = -1074},
                        }
                    },
                    0.8
                },
                new object[]
                {
                    -3,
                    new MrqSubmissionDto
                    {
                        AssessmentItemId = -107,
                        Answers = new List<MrqItemDto>
                        {
                            new() {Id = -1072},
                            new() {Id = -1075},
                        }
                    },
                    1.0
                },
                new object[]
                {
                    -2,
                    new MrqSubmissionDto
                    {
                        AssessmentItemId = -106,
                        Answers = new List<MrqItemDto>
                        {
                            new() {Id = -1062},
                            new() {Id = -1065}
                        }
                    },
                    0.5
                },
                new object[]
                {
                    -2,
                    new MrqSubmissionDto
                    {
                        AssessmentItemId = -106,
                        Answers = new List<MrqItemDto>
                        {
                            new() {Id = -1061},
                            new() {Id = -1065}
                        }
                    },
                    0.5
                },
                new object[]
                {
                    -2,
                    new MrqSubmissionDto
                    {
                        AssessmentItemId = -107,
                        Answers = new List<MrqItemDto>
                        {
                            new() {Id = -1071},
                            new() {Id = -1074},
                            new() {Id = -1073}
                        }
                    },
                    0.5
                },
                new object[]
                {
                    -2,
                    new MrqSubmissionDto
                    {
                        AssessmentItemId = -107,
                        Answers = new List<MrqItemDto>
                        {
                            new() {Id = -1071},
                            new() {Id = -1074},
                            new() {Id = -1073}
                        }
                    },
                    0.5
                },
                new object[]
                {
                    -2,
                    new MrqSubmissionDto
                    {
                        AssessmentItemId = -107,
                        Answers = new List<MrqItemDto>
                        {
                            new() {Id = -1072},
                            new() {Id = -1074},
                        }
                    },
                    0.8
                },
                new object[]
                {
                    -2,
                    new MrqSubmissionDto
                    {
                        AssessmentItemId = -107,
                        Answers = new List<MrqItemDto>
                        {
                            new() {Id = -1072},
                            new() {Id = -1075},
                        }
                    },
                    1.0
                }
            };
        }

        [Fact]
        public void Retrieves_kcm_statistics()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupKcmController(scope, "-2");

            var kcMasteryStatistics = ((OkObjectResult)controller.GetKcMasteryStatistics(-15).Result).Value as KcMasteryStatisticsDto;

            kcMasteryStatistics.ShouldNotBeNull();
            kcMasteryStatistics.IsSatisfied.ShouldBe(false);
            kcMasteryStatistics.Mastery.ShouldBe(0.5);
            kcMasteryStatistics.TotalCount.ShouldBe(4);
            kcMasteryStatistics.AttemptedCount.ShouldBe(4);
            kcMasteryStatistics.PassedCount.ShouldBe(0);
        }
    }
}