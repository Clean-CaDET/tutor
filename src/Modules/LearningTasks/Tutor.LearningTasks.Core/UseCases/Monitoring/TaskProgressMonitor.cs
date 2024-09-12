using FluentResults;
using Tutor.BuildingBlocks.Core.Domain.EventSourcing;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.LearningTasks.API.Dtos.TaskAnalytics;
using Tutor.LearningTasks.API.Internal;
using Tutor.LearningTasks.Core.Domain.LearningTaskProgress;
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

        var tasks = _taskRepository.GetByUnits(unitIds);
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

            var gradedIndex = orderedEvents.FindIndex(e => e is TaskGraded);
            if (gradedIndex == -1) continue;

            var eventsUpToGraded = orderedEvents.Take(gradedIndex + 1).ToList();

            taskStatistics.Add(CreateTaskStatistics(eventsUpToGraded, task));
        }

        return new InternalTaskUnitSummaryStatisticsDto
        {
            UnitId = grouping.Key,
            TotalCount = grouping.Count(),
            GradedCount = taskStatistics.Count,
            LearnerPoints = taskStatistics.Sum(s => s.WonPoints),
            GradedTaskStatistics = taskStatistics
        };
    }

    private InternalTaskProgressStatisticsDto CreateTaskStatistics(List<TaskEvent> eventsUpToGraded, LearningTask task)
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

            stats.AvgScorePerLearner = Math.Round(learnersTotalScores.Average(), 1);
            stats.TotalMaxPoints = tasks.Sum(t => t.MaxPoints);
        }
    }
}