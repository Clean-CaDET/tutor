using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Learner.Learning;
using Tutor.KnowledgeComponents.API.Dtos;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge;
using Tutor.KnowledgeComponents.API.Dtos.KnowledgeMastery;
using Tutor.KnowledgeComponents.API.Public.Learning;

namespace Tutor.KnowledgeComponents.Tests.Integration.Learning;

[Collection("Sequential")]
public class StructureTests : BaseKnowledgeComponentsIntegrationTest
{
    public StructureTests(KnowledgeComponentsTestFactory factory) : base(factory) {}

    [Fact]
    public void Retrieves_mastered_unit_ids()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-4");

        var masteredUnitIds = ((OkObjectResult)controller.GetMasteredUnitIds(new List<int> {-4}).Result)?.Value as List<int>;

        masteredUnitIds.ShouldNotBeNull();
        masteredUnitIds.Count.ShouldBe(1);
        masteredUnitIds.ShouldContain(-4);
    }

    [Theory]
    [MemberData(nameof(KnowledgeComponentMasteries))]
    public void Retrieves_kc_mastery_for_unit(int unitId, List<KnowledgeComponentMasteryDto> expectedResult)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-2");

        var actualResult = ((OkObjectResult)controller.GetKcsWithMasteries(unitId).Result)?.Value as List<KcWithMasteryDto>;

        expectedResult.All(kcms => actualResult.Any(
                item => kcms.KnowledgeComponentId == item.KnowledgeComponent.Id && kcms.Mastery == item.Mastery.Mastery))
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
        var controller = CreateController(scope, "-2");

        var kc = ((OkObjectResult)controller.GetKnowledgeComponent(-11).Result)?.Value as KnowledgeComponentDto;

        kc.ShouldNotBeNull();
        kc.Id.ShouldBe(-11);
    }

    private static StructureController CreateController(IServiceScope scope, string id)
    {
        return new StructureController(scope.ServiceProvider.GetRequiredService<IStructureService>())
        {
            ControllerContext = BuildContext(id, "learner")
        };
    }
}