using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.UseCases.Learning;
using Tutor.Core.UseCases.Learning.Assessment;
using Tutor.Infrastructure.Database;
using Tutor.Web.Controllers.Learners.Learning;
using Tutor.Web.Controllers.Learners.Learning.Assessment;
using Tutor.Web.Mappings.Knowledge.DTOs;
using Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems.MultiResponseQuestions;
using Tutor.Web.Mappings.Knowledge.DTOs.InstructionalItems;
using Tutor.Web.Mappings.KnowledgeMastery;
using Xunit;

namespace Tutor.Web.Tests.Integration.Learning;

[Collection("Sequential")]
public class StructureTests : BaseWebIntegrationTest
{
    public StructureTests(TutorApplicationTestFactory<Startup> factory) : base(factory) {}

    [Fact]
    public void Retrieves_unit()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupStructureController(scope, "-2");

        var unit = ((OkObjectResult)controller.GetUnit(-1).Result)?.Value as KnowledgeUnitDto;

        unit.ShouldNotBeNull();
        unit.Id.ShouldBe(-1);
        unit.KnowledgeComponents.ShouldNotBeNull();
        unit.KnowledgeComponents.Count.ShouldBe(6);
    }

    [Theory]
    [MemberData(nameof(KnowledgeComponentMasteries))]
    public void Retrieves_kc_mastery_for_unit(int unitId, List<KnowledgeComponentMasteryDto> expectedKCs)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupStructureController(scope, "-2");

        var actualKcms = ((OkObjectResult)controller.GetMasteries(unitId).Result)?.Value as List<KnowledgeComponentMasteryDto>;

        expectedKCs.All(expectedKc => actualKcms.Any(
                kcm => expectedKc.KnowledgeComponentId == kcm.KnowledgeComponentId && expectedKc.Mastery == kcm.Mastery))
            .ShouldBe(true);
    }

    public static IEnumerable<object[]> KnowledgeComponentMasteries()
    {
        return new List<object[]>
        {
            new object[]
            {
                -1,
                new List<KnowledgeComponentMasteryDto>
                {
                    new() { Mastery = 0.1, KnowledgeComponentId = -11 },
                    new() { Mastery = 0.2, KnowledgeComponentId = -12 },
                    new() { Mastery = 0.3, KnowledgeComponentId = -13 },
                    new() { Mastery = 0.4, KnowledgeComponentId = -14 },
                    new() { Mastery = 0.5, KnowledgeComponentId = -15 }
                }
            }
        };
    }

    [Fact]
    public void Retrieves_knowledge_component()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupStructureController(scope, "-2");

        var kc = ((OkObjectResult)controller.GetKnowledgeComponent(-11).Result)?.Value as KnowledgeComponentDto;

        kc.ShouldNotBeNull();
        kc.Id.ShouldBe(-11);
    }

    [Theory]
    [MemberData(nameof(InstructionalItems))]
    public void Retrieves_instructional_events(int knowledgeComponentId, int expectedIEsCount)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupStructureController(scope, "-2");

        var items = ((OkObjectResult)controller.GetInstructionalItems(knowledgeComponentId).Result)?.Value as List<InstructionalItemDto>;

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
    public void Updates_Kc_Mastery(int learnerId, int assessmentItemId, MrqSubmissionDto submission, double expectedKcMastery)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupAssessmentEvaluationController(scope, learnerId.ToString());
        var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();
        var assessmentItem = dbContext.AssessmentItems.FirstOrDefault(ae => ae.Id == assessmentItemId);
        var knowledgeComponent =
            dbContext.KnowledgeComponents.FirstOrDefault(kc => kc.Id == assessmentItem.KnowledgeComponentId);

        controller.SubmitAssessmentAnswer(assessmentItemId, submission);

        dbContext.ChangeTracker.Clear();
        var actualKcMastery = dbContext.KcMasteries.FirstOrDefault(kcm => kcm.LearnerId == learnerId
                                                                          && kcm.KnowledgeComponentId == knowledgeComponent.Id);
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
                -106,
                new MrqSubmissionDto
                {
                    Answers = new List<MrqItemDto>
                    {
                        new() {Text = "-1062"},
                        new() {Text = "-1065"}
                    }
                },
                0.5
            },
            new object[]
            {
                -3,
                -106,
                new MrqSubmissionDto
                {
                    Answers = new List<MrqItemDto>
                    {
                        new() {Text = "-1061"},
                        new() {Text = "-1065"}
                    }
                },
                0.5
            },
            new object[]
            {
                -3,
                -107,
                new MrqSubmissionDto
                {
                    Answers = new List<MrqItemDto>
                    {
                        new() {Text = "-1071"},
                        new() {Text = "-1073"},
                        new() {Text = "-1074"}
                    }
                },
                0.5
            },
            new object[]
            {
                -3,
                -107,
                new MrqSubmissionDto
                {
                    Answers = new List<MrqItemDto>
                    {
                        new() {Text = "-1072"},
                        new() {Text = "-1074"}
                    }
                },
                0.8
            },
            new object[]
            {
                -3,
                -107,
                new MrqSubmissionDto
                {
                    Answers = new List<MrqItemDto>
                    {
                        new() {Text = "-1072"},
                        new() {Text = "-1075"}
                    }
                },
                1.0
            },
            new object[]
            {
                -2,
                -106,
                new MrqSubmissionDto
                {
                    Answers = new List<MrqItemDto>
                    {
                        new() {Text = "-1062"},
                        new() {Text = "-1065"}
                    }
                },
                0.5
            },
            new object[]
            {
                -2,
                -106,
                new MrqSubmissionDto
                {
                    Answers = new List<MrqItemDto>
                    {
                        new() {Text = "-1061"},
                        new() {Text = "-1065"}
                    }
                },
                0.5
            },
            new object[]
            {
                -2,
                -107,
                new MrqSubmissionDto
                {
                    Answers = new List<MrqItemDto>
                    {
                        new() {Text = "-1071"},
                        new() {Text = "-1073"},
                        new() {Text = "-1074"}
                    }
                },
                0.5
            },
            new object[]
            {
                -2,
                -107,
                new MrqSubmissionDto
                {
                    Answers = new List<MrqItemDto>
                    {
                        new() {Text = "-1072"},
                        new() {Text = "-1074"}
                    }
                },
                0.8
            },
            new object[]
            {
                -2,
                -107,
                new MrqSubmissionDto
                {
                    Answers = new List<MrqItemDto>
                    {
                        new() {Text = "-1072"},
                        new() {Text = "-1075"}
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