using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.LearningTasks.API.Dtos.LearningTaskProgress;
using Tutor.LearningTasks.API.Public;
using Tutor.LearningTasks.API.Public.Learning;
using Tutor.LearningTasks.Core.Domain.LearningTaskProgress;
using Tutor.LearningTasks.Core.Domain.LearningTasks;
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

        TaskProgress? taskProgress = _progressRepository.GetByTaskAndLearner(taskId, learnerId);
        if(taskProgress == null)
        {
            return Create(taskId, learnerId);
        }
        return MapToDto(taskProgress);
    }

    private Result<TaskProgressDto> Create(int taskId, int learnerId)
    {
        LearningTask? learningTask = _taskRepository.Get(taskId);
        if (learningTask == null)
            return Result.Fail(FailureCode.NotFound);

        TaskProgress taskProgress = new(learningTask.Steps!, learningTask.Id, learnerId);
        return Create(MapToDto(taskProgress));
    }

    public Result<TaskProgressDto> ViewStep(int unitId, int id, int stepId, int learnerId)
    {
        Result<TaskProgress> result = GetTaskProgress(unitId, learnerId, id);
        if (result.IsFailed)
            return result.ToResult();

        TaskProgress taskProgress = result.Value;
        taskProgress.ViewStep(stepId);
        return Update(taskProgress);
    }

    public Result<TaskProgressDto> SubmitAnswer(int unitId, int id, StepProgressDto stepProgress, int learnerId)
    {
        Result<TaskProgress> result = GetTaskProgress(unitId, learnerId, id);
        if (result.IsFailed)
            return result.ToResult();

        TaskProgress taskProgress = result.Value;
        taskProgress.SubmitAnswer(stepProgress.StepId, stepProgress.Answer!);
        return Update(taskProgress);
    }

    private Result<TaskProgress> GetTaskProgress(int unitId, int learnerId, int progressId)
    {
        if (!_accessServices.IsEnrolledInUnit(unitId, learnerId))
            return Result.Fail(FailureCode.Forbidden);

        TaskProgress? taskProgress = _progressRepository.Get(progressId);
        if (taskProgress == null)
            return Result.Fail(FailureCode.NotFound);

        return Result.Ok(taskProgress);
    }
}
