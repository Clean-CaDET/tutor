using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.LearningTasks.API.Dtos.LearningTasks;
using Tutor.LearningTasks.API.Public;
using Tutor.LearningTasks.API.Public.Authoring;
using Tutor.LearningTasks.Core.Domain.LearningTasks;
using Tutor.LearningTasks.Core.Domain.RepositoryInterfaces;

namespace Tutor.LearningTasks.Core.UseCases.Authoring;

public class ActivityService :  IActivityService
{
    private readonly ILearningTaskRepository _learningTaskRepository;
    private readonly IAccessServices _accessServices;
    private readonly ILearningTasksUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ActivityService(ILearningTaskRepository learningTaskRepository, IAccessServices accessServices,
        ILearningTasksUnitOfWork unitOfWork, IMapper mapper)
    {
        _learningTaskRepository = learningTaskRepository;
        _accessServices = accessServices;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Result<ActivityDto> Create(ActivityDto activity, int learningTaskId,  int instructorId)
    {
        if (!_accessServices.IsUnitOwner(activity.UnitId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        LearningTask? learningTask = _learningTaskRepository.Get(learningTaskId);
        if (learningTask == null)
            return Result.Fail<ActivityDto>(FailureCode.NotFound);

        learningTask.AddStep(_mapper.Map<Activity>(activity));
        LearningTask updatedLearningTask = _learningTaskRepository.Update(learningTask);
        var result = _unitOfWork.Save();

        return result.IsFailed ? result : _mapper.Map<ActivityDto>(updatedLearningTask.GetStep(activity.Code));
    }

    public Result<ActivityDto> Update(ActivityDto activity, int learningTaskId, int instructorId)
    {
        if (!_accessServices.IsUnitOwner(activity.UnitId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        LearningTask? learningTask = _learningTaskRepository.Get(learningTaskId);
        if (learningTask == null)
            return Result.Fail<ActivityDto>(FailureCode.NotFound);

        learningTask.UpdateStep(_mapper.Map<Activity>(activity));
        LearningTask updatedLearningTask = _learningTaskRepository.Update(learningTask);
        var result = _unitOfWork.Save();

        return result.IsFailed ? result : _mapper.Map<ActivityDto>(updatedLearningTask.GetStep(activity.Code));
    }

    public Result Delete(int id, int unitId, int learningTaskId, int instructorId)
    {
        if (!_accessServices.IsUnitOwner(unitId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        LearningTask? learningTask = _learningTaskRepository.Get(learningTaskId);
        if (learningTask == null)
            return Result.Fail(FailureCode.NotFound);

        learningTask.RemoveStep(id);
        _learningTaskRepository.Update(learningTask);
        _unitOfWork.Save();

        return Result.Ok();
    }
}
