using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.LearningTasks.API.Dtos.LearningTasks;
using Tutor.LearningTasks.API.Internal;
using Tutor.LearningTasks.API.Public;
using Tutor.LearningTasks.API.Public.Authoring;
using Tutor.LearningTasks.Core.Domain.LearningTasks;
using Tutor.LearningTasks.Core.Domain.RepositoryInterfaces;

namespace Tutor.LearningTasks.Core.UseCases.Authoring;

public class LearningTaskService : CrudService<LearningTaskDto, LearningTask>, ILearningTaskService, ILearningTaskCloner
{
    private readonly ILearningTaskRepository _taskRepository;
    private readonly IAccessServices _accessServices;

    public LearningTaskService(ILearningTaskRepository taskRepository, IAccessServices accessServices,
        ILearningTasksUnitOfWork unitOfWork, IMapper mapper) : base(taskRepository, unitOfWork, mapper)
    {
        _taskRepository = taskRepository;
        _accessServices = accessServices;
    }

    public Result<LearningTaskDto> Get(int id, int unitId,  int instructorId)
    {
        if (!_accessServices.IsUnitOwner(unitId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        return Get(id);
    }

    public Result<List<LearningTaskDto>> GetByUnit(int unitId, int instructorId)
    {
        if (!_accessServices.IsUnitOwner(unitId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        List<LearningTask> learningTasks = _taskRepository.GetForUnit(unitId);
        return MapToDto(learningTasks);
    }

    public Result<LearningTaskDto> Create(LearningTaskDto learningTask, int instructorId)
    {
        if (!_accessServices.IsUnitOwner(learningTask.UnitId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        return Create(learningTask);
    }

    public Result<LearningTaskDto> Clone(LearningTaskDto taskHeader, int instructorId)
    {
        if (!_accessServices.IsUnitOwner(taskHeader.UnitId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        var oldTask = _taskRepository.Get(taskHeader.Id);
        if (oldTask == null) return Result.Fail(FailureCode.NotFound);

        UnitOfWork.BeginTransaction();
        var result = CloneTask(taskHeader, oldTask);
        if (result.IsFailed)
        {
            UnitOfWork.Rollback();
            return result;
        }
        UnitOfWork.Commit();

        return result;
    }

    private Result<LearningTaskDto> CloneTask(LearningTaskDto taskHeader, LearningTask oldTask)
    {
        var clonedTask = oldTask.Clone(taskHeader.UnitId);
        clonedTask.UpdateHeader(taskHeader.Name, taskHeader.Description, taskHeader.IsTemplate);

        clonedTask = _taskRepository.Create(clonedTask);
        var result = UnitOfWork.Save();
        if (result.IsFailed) return result;

        clonedTask.LinkActivityParents(oldTask);
        result = UnitOfWork.Save();
        if (result.IsFailed) return result;

        return MapToDto(clonedTask);
    }

    public Result<LearningTaskDto> Update(LearningTaskDto learningTask, int instructorId)
    {
        if (!_accessServices.IsUnitOwner(learningTask.UnitId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        LearningTask? existingLearningTask = _taskRepository.Get(learningTask.Id);
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
    
    public Result CloneMany(List<Tuple<int, int>> unitIdPairs)
    {
        var oldTasks = _taskRepository.GetForUnits(unitIdPairs.Select(u => u.Item1).ToList());

        UnitOfWork.BeginTransaction();

        var result = CloneTasks(oldTasks, unitIdPairs);

        if (result.IsFailed)
        {
            UnitOfWork.Rollback();
            return result;
        }

        UnitOfWork.Commit();

        return result;
    }

    private Result CloneTasks(List<LearningTask> oldTasks, List<Tuple<int, int>> unitIdPairs)
    {
        var clonedTasks = oldTasks
            .Select(t => t.Clone(
                unitIdPairs.Find(pair => pair.Item1 == t.UnitId)!.Item2))
            .ToList();

        clonedTasks = _taskRepository.BulkCreate(clonedTasks);
        var result = UnitOfWork.Save();
        if (result.IsFailed) return result;

        LinkActivityParents(clonedTasks, oldTasks);
        return UnitOfWork.Save();
    }

    private static void LinkActivityParents(List<LearningTask> clonedTasks, List<LearningTask> oldTasks)
    {
        for (var i = 0; i < oldTasks.Count; i++)
        {
            if (oldTasks[i].Steps == null) continue;
            clonedTasks[i].LinkActivityParents(oldTasks[i]);
        }
    }
}