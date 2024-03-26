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

        TaskProgress? taskProgress = _progressRepository.GetByTaskIdAndLearnerId(taskId, learnerId);
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

        TaskProgress taskProgress = new(learningTask.Id, learnerId);
        taskProgress.CreateStepProgresses(learningTask.Steps!);
        return Create(MapToDto(taskProgress));
    }

    public Result<TaskProgressDto> ViewStep(int unitId, int id, int stepId, int learnerId)
    {
        if (!_accessServices.IsEnrolledInUnit(unitId, learnerId))
            return Result.Fail(FailureCode.Forbidden);

        TaskProgress? taskProgress = _progressRepository.Get(id);
        if (taskProgress == null)
            return Result.Fail(FailureCode.NotFound);

        taskProgress.ViewStep(stepId);
        return Update(taskProgress);
    }

    public Result<TaskProgressDto> SubmitAnswer(int unitId, int id, StepProgressDto stepProgress, int learnerId)
    {
        if (!_accessServices.IsEnrolledInUnit(unitId, learnerId))
            return Result.Fail(FailureCode.Forbidden);

        TaskProgress? taskProgress = _progressRepository.Get(id);
        if (taskProgress == null)
            return Result.Fail(FailureCode.NotFound);

        taskProgress.SubmitAnswer(stepProgress.StepId, stepProgress.Answer!);
        return Update(taskProgress);
    }
}
