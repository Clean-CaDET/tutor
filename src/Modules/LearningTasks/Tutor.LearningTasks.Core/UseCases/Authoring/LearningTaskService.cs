using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.LearningTasks.API.Dtos.LearningTasks;
using Tutor.LearningTasks.API.Public;
using Tutor.LearningTasks.API.Public.Authoring;
using Tutor.LearningTasks.Core.Domain.LearningTasks;
using Tutor.LearningTasks.Core.Domain.RepositoryInterfaces;

namespace Tutor.LearningTasks.Core.UseCases.Authoring;

public class LearningTaskService : CrudService<LearningTaskDto, LearningTask>, ILearningTaskService
{
    private readonly ILearningTaskRepository _learningTaskRepository;
    private readonly IAccessServices _accessServices;

    public LearningTaskService(ILearningTaskRepository learningTaskRepository, IAccessServices accessServices,
        ILearningTasksUnitOfWork unitOfWork, IMapper mapper) : base(learningTaskRepository, unitOfWork, mapper)
    {
        _learningTaskRepository = learningTaskRepository;
        _accessServices = accessServices;
    }

    public new Result<LearningTaskDto> Get(int id, int unitId,  int instructorId)
    {
        if (!_accessServices.IsUnitOwner(unitId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

       return Get(id);
    }

    public Result<List<LearningTaskDto>> GetByUnit(int unitId, int instructorId)
    {
        if (!_accessServices.IsUnitOwner(unitId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        List<LearningTask> learningTasks = _learningTaskRepository.GetUnitLearningTasks(unitId);
        return MapToDto(learningTasks);
    }

    public Result<LearningTaskDto> Create(LearningTaskDto learningTask, int instructorId)
    {
        if (!_accessServices.IsUnitOwner(learningTask.UnitId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        return Create(learningTask);
    }

    public Result<LearningTaskDto> Update(LearningTaskDto learningTask, int instructorId)
    {
        if (!_accessServices.IsUnitOwner(learningTask.UnitId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        LearningTask? existingLearningTask = _learningTaskRepository.Get(learningTask.Id);
        if (existingLearningTask == null)
            return Result.Fail(FailureCode.NotFound);

        existingLearningTask.Update(MapToDomain(learningTask));

        return Update(existingLearningTask);
    }

    public Result Delete(int id, int unitId, int instructorId)
    {
        if(!_accessServices.IsUnitOwner(unitId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        return Delete(id);
    }
}