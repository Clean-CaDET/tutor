using FluentResults;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Tutor.BuildingBlocks.Core.Domain.EventSourcing;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.LearningTasks.API.Dtos.TaskAnalytics;
using Tutor.LearningTasks.API.Internal;
using Tutor.LearningTasks.Core.Domain.LearningTaskProgress;
using Tutor.LearningTasks.Core.Domain.LearningTaskProgress.Events;
using Tutor.LearningTasks.Core.Domain.LearningTaskProgress.Events.TaskProgressEvents;
using Tutor.LearningTasks.Core.Domain.LearningTasks;
using Tutor.LearningTasks.Core.Domain.RepositoryInterfaces;

namespace Tutor.LearningTasks.Core.UseCases.Monitoring;

public class TaskProgressMonitor : ITaskProgressMonitor
{

    private readonly ILearningTaskRepository _taskRepository;
    private readonly ITaskProgressRepository _taskProgressRepository;
    private readonly IEventStore<TaskProgressEvent> _eventStore;

    public TaskProgressMonitor(ILearningTaskRepository taskRepository, ITaskProgressRepository taskProgressRepository,
        IEventStore<TaskProgressEvent> eventStore)
    {
        _taskRepository = taskRepository;
        _taskProgressRepository = taskProgressRepository;
        _eventStore = eventStore;
    }

    public Result<List<InternalTaskUnitSummaryStatisticsDto>> GetProgress(int learnerId, int[] unitIds, int[] groupMemberIds)
    {
        if (unitIds.Length == 0) return Result.Fail(FailureCode.NotFound);

        var tasks = _taskRepository.GetByUnits(unitIds);
        var taskIds = tasks.Select(kc => kc.Id).ToArray();
        var progresses = _taskProgressRepository.GetByTasksAndGroup(taskIds, groupMemberIds);

        var taskEvents = _eventStore.GetEventsByUserAndPrimaryEntities(learnerId, taskIds.ToHashSet());

        return CalculateProgressStatistics(tasks, progresses, taskEvents);
    }

    private static List<InternalTaskUnitSummaryStatisticsDto> CalculateProgressStatistics(List<LearningTask> tasks,
        List<TaskProgress> progresses, List<TaskProgressEvent> events)
    {
        var groupedKcs = tasks.GroupBy(kc => kc.UnitId);
        return groupedKcs.Select(grouping => CalculateTaskProgressForUnit(grouping, progresses, events)).ToList();
    }

    private static InternalTaskUnitSummaryStatisticsDto CalculateTaskProgressForUnit(IGrouping<int, LearningTask> grouping, List<TaskProgress> progresses, List<TaskProgressEvent> events)
    {
        var taskStatistics = new List<InternalTaskProgressStatisticsDto>();

        foreach (var task in grouping)
        {
            var orderedEvents = events
                .Where(e => e.LearningTaskId == task.Id)
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
            AvgScorePerLearner = CalculateAvgScorePerLearner(progresses),
            GradedCount = taskStatistics.Count,
            LearnerPoints = taskStatistics.Sum(s => s.WonPoints),
            TaskStatistics = taskStatistics
        };
    }

    private static InternalTaskProgressStatisticsDto CreateTaskStatistics(List<TaskProgressEvent> eventsUpToGraded, LearningTask task)
    {
        var negativePatterns = new List<string>();

        return new InternalTaskProgressStatisticsDto
        {
            TaskId = task.Id,
            CompletionTime = eventsUpToGraded.Find(e => e is TaskCompleted)!.TimeStamp,
            WonPoints = (eventsUpToGraded[^1] as TaskGraded)!.TotalScore,
            NegativePatterns = negativePatterns
        };
    }

    private static double CalculateAvgScorePerLearner(List<TaskProgress> progresses)
    {
        return progresses.GroupBy(p => p.LearnerId).Average(g => g.Sum(p => p.TotalScore));
    }
}