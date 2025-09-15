using FluentResults;
using Tutor.BuildingBlocks.Core.Domain.EventSourcing;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.LearningTasks.API.Dtos.TaskAnalytics;
using Tutor.LearningTasks.API.Internal;
using Tutor.LearningTasks.Core.Domain.LearningTaskProgress.DomainServices;
using Tutor.LearningTasks.Core.Domain.LearningTaskProgress.Events.TaskEvents;
using Tutor.LearningTasks.Core.Domain.LearningTasks;
using Tutor.LearningTasks.Core.Domain.RepositoryInterfaces;

namespace Tutor.LearningTasks.Core.UseCases.Monitoring;

public class TaskProgressMonitor : ITaskProgressMonitor
{
    private readonly ILearningTaskRepository _taskRepository;
    private readonly ITaskProgressRepository _taskProgressRepository;
    private readonly IEventStore<TaskEvent> _eventStore;
    private readonly List<INegativePatternDetector> _negativePatternDetectors;

    public TaskProgressMonitor(ILearningTaskRepository taskRepository, ITaskProgressRepository taskProgressRepository,
        IEventStore<TaskEvent> eventStore)
    {
        _taskRepository = taskRepository;
        _taskProgressRepository = taskProgressRepository;
        _eventStore = eventStore;
        _negativePatternDetectors = new List<INegativePatternDetector>
        {
            new PatternDetectorSupport(),
            new PatternDetectorSteps()
        };
    }

    public Result<List<InternalTaskUnitSummaryStatisticsDto>> GetProgress(int learnerId, int[] unitIds, int[] groupMemberIds)
    {
        if (unitIds.Length == 0) return Result.Fail(FailureCode.NotFound);

        var tasks = _taskRepository.GetNonTemplateByUnits(unitIds);
        var taskEvents = _eventStore.GetEventsByUserAndPrimaryEntities(learnerId, tasks.Select(t => t.Id).ToHashSet());

        var unitStatistics = CalculateProgressStatistics(tasks, taskEvents);
        PopulateAverageScores(unitStatistics, tasks, groupMemberIds);
        return unitStatistics;
    }

    private List<InternalTaskUnitSummaryStatisticsDto> CalculateProgressStatistics(List<LearningTask> tasks, List<TaskEvent> events)
    {
        var groupedTasks = tasks.GroupBy(kc => kc.UnitId);
        return groupedTasks.Select(grouping => CalculateTaskProgressForUnit(grouping, events)).ToList();
    }

    private InternalTaskUnitSummaryStatisticsDto CalculateTaskProgressForUnit(IGrouping<int, LearningTask> grouping, List<TaskEvent> events)
    {
        var taskStatistics = new List<InternalTaskProgressStatisticsDto>();

        foreach (var task in grouping)
        {
            var orderedEvents = events
                .Where(e => e.TaskId == task.Id)
                .OrderBy(e => e.TimeStamp)
                .ToList();

            var completedIndex = orderedEvents.FindIndex(e => e is TaskCompleted);
            if(completedIndex == -1) continue;

            var gradedIndex = orderedEvents.FindLastIndex(e => e is TaskGraded);
            if (gradedIndex == -1)
            {
                taskStatistics.Add(new InternalTaskProgressStatisticsDto
                {
                    TaskId = task.Id,
                    CompletionTime = orderedEvents[completedIndex].TimeStamp,
                    IsGraded = false,
                    WonPoints = 0,
                    NegativePatterns = new List<string>()
                });
                continue;
            }

            var eventsUpToGraded = orderedEvents.Take(gradedIndex + 1).ToList();
            taskStatistics.Add(CreateGradedTaskStatistics(eventsUpToGraded, task));
        }

        return new InternalTaskUnitSummaryStatisticsDto
        {
            UnitId = grouping.Key,
            TotalCount = grouping.Count(),
            GradedCount = taskStatistics.Count(s => s.IsGraded),
            CompletedCount = taskStatistics.Count(s => !s.IsGraded),
            LearnerPoints = taskStatistics.Sum(s => s.WonPoints),
            TaskStatistics = taskStatistics
        };
    }

    private InternalTaskProgressStatisticsDto CreateGradedTaskStatistics(List<TaskEvent> eventsUpToGraded, LearningTask task)
    {
        var negativePatterns = new List<string>();
        foreach (var detector in _negativePatternDetectors)
        {
            negativePatterns.AddRange(detector.Detect(eventsUpToGraded, task));
        }

        return new InternalTaskProgressStatisticsDto
        {
            TaskId = task.Id,
            CompletionTime = eventsUpToGraded.Find(e => e is TaskCompleted)!.TimeStamp,
            IsGraded = true,
            WonPoints = (eventsUpToGraded[^1] as TaskGraded)!.TotalScore,
            NegativePatterns = negativePatterns
        };
    }

    private void PopulateAverageScores(List<InternalTaskUnitSummaryStatisticsDto> unitStatistics, List<LearningTask> tasks, int[] groupMemberIds)
    {
        var allProgress = _taskProgressRepository.GetByTasksAndGroup(tasks.Select(t => t.Id).ToArray(), groupMemberIds);
        foreach (var stats in unitStatistics)
        {
            var relatedTaskIds = tasks
                .Where(t => t.UnitId == stats.UnitId)
                .Select(t => t.Id).ToArray();
            var learnersTotalScores = new List<double>(groupMemberIds.Length);

            foreach (var learnerId in groupMemberIds)
            {
                var relatedScores = allProgress
                    .Where(p => relatedTaskIds.Contains(p.LearningTaskId) && p.LearnerId == learnerId)
                    .Select(p => p.TotalScore)
                    .ToList();
                learnersTotalScores.Add(relatedScores.Sum());
            }

            stats.AvgGroupPoints = Math.Round(learnersTotalScores.Average(), 1);
            stats.TotalMaxPoints = tasks.Where(t => t.UnitId == stats.UnitId).Sum(t => t.MaxPoints);
        }
    }
}