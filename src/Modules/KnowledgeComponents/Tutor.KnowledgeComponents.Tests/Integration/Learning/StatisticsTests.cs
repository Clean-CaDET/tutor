using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Learner.Learning;
using Tutor.KnowledgeComponents.API.Dtos.KnowledgeMastery;
using Tutor.KnowledgeComponents.API.Interfaces.Learning;
using Xunit;

namespace Tutor.KnowledgeComponents.Tests.Integration.Learning;

[Collection("Sequential")]
public class StatisticsTests : BaseKnowledgeComponentsIntegrationTest
{
    public StatisticsTests(KnowledgeComponentsTestFactory factory) : base(factory) {}

    [Fact]
    public void Retrieves_kcm_statistics()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-2");

        var kcMasteryStatistics = ((OkObjectResult)controller.GetKcMasteryStatistics(-15).Result).Value as KcMasteryStatisticsDto;

        kcMasteryStatistics.ShouldNotBeNull();
        kcMasteryStatistics.IsSatisfied.ShouldBe(false);
        kcMasteryStatistics.Mastery.ShouldBe(0.5);
        kcMasteryStatistics.TotalCount.ShouldBe(4);
        kcMasteryStatistics.AttemptedCount.ShouldBe(4);
        kcMasteryStatistics.PassedCount.ShouldBe(0);
    }

    [Fact]
    public void Retrieves_assessment_max_correctness()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-2");

        var correctness = (double)((OkObjectResult)controller.GetMaxCorrectness(-134).Result).Value;

        correctness.ShouldBe(0.75);
    }

    private static StatisticsController CreateController(IServiceScope scope, string id)
    {
        return new StatisticsController(scope.ServiceProvider.GetRequiredService<IStatisticsService>())
        {
            ControllerContext = BuildContext(id, "learner")
        };
    }
}