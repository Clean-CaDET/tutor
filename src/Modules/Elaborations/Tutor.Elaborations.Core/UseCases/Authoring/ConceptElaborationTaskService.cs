using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Elaborations.API.Dtos.ConceptElaborationTasks;
using Tutor.Elaborations.API.Public;
using Tutor.Elaborations.API.Public.Authoring;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;

namespace Tutor.Elaborations.Core.UseCases.Authoring;

public class ConceptElaborationTaskService :
    CrudService<ConceptElaborationTaskDto, ConceptElaborationTask>, IConceptElaborationTaskService
{
    private readonly IConceptElaborationTaskRepository _taskRepository;
    private readonly IAccessServices _accessServices;

    public ConceptElaborationTaskService(IConceptElaborationTaskRepository repository,
        IAccessServices accessServices, IElaborationsUnitOfWork unitOfWork,
        IMapper mapper) : base(repository, unitOfWork, mapper)
    {
        _taskRepository = repository;
        _accessServices = accessServices;
    }

    public Result<List<ConceptElaborationTaskDto>> GetByUnit(int unitId, int instructorId)
    {
        if (!_accessServices.IsUnitOwner(unitId, instructorId))
            return Result.Fail(FailureCode.Forbidden);
        var tasks = _taskRepository.GetByUnit(unitId);
        return MapToDto(tasks);
    }

    public Result<ConceptElaborationTaskDto> Create(ConceptElaborationTaskDto task, int instructorId)
    {
        if (!_accessServices.IsUnitOwner(task.UnitId, instructorId))
            return Result.Fail(FailureCode.Forbidden);
        return Create(task);
    }

    public Result<ConceptElaborationTaskDto> Update(ConceptElaborationTaskDto task, int instructorId)
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
        var task = _taskRepository.Get(id);
        if (task == null || task.UnitId != unitId)
            return Result.Fail(FailureCode.NotFound);
        return Delete(id);
    }
}
