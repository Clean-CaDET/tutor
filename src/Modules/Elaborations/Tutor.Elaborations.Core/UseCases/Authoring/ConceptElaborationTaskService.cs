using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Elaborations.API.Dtos.ConceptElaborationTasks;
using Tutor.Elaborations.API.Public;
using Tutor.Elaborations.API.Public.Authoring;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;

namespace Tutor.Elaborations.Core.UseCases.Authoring;

public class ConceptElaborationTaskService : IConceptElaborationTaskService
{
    private readonly IConceptElaborationTaskRepository _taskRepository;
    private readonly IAccessServices _accessServices;
    private readonly IElaborationsUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ConceptElaborationTaskService(
        IConceptElaborationTaskRepository taskRepository, IAccessServices accessServices,
        IElaborationsUnitOfWork unitOfWork, IMapper mapper)
    {
        _taskRepository = taskRepository;
        _accessServices = accessServices;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Result<List<ConceptElaborationTaskDto>> GetByUnit(int unitId, int instructorId)
    {
        if (!_accessServices.IsUnitOwner(unitId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        var tasks = _taskRepository.GetByUnitWithRecords(unitId);
        return Result.Ok(tasks.Select(t => _mapper.Map<ConceptElaborationTaskDto>(t)).ToList());
    }

    public Result<ConceptElaborationTaskDto> Create(ConceptElaborationTaskDto dto, int instructorId)
    {
        if (!_accessServices.IsUnitOwner(dto.UnitId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        var task = _mapper.Map<ConceptElaborationTask>(dto);
        task.UnitId = dto.UnitId;
        var created = _taskRepository.Create(task);

        var saveResult = _unitOfWork.Save();
        if (saveResult.IsFailed) return saveResult;

        return Result.Ok(_mapper.Map<ConceptElaborationTaskDto>(created));
    }

    public Result<ConceptElaborationTaskDto> Update(ConceptElaborationTaskDto dto, int instructorId)
    {
        if (!_accessServices.IsUnitOwner(dto.UnitId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        var existingTask = _taskRepository.GetWithRecord(dto.Id);
        if (existingTask == null || existingTask.UnitId != dto.UnitId)
            return Result.Fail(FailureCode.NotFound);

        existingTask.Update(_mapper.Map<ConceptElaborationTask>(dto));
        _taskRepository.Update(existingTask);

        var saveResult = _unitOfWork.Save();
        if (saveResult.IsFailed) return saveResult;

        return Result.Ok(_mapper.Map<ConceptElaborationTaskDto>(existingTask));
    }

    public Result Delete(int id, int unitId, int instructorId)
    {
        if (!_accessServices.IsUnitOwner(unitId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        var task = _taskRepository.Get(id);
        if (task == null || task.UnitId != unitId)
            return Result.Fail(FailureCode.NotFound);

        _taskRepository.Delete(task);
        return _unitOfWork.Save();
    }
}
