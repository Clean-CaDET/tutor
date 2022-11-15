using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.Domain.Knowledge.KnowledgeComponents;
using Tutor.Core.Domain.Stakeholders;
using Tutor.Infrastructure.Database.EventStore;
using Tutor.Web.Controllers.Instructors;
using Tutor.Web.Mappings.Analytics;
using Xunit;

namespace Tutor.Web.Tests.Integration.Analytics;

[Collection("Sequential")]
public class KcStatisticsTests : BaseWebIntegrationTest
{
    public KcStatisticsTests(TutorApplicationTestFactory<Startup> factory) : base(factory) { }

    [Theory]
    [MemberData(nameof(TestData))]
    public void Retrieves_knowledge_component_statistics(string userId, int unitId, int groupId, List<KcStatisticsDto> expectedStatistics)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateAnalyticsController(scope, userId);

        var result = ((OkObjectResult)controller.GetKcStatistics(unitId, groupId).Result).Value as List<KcStatisticsDto>;

        result.ShouldNotBeNull();
        result.Count.ShouldBe(expectedStatistics.Count);
        result.All(expectedStatistics.Contains).ShouldBeTrue();
    }

    private AnalyticsController CreateAnalyticsController(IServiceScope scope, string id)
    {
        return new AnalyticsController(
            scope.ServiceProvider.GetRequiredService<ILearnerRepository>(),
            scope.ServiceProvider.GetRequiredService<IKnowledgeUnitRepository>(),
            scope.ServiceProvider.GetRequiredService<IEventStore>(),
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
                "-50", -1, -1,
                new List<KcStatisticsDto>
                {
                    new()
                    {
                        KcCode = "N00",
                        MinutesToCompletion = new List<int> {0,0,0,1},
                        MinutesToPass = new List<int> {0,1},
                        TotalRegistered = 4,
                        TotalStarted = 4,
                        TotalCompleted = 4,
                        TotalPassed = 2
                    },
                    new()
                    {
                        KcCode = "N01",
                        MinutesToCompletion = new List<int> {0,0,0,0},
                        MinutesToPass = new List<int> {0,0},
                        TotalRegistered = 4,
                        TotalStarted = 4,
                        TotalCompleted = 4,
                        TotalPassed = 2
                    },
                    new()
                    {
                        KcCode = "N02",
                        MinutesToCompletion = new List<int>(),
                        MinutesToPass = new List<int>(),
                        TotalRegistered = 4,
                        TotalStarted = 1,
                        TotalCompleted = 0,
                        TotalPassed = 0
                    },
                    new()
                    {
                        KcCode = "N03",
                        MinutesToCompletion = new List<int>(),
                        MinutesToPass = new List<int>(),
                        TotalRegistered = 4,
                        TotalStarted = 1,
                        TotalCompleted = 0,
                        TotalPassed = 0
                    },
                    new()
                    {
                        KcCode = "N04",
                        MinutesToCompletion = new List<int>(),
                        MinutesToPass = new List<int>(),
                        TotalRegistered = 4,
                        TotalStarted = 0,
                        TotalCompleted = 0,
                        TotalPassed = 0
                    },
                    new()
                    {
                        KcCode = "N05",
                        MinutesToCompletion = new List<int>(),
                        MinutesToPass = new List<int>(),
                        TotalRegistered = 4,
                        TotalStarted = 0,
                        TotalCompleted = 0,
                        TotalPassed = 0
                    }
                }
            }
        };
    }
}
