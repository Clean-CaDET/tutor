using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.LearningTasks.API.Dtos.LearningTaskProgress;
using Tutor.LearningTasks.API.Internal;
using Tutor.LearningTasks.API.Public;
using Tutor.LearningTasks.API.Public.Learning;
using Tutor.LearningTasks.Core.Domain.LearningTaskProgress;
using Tutor.LearningTasks.Core.Domain.LearningTasks;
using Tutor.LearningTasks.Core.Domain.RepositoryInterfaces;
using TaskStatus = Tutor.LearningTasks.Core.Domain.LearningTaskProgress.TaskStatus;

namespace Tutor.LearningTasks.Core.UseCases.Learning;

public class TaskProgressService : CrudService<TaskProgressDto, TaskProgress>, ITaskProgressService, ITaskProgressQuerier
{
    private readonly ITaskProgressRepository _progressRepository;
    private readonly IAccessServices _accessServices;
    private readonly ILearningTaskRepository _taskRepository;

    public TaskProgressService(ITaskProgressRepository progressRepository, IAccessServices accessServices,
        ILearningTaskRepository taskRepository, ILearningTasksUnitOfWork unitOfWork, IMapper mapper) : base(progressRepository, unitOfWork, mapper)
    {
        _progressRepository = progressRepository;
        _accessServices = accessServices;
        _taskRepository = taskRepository;
    }

    public Result<TaskProgressDto> GetOrCreate(int unitId, int taskId, int learnerId)
    {
        if(!_accessServices.IsEnrolledInUnit(unitId, learnerId)) 
            return Result.Fail(FailureCode.Forbidden);

        var taskProgress = _progressRepository.GetByTask(taskId, learnerId);
        if(taskProgress == null)
            return Create(taskId, learnerId);

        taskProgress.TaskOpened();
        _progressRepository.UpdateEvents(taskProgress);
        UnitOfWork.Save();

        return MapToDto(taskProgress);
    }

    private Result<TaskProgressDto> Create(int taskId, int learnerId)
    {
        var learningTask = _taskRepository.Get(taskId);
        if (learningTask == null)
            return Result.Fail(FailureCode.NotFound);
        if (learningTask.IsTemplate)
            return Result.Fail(FailureCode.Forbidden);

        TaskProgress taskProgress = new(learningTask.Steps!, learningTask.Id, learnerId);
        taskProgress.TaskOpened();
        _progressRepository.UpdateEvents(taskProgress);

        return Create(MapToDto(taskProgress));
    }

    public Result<TaskProgressDto> ViewStep(int unitId, int id, int stepId, int learnerId)
    {
        var result = GetTaskProgress(unitId, learnerId, id);
        if (result.IsFailed)
            return result.ToResult();

        var taskProgress = result.Value;
        taskProgress.ViewStep(stepId);
        _progressRepository.UpdateEvents(taskProgress);

        return Update(taskProgress);
    }

    public Result<TaskProgressDto> SubmitAnswer(int unitId, int id, StepProgressDto stepProgress, int learnerId)
    {
        var result = GetTaskProgress(unitId, learnerId, id);
        if (result.IsFailed)
            return result.ToResult();

        var taskProgress = result.Value;
        taskProgress.SubmitAnswer(stepProgress.StepId, stepProgress.Answer!);
        _progressRepository.UpdateEvents(taskProgress);

        return Update(taskProgress);
    }

    public Result OpenSubmission(int unitId, int id, int stepId, int learnerId)
    {
        return HandleNonStateChangingEvent(unitId, id, learnerId,
            taskProgress => taskProgress.OpenSubmission(stepId));
    }

    public Result OpenGuidance(int unitId, int id, int stepId, int learnerId)
    {
        return HandleNonStateChangingEvent(unitId, id, learnerId,
            taskProgress => taskProgress.OpenGuidance(stepId));
    }

    public Result OpenExample(int unitId, int id, int stepId, int learnerId)
    {
        return HandleNonStateChangingEvent(unitId, id, learnerId,
            taskProgress => taskProgress.OpenExample(stepId));
    }

    public Result PlayExampleVideo(int unitId, int id, int stepId, int learnerId, string videoUrl)
    {
        return HandleNonStateChangingEvent(unitId, id, learnerId,
            taskProgress => taskProgress.PlayExampleVideo(stepId, videoUrl));
    }

    public Result PauseExampleVideo(int unitId, int id, int stepId, int learnerId, string videoUrl)
    {
        return HandleNonStateChangingEvent(unitId, id, learnerId,
            taskProgress => taskProgress.PauseExampleVideo(stepId, videoUrl));
    }

    public Result FinishExampleVideo(int unitId, int id, int stepId, int learnerId, string videoUrl)
    {
        return HandleNonStateChangingEvent(unitId, id, learnerId,
            taskProgress => taskProgress.FinishExampleVideo(stepId, videoUrl));
    }

    private Result HandleNonStateChangingEvent(int unitId, int id, int learnerId, Action<TaskProgress> action)
    {
        var result = GetTaskProgress(unitId, learnerId, id);
        if (result.IsFailed)
            return result.ToResult();

        var taskProgress = result.Value;
        action(taskProgress);
        _progressRepository.UpdateEvents(taskProgress);

        return UnitOfWork.Save();
    }

    private Result<TaskProgress> GetTaskProgress(int unitId, int learnerId, int progressId)
    {
        if (!_accessServices.IsEnrolledInUnit(unitId, learnerId))
            return Result.Fail(FailureCode.Forbidden);

        var taskProgress = _progressRepository.Get(progressId);
        if (taskProgress == null)
            return Result.Fail(FailureCode.NotFound);

        return Result.Ok(taskProgress);
    }

    public Result<Tuple<int, int>> CountTotalAndCompleted(int unitId, int learnerId)
    {
        var tasks = _taskRepository.GetNonTemplateByUnit(unitId);
        var taskIds = tasks.Select(task => task.Id).ToList();
        var progresses = _progressRepository.GetByTasks(taskIds, learnerId);

        return new Tuple<int, int>(tasks.Count, progresses.Count(p => p.IsCompleted()));
    }

    public Result<List<int>> GetCompletedUnitIds(List<int> unitIds, int learnerId)
    {
        var tasks = _taskRepository.GetNonTemplateByUnits(unitIds);
        var taskIds = tasks.Select(t => t.Id).ToList();
        var progresses = _progressRepository.GetByTasks(taskIds, learnerId);

        var groupedTasks = tasks.GroupBy(t => t.UnitId);
        var completedUnits = unitIds.Where(id => tasks.All(t => t.UnitId != id)).ToList();
        foreach (var grouping in groupedTasks)
        {
            if(UnitIsCompleted(grouping, progresses)) completedUnits.Add(grouping.Key);
        }
        return completedUnits;
    }

    private static bool UnitIsCompleted(IGrouping<int, LearningTask> grouping, List<TaskProgress> progresses)
    {
        foreach (var task in grouping)
        {
            var matchingProgress = progresses.Find(p => p.LearningTaskId == task.Id);
            if(matchingProgress == null || !matchingProgress.IsCompleted()) return false;
        }

        return true;
    }
}
