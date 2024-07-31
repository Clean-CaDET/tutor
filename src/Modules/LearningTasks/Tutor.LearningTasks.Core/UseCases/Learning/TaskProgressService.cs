using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.LearningTasks.API.Dtos.LearningTaskProgress;
using Tutor.LearningTasks.API.Public;
using Tutor.LearningTasks.API.Public.Learning;
using Tutor.LearningTasks.Core.Domain.LearningTaskProgress;
using Tutor.LearningTasks.Core.Domain.RepositoryInterfaces;

namespace Tutor.LearningTasks.Core.UseCases.Learning;

public class TaskProgressService : CrudService<TaskProgressDto, TaskProgress>, ITaskProgressService
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

        var taskProgress = _progressRepository.GetByTaskAndLearner(taskId, learnerId);
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
        return HandleNonStateChangingEvent(unitId, id, stepId, learnerId,
            (taskProgress, step) => taskProgress.OpenSubmission(step));
    }

    public Result OpenGuidance(int unitId, int id, int stepId, int learnerId)
    {
        return HandleNonStateChangingEvent(unitId, id, stepId, learnerId,
            (taskProgress, step) => taskProgress.OpenGuidance(step));
    }

    public Result OpenExample(int unitId, int id, int stepId, int learnerId)
    {
        return HandleNonStateChangingEvent(unitId, id, stepId, learnerId,
            (taskProgress, step) => taskProgress.OpenExample(step));
    }

    public Result PlayExampleVideo(int unitId, int id, int stepId, int learnerId, string videoUrl)
    {
        return HandeVideoEvent(unitId, id, stepId, learnerId, videoUrl,
             (taskProgress, stepId, videoUrl) => taskProgress.PlayExampleVideo(stepId, videoUrl));
    }

    public Result PauseExampleVideo(int unitId, int id, int stepId, int learnerId, string videoUrl)
    {
        return HandeVideoEvent(unitId, id, stepId, learnerId, videoUrl,
             (taskProgress, stepId, videoUrl) => taskProgress.PauseExampleVideo(stepId, videoUrl));
    }

    public Result FinishExampleVideo(int unitId, int id, int stepId, int learnerId, string videoUrl)
    {
        return HandeVideoEvent(unitId, id, stepId, learnerId,videoUrl,
            (taskProgress, stepId, videoUrl) => taskProgress.FinishExampleVideo(stepId, videoUrl));
    }

    private Result HandeVideoEvent(int unitId, int id, int stepId, int learnerId, string videoUrl, Action<TaskProgress, int, string> action)
    {
        var result = GetTaskProgress(unitId, learnerId, id);
        if (result.IsFailed)
            return result.ToResult();

        var taskProgress = result.Value;
        action(taskProgress, stepId, videoUrl);
        _progressRepository.UpdateEvents(taskProgress);

        return UnitOfWork.Save();
    }

    private Result HandleNonStateChangingEvent(int unitId, int id, int stepId, int learnerId, Action<TaskProgress, int> action)
    {
        var result = GetTaskProgress(unitId, learnerId, id);
        if (result.IsFailed)
            return result.ToResult();

        var taskProgress = result.Value;
        action(taskProgress, stepId);
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
}
