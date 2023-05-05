using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Collections.Generic;
using Tutor.Core.UseCases.KnowledgeAnalysis;
using Tutor.Web.Controllers.Instructors.Analytics;
using Tutor.Web.Mappings.Analytics;
using Xunit;

namespace Tutor.Web.Tests.Integration.KnowledgeAnalysis;

[Collection("Sequential")]
public class KnowledgeAnalysisTests : BaseWebIntegrationTest
{
    public KnowledgeAnalysisTests(TutorApplicationTestFactory<Startup> factory) : base(factory) { }

    [Theory]
    [MemberData(nameof(TestData))]
    public void Retrieves_kc_statistics_for_group(string userId, int kcId, int groupId, KcStatisticsDto expectedStatistics)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupAnalysisController(scope, userId);

        var result = ((OkObjectResult)controller.GetStatisticsForGroup(kcId, groupId).Result).Value as KcStatisticsDto;

        result.ShouldNotBeNull();
        result.ShouldBe(expectedStatistics);
    }

    [Theory]
    [InlineData("-51", -10)]
    public void Retrieves_kc_statistics(string userId, int kcId)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupAnalysisController(scope, userId);

        var result = ((OkObjectResult)controller.GetStatistics(kcId).Result).Value as KcStatisticsDto;

        result.ShouldNotBeNull();
    }

    [Theory]
    [InlineData("-51", -3)]
    public void Retrieves_kc_statistics_fails_instructor_not_course_owner(string userId, int unitId)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupAnalysisController(scope, userId);

        var result = (ObjectResult)controller.GetStatistics(unitId).Result;

        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(403);
    }

    private KnowledgeAnalysisController SetupAnalysisController(IServiceScope scope, string id)
    {
        return new KnowledgeAnalysisController(
            scope.ServiceProvider.GetRequiredService<IKnowledgeAnalysisService>(),
            Factory.Services.GetRequiredService<IMapper>())
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