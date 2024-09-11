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
                        SatisfiedKcStatistics = new List<InternalKcProgressStatisticsDto>
                        {
                            new()
                            {
                                KcId = -9999,
                                NegativePatterns = new List<string>
                                {
                                    "Brzanje: Proveo 0.8 minuta izučavajući gradivo pre nego što je završena komponenta.",
                                    "Pogađanje ili brzanje: Od 3 pitanja, za 67% daje pogrešan prvi odgovor u 30 sekundi od otvaranja pitanja."
                                },
                                SatisfactionTime = DateTime.UtcNow
                            }
                        }
                    }
                }
            },
            new object[]
            {
                -9998, new []{-9999, -9998}, new List<InternalKcUnitSummaryStatisticsDto>()
                {
                    new()
                    {
                        UnitId = -9999,
                        TotalCount = 2,
                        SatisfiedCount = 2,
                        SatisfiedKcStatistics = new List<InternalKcProgressStatisticsDto>
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
                                NegativePatterns = new List<string>
                                {
                                    "Brzanje: Ukupno vremena provedeno na komponenti je 6 minuta (predviđeno minimalno 8 minuta).",
                                    "Nepromišljenost: Od 1 pitanja, 100% odgovara tačno tek posle 3 ili više pokušaja."
                                },
                                SatisfactionTime = DateTime.UtcNow
                            }
                        }
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