using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Elaborations.API.Dtos.Conversations;
using Tutor.Elaborations.API.Public;
using Tutor.Elaborations.API.Public.Authoring;
using Tutor.Elaborations.Core.Domain.ElaborationTasks;

namespace Tutor.Elaborations.Core.UseCases.Authoring;

public class ElaborationTaskService : CrudService<ElaborationTaskDto, ElaborationTask>, IElaborationTaskService
{
    private readonly IElaborationTaskRepository _taskRepository;
    private readonly IAccessServices _accessServices;

    public ElaborationTaskService(IElaborationTaskRepository taskRepository,
        IAccessServices accessServices, IElaborationsUnitOfWork unitOfWork,
        IMapper mapper) : base(taskRepository, unitOfWork, mapper)
    {
        _taskRepository = taskRepository;
        _accessServices = accessServices;
    }

    public Result<List<ElaborationTaskDto>> GetByUnit(int unitId, int instructorId)
    {
        if (!_accessServices.IsUnitOwner(unitId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        var tasks = _taskRepository.GetByUnit(unitId);
        return MapToDto(tasks);
    }

    public Result<ElaborationTaskDto> Create(ElaborationTaskDto task, int instructorId)
    {
        if (!_accessServices.IsUnitOwner(task.UnitId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        return Create(task);
    }

    public Result<ElaborationTaskDto> Update(ElaborationTaskDto task, int instructorId)
    {
        if (!_accessServices.IsUnitOwner(task.UnitId, instructorId))
            return Result.Fail(FailureCode.Forbidden);
        var existing = _taskRepository.Get(task.Id);
        if (existing == null || existing.UnitId != task.UnitId)
            return Result.Fail(FailureCode.NotFound);
        existing.Update(MapToDomain(task));
        return Update(existing);
    }

    public Result Delete(int id, int unitId, int instructorId)
    {
        if (!_accessServices.IsUnitOwner(unitId, instructorId))
            return Result.Fail(FailureCode.Forbidden);
        var existing = _taskRepository.Get(id);
        if (existing == null || existing.UnitId != unitId)
            return Result.Fail(FailureCode.NotFound);
        return Delete(id);
    }
}
