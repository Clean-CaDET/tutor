using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Elaborations.API.Dtos.Conversations;
using Tutor.Elaborations.API.Public;
using Tutor.Elaborations.API.Public.Authoring;
using Tutor.Elaborations.Core.Domain.ConceptRecords;
using Tutor.Elaborations.Core.Domain.ElaborationTasks;

namespace Tutor.Elaborations.Core.UseCases.Authoring;

public class ElaborationTaskService : CrudService<ElaborationTaskDto, ElaborationTask>, IElaborationTaskService
{
    private readonly IElaborationTaskRepository _taskRepository;
    private readonly IConceptRecordRepository _conceptRecordRepository;
    private readonly IAccessServices _accessServices;

    public ElaborationTaskService(IElaborationTaskRepository taskRepository,
        IConceptRecordRepository conceptRecordRepository,
        IAccessServices accessServices, IElaborationsUnitOfWork unitOfWork,
        IMapper mapper) : base(taskRepository, unitOfWork, mapper)
    {
        _taskRepository = taskRepository;
        _conceptRecordRepository = conceptRecordRepository;
        _accessServices = accessServices;
    }

    public Result<List<ElaborationTaskDto>> GetByUnit(int unitId, int instructorId)
    {
        if (!_accessServices.IsUnitOwner(unitId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        var tasks = _taskRepository.GetByUnit(unitId);

        return Result.Ok(MapToDtos(tasks));
    }

    private List<ElaborationTaskDto> MapToDtos(List<ElaborationTask> tasks)
    {
        var taskDtos = tasks.Select(MapToDto).ToList();

        var crIds = taskDtos.Select(t => t.ConceptRecordId).Distinct().ToList();
        var titleMap = _conceptRecordRepository.GetMany(crIds)
            .ToDictionary(cr => cr.Id, cr => cr.Title);
        foreach (var dto in taskDtos)
            if (titleMap.TryGetValue(dto.ConceptRecordId, out var title))
                dto.ConceptRecordTitle = title;
        return taskDtos;
    }

    public Result<ElaborationTaskDto> Create(ElaborationTaskDto task, int instructorId)
    {
        if (!_accessServices.IsUnitOwner(task.UnitId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        var validation = ValidateConceptRecordOwnership(task.ConceptRecordId, instructorId);
        if (validation.IsFailed) return validation.ToResult<ElaborationTaskDto>();

        return Create(task);
    }

    public Result<ElaborationTaskDto> Update(ElaborationTaskDto task, int instructorId)
    {
        if (!_accessServices.IsUnitOwner(task.UnitId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        var validation = ValidateConceptRecordOwnership(task.ConceptRecordId, instructorId);
        if (validation.IsFailed) return validation.ToResult<ElaborationTaskDto>();

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

    private Result ValidateConceptRecordOwnership(int conceptRecordId, int instructorId)
    {
        var conceptRecord = _conceptRecordRepository.Get(conceptRecordId);
        if (conceptRecord == null)
            return Result.Fail(FailureCode.NotFound);
        if (!_accessServices.IsCourseOwner(conceptRecord.CourseId, instructorId))
            return Result.Fail(FailureCode.NotFound);
        return Result.Ok();
    }
}
