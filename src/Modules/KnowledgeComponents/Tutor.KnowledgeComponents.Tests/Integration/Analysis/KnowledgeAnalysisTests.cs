using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Instructor.Analysis;
using Tutor.KnowledgeComponents.API.Dtos.KnowledgeAnalytics;
using Tutor.KnowledgeComponents.API.Public.Analysis;

namespace Tutor.KnowledgeComponents.Tests.Integration.Analysis;

[Collection("Sequential")]
public class KnowledgeAnalysisTests : BaseKnowledgeComponentsIntegrationTest
{
    public KnowledgeAnalysisTests(KnowledgeComponentsTestFactory factory) : base(factory) { }

    [Theory]
    [InlineData("-51", -10)]
    public void Retrieves_kc_statistics(string userId, int kcId)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, userId);

        var result = ((OkObjectResult)controller.GetStatistics(kcId).Result).Value as KcStatisticsDto;

        result.ShouldNotBeNull();
        result.TotalRegistered.ShouldBe(4);
        result.TotalStarted.ShouldBe(4);
        result.TotalCompleted.ShouldBe(4);
        result.TotalPassed.ShouldBe(2);
    }

    [Theory]
    [InlineData("-51", -3)]
    public void Retrieves_kc_statistics_fails_instructor_not_course_owner(string userId, int unitId)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, userId);

        var result = (ObjectResult)controller.GetStatistics(unitId).Result;

        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(403);
    }

    private static KnowledgeAnalysisController CreateController(IServiceScope scope, string id)
    {
        return new KnowledgeAnalysisController(scope.ServiceProvider.GetRequiredService<IKnowledgeAnalysisService>())
        {
            ControllerContext = BuildContext(id, "instructor")
        };
    }
}