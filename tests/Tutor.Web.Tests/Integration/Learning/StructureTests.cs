using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Tutor.Core.UseCases.Learning;
using Tutor.Infrastructure.Database;
using Tutor.Web.Controllers.Learners.Learning;
using Tutor.Web.Mappings.KnowledgeMastery;
using Xunit;
using Tutor.Core.UseCases.Learning.Assessment;
using Tutor.Web.Controllers.Learners.Learning.Assessment;
using Tutor.Web.Mappings.Knowledge.DTOs;
using Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems.MultiResponseQuestions;
using Tutor.Web.Mappings.Knowledge.DTOs.InstructionalItems;

namespace Tutor.Web.Tests.Integration.Learning
{
    [Collection("Sequential")]
    public class StructureTests : BaseWebIntegrationTest
    {
        public StructureTests(TutorApplicationTestFactory<Startup> factory) : base(factory) {}

        [Theory]
        [MemberData(nameof(KnowledgeComponentMasteries))]
        public void Retrieves_kc_mastery_for_unit(int unitId, List<KnowledgeComponentDto> expectedKCs)
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupStructureController(scope, "-2");

            var unit = ((OkObjectResult)controller.GetUnit(unitId).Result).Value as KnowledgeUnitDto;

            expectedKCs.All(expectedKc => unit.KnowledgeComponents.Any(
                    kc => expectedKc.Id == kc.Id && expectedKc.Mastery.Mastery == kc.Mastery.Mastery))
                .ShouldBe(true);
        }

        public static IEnumerable<object[]> KnowledgeComponentMasteries()
        {
            return new List<object[]>
            {
                new object[]
                {
                    -1,
                    new List<KnowledgeComponentDto>
                    {
                        new() {Id = -11, Mastery = new KnowledgeComponentMasteryDto { Mastery = 0.1 }},
                        new() {Id = -12, Mastery = new KnowledgeComponentMasteryDto { Mastery = 0.2 }},
                        new() {Id = -13, Mastery = new KnowledgeComponentMasteryDto { Mastery = 0.3 }},
                        new() {Id = -14, Mastery = new KnowledgeComponentMasteryDto { Mastery = 0.4 }},
                        new() {Id = -15, Mastery = new KnowledgeComponentMasteryDto { Mastery = 0.5 }}
                    }
                }
            };
        }

        [Theory]
        [MemberData(nameof(InstructionalItems))]
        public void Retrieves_instructional_events(int knowledgeComponentId, int expectedIEsCount)
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupStructureController(scope, "-2");

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
        [MemberData(nameof(MrqSubmission))]
        public void Updates_Kc_Mastery(int learnerId, MrqSubmissionDto submission, double expectedKcMastery)
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupAssessmentEvaluationController(scope, learnerId.ToString());
            var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();
            var assessmentItem = dbContext.AssessmentItems.FirstOrDefault(ae => ae.Id == submission.AssessmentItemId);
            var knowledgeComponent =
                dbContext.KnowledgeComponents.FirstOrDefault(kc => kc.Id == assessmentItem.KnowledgeComponentId);
            
            controller.SubmitMultipleResponseQuestion(submission);
            
            var actualKcMastery = dbContext.KcMasteries.FirstOrDefault(kcm => kcm.LearnerId == learnerId
            && kcm.KnowledgeComponent.Id == knowledgeComponent.Id);
            
            actualKcMastery.Mastery.ShouldBe(expectedKcMastery);
        }
        //Rethink this test
        private EvaluationController SetupAssessmentEvaluationController(IServiceScope scope, string id)
        {
            return new EvaluationController(Factory.Services.GetRequiredService<IMapper>(),
                scope.ServiceProvider.GetRequiredService<IEvaluationService>(),
                scope.ServiceProvider.GetRequiredService<IHelpService>())
            {
                ControllerContext = BuildContext(id, "learner")
            };
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

        private StructureController SetupStructureController(IServiceScope scope, string id)
        {
            return new StructureController(Factory.Services.GetRequiredService<IMapper>(),
                scope.ServiceProvider.GetRequiredService<IStructureService>())
            {
                ControllerContext = BuildContext(id, "learner")
            };
        }
    }
}