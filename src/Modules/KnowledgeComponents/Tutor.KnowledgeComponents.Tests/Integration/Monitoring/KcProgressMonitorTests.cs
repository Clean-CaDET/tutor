using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.BuildingBlocks.Core.Domain.EventSourcing;
using Tutor.KnowledgeComponents.API.Dtos.KnowledgeAnalytics;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.RepositoryInterfaces;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.Events;
using Tutor.KnowledgeComponents.Core.UseCases.Monitoring;

namespace Tutor.KnowledgeComponents.Tests.Integration.Monitoring;

[Collection("Sequential")]
public class KcProgressMonitorTests : BaseKnowledgeComponentsIntegrationTest
{
    public KcProgressMonitorTests(KnowledgeComponentsTestFactory factory) : base(factory) {}
    
    [Theory]
    [MemberData(nameof(TestData))]
    public void Identifies_kc_statistics(int learnerId, int[] unitIds, List<InternalKcUnitSummaryStatisticsDto> expectedUnitStatistics)
    {
        using var scope = Factory.Services.CreateScope();
        var service = CreateService(scope);

        var actualUnitStatistics = service.GetProgress(learnerId, unitIds).Value;

        actualUnitStatistics.ShouldNotBeNull();
        actualUnitStatistics.Count.ShouldBe(expectedUnitStatistics.Count);
        actualUnitStatistics.All(expectedUnitStatistics.Contains).ShouldBeTrue();
    }

    public static IEnumerable<object[]> TestData()
    {
        return new List<object[]>
        {
            new object[]
            {
                -9999, new []{-9999, -9998}, new List<InternalKcUnitSummaryStatisticsDto>()
                {
                    new()
                    {
                        UnitId = -9999,
                        TotalCount = 2,
                        SatisfiedCount = 1,
                        KcProgressStatistics = new List<InternalKcProgressStatisticsDto>
                        {
                            new()
                            {
                                KcId = -9999,
                                NegativePatterns = new List<string>(),
                                SatisfactionTime = DateTime.UtcNow
                            },
                            new()
                            {
                                KcId = -9998,
                                NegativePatterns = new List<string>(),
                                SatisfactionTime = DateTime.UtcNow
                            }
                        }
                    },
                    new()
                    {
                        UnitId = -9998,
                        TotalCount = 0,
                        SatisfiedCount = 0,
                        KcProgressStatistics = new List<InternalKcProgressStatisticsDto>()
                    }
                }
            }
        };
    }

    private static KcProgressMonitor CreateService(IServiceScope scope)
    {
        return new KcProgressMonitor(
            scope.ServiceProvider.GetRequiredService<IKnowledgeComponentRepository>(),
            scope.ServiceProvider.GetRequiredService<IEventStore<KnowledgeComponentEvent>>());
    }
}