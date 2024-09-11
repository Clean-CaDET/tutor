using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.BuildingBlocks.Core.Domain.EventSourcing;
using Tutor.LearningTasks.API.Dtos.TaskAnalytics;
using Tutor.LearningTasks.Core.Domain.LearningTaskProgress.Events.TaskEvents;
using Tutor.LearningTasks.Core.Domain.RepositoryInterfaces;
using Tutor.LearningTasks.Core.UseCases.Monitoring;

namespace Tutor.LearningTasks.Tests.Integration.Monitoring;

[Collection("Sequential")]
public class TaskProgressMonitorTests : BaseLearningTasksIntegrationTest
{
    public TaskProgressMonitorTests(LearningTasksTestFactory factory) : base(factory) {}
    
    [Theory]
    [MemberData(nameof(TestData))]
    public void Identifies_task_statistics(int learnerId, int[] unitIds, int[] groupMemberIds, List<InternalTaskUnitSummaryStatisticsDto> expectedUnitStatistics)
    {
        using var scope = Factory.Services.CreateScope();
        var service = CreateService(scope);

        var actualUnitStatistics = service.GetProgress(learnerId, unitIds, groupMemberIds).Value;

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
                -9999, new []{-9999, -9998}, new []{-9999, -9998, -9997}, new List<InternalTaskUnitSummaryStatisticsDto>
                {
                    new()
                    {
                        UnitId = -9998,
                        TotalCount = 2,
                        GradedCount = 1,
                        LearnerPoints = 4,
                        AvgScorePerLearner = 2,
                        GradedTaskStatistics = new List<InternalTaskProgressStatisticsDto>
                        {
                            new()
                            {
                                TaskId = -9999,
                                WonPoints = 4,
                                NegativePatterns = new List<string>
                                {
                                    "Nedovoljan početni napor: Za 50% koraka je gledao smernice/primere u roku od 3 minuta."
                                }
                            }
                        }
                    }
                }
            }
        };
    }

    private static TaskProgressMonitor CreateService(IServiceScope scope)
    {
        return new TaskProgressMonitor(
            scope.ServiceProvider.GetRequiredService<ILearningTaskRepository>(),
            scope.ServiceProvider.GetRequiredService<ITaskProgressRepository>(),
            scope.ServiceProvider.GetRequiredService<IEventStore<TaskEvent>>());
    }
}