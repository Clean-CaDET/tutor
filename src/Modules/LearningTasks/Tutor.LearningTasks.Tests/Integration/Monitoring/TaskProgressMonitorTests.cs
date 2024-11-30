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
                        GradedCount = 2,
                        CompletedCount = 0,
                        LearnerPoints = 8,
                        AvgGroupPoints = 3.7,
                        TotalMaxPoints = 15,
                        TaskStatistics = new List<InternalTaskProgressStatisticsDto>
                        {
                            new()
                            {
                                TaskId = -9999,
                                WonPoints = 4,
                                IsGraded = true,
                                NegativePatterns = new List<string>
                                {
                                    "Nedovoljan početni napor: Za 50% koraka je gledao smernice/primere u roku od 3 minuta."
                                }
                            },
                            new()
                            {
                                TaskId = -9998,
                                WonPoints = 4,
                                IsGraded = true,
                                NegativePatterns = new List<string>()
                            }
                        }
                    },
                    new()
                    {
                        UnitId = -9999,
                        TotalCount = 1,
                        GradedCount = 0,
                        CompletedCount = 1,
                        LearnerPoints = 0,
                        AvgGroupPoints = 0,
                        TotalMaxPoints = 1,
                        TaskStatistics = new List<InternalTaskProgressStatisticsDto>
                        {
                            new()
                            {
                                TaskId = -9997,
                                WonPoints = 0,
                                IsGraded = false,
                                NegativePatterns = new List<string>()
                            }
                        }
                    }
                }
            },
            new object[]
            {
                -9998, new []{-9998}, new []{-9999, -9998, -9997}, new List<InternalTaskUnitSummaryStatisticsDto>
                {
                    new()
                    {
                        UnitId = -9998,
                        TotalCount = 2,
                        GradedCount = 2,
                        CompletedCount = 0,
                        LearnerPoints = 3,
                        AvgGroupPoints = 3.7,
                        TotalMaxPoints = 15,
                        TaskStatistics = new List<InternalTaskProgressStatisticsDto>
                        {
                            new()
                            {
                                TaskId = -9999,
                                WonPoints = 2,
                                IsGraded = true,
                                NegativePatterns = new List<string>
                                {
                                    "Nedovoljan početni napor: Za 100% koraka je gledao smernice/primere u roku od 3 minuta.",
                                    "Neefektivno učenje: Pogledao je smernice/primere od svih koraka pre nego što je rešio bar 1 korak."
                                }
                            },
                            new()
                            {
                                TaskId = -9998,
                                WonPoints = 1,
                                IsGraded = true,
                                NegativePatterns = new List<string>()
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