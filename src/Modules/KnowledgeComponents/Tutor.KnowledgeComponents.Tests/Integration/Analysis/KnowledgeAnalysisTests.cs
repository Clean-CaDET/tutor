using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Instructor.Analysis;
using Tutor.KnowledgeComponents.API.Dtos.KnowledgeAnalytics;
using Tutor.KnowledgeComponents.API.Interfaces.Analysis;
using Xunit;

namespace Tutor.KnowledgeComponents.Tests.Integration.Analysis;

[Collection("Sequential")]
public class KnowledgeAnalysisTests : BaseKnowledgeComponentsIntegrationTest
{
    public KnowledgeAnalysisTests(KnowledgeComponentsTestFactory factory) : base(factory) { }

    [Theory]
    [MemberData(nameof(TestData))]
    public void Retrieves_kc_statistics_for_group(string userId, int kcId, int groupId, KcStatisticsDto expectedStatistics)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, userId);

        var result = ((OkObjectResult)controller.GetStatisticsForGroup(kcId, groupId).Result).Value as KcStatisticsDto;

        result.ShouldNotBeNull();
        result.ShouldBe(expectedStatistics);
    }

    [Theory]
    [InlineData("-51", -10)]
    public void Retrieves_kc_statistics(string userId, int kcId)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, userId);

        var result = ((OkObjectResult)controller.GetStatistics(kcId).Result).Value as KcStatisticsDto;

        result.ShouldNotBeNull();
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

    private KnowledgeAnalysisController CreateController(IServiceScope scope, string id)
    {
        return new KnowledgeAnalysisController(scope.ServiceProvider.GetRequiredService<IKnowledgeAnalysisService>())
        {
            ControllerContext = BuildContext(id, "instructor")
        };
    }

    public static IEnumerable<object[]> TestData()
    {
        return new List<object[]>
        {
            new object[]
            {
                "-51", -10, -1,
                new KcStatisticsDto
                {
                    KcId = -10,
                    MinutesToCompletion = new List<double> {0,0,0,0},
                    MinutesToPass = new List<double> {0,0},
                    TotalRegistered = 4,
                    TotalStarted = 4,
                    TotalCompleted = 4,
                    TotalPassed = 2
                }
            },
            new object[]
            {
                "-51", -11, -1,
                new KcStatisticsDto
                {
                    KcId = -11,
                    MinutesToCompletion = new List<double> { 0, 0, 0, 0 },
                    MinutesToPass = new List<double> { 0, 0 },
                    TotalRegistered = 4,
                    TotalStarted = 4,
                    TotalCompleted = 4,
                    TotalPassed = 2
                }
            },
            new object[]
            {
                "-51", -12, -1,
                new KcStatisticsDto
                {
                    KcId = -12,
                    MinutesToCompletion = new List<double>(),
                    MinutesToPass = new List<double>(),
                    TotalRegistered = 4,
                    TotalStarted = 1,
                    TotalCompleted = 0,
                    TotalPassed = 0
                }
            },
            new object[]
            {
                "-51", -13, -1,
                new KcStatisticsDto
                {
                    KcId = -13,
                    MinutesToCompletion = new List<double>(),
                    MinutesToPass = new List<double>(),
                    TotalRegistered = 4,
                    TotalStarted = 1,
                    TotalCompleted = 0,
                    TotalPassed = 0
                }
            },
            new object[]
            {
                "-51", -14, -1,
                new KcStatisticsDto
                {
                    KcId = -14,
                    MinutesToCompletion = new List<double>(),
                    MinutesToPass = new List<double>(),
                    TotalRegistered = 4,
                    TotalStarted = 0,
                    TotalCompleted = 0,
                    TotalPassed = 0
                }
            },
            new object[]
            {
                "-51", -15, -1,
                new KcStatisticsDto
                {
                    KcId = -15,
                    MinutesToCompletion = new List <double>(),
                    MinutesToPass = new List <double>(),
                    TotalRegistered = 4,
                    TotalStarted = 0,
                    TotalCompleted = 0,
                    TotalPassed = 0
                }
            },
        };
    }
}