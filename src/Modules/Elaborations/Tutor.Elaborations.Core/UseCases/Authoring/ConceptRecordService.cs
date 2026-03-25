using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Elaborations.API.Dtos.ConceptRecords;
using Tutor.Elaborations.API.Public;
using Tutor.Elaborations.API.Public.Authoring;
using Tutor.Elaborations.Core.Domain.ConceptRecords;

namespace Tutor.Elaborations.Core.UseCases.Authoring;

public class ConceptRecordService : CrudService<ConceptRecordDto, ConceptRecord>, IConceptRecordService
{
    private readonly IConceptRecordRepository _conceptRecordRepository;
    private readonly IAccessServices _accessServices;

    public ConceptRecordService(IConceptRecordRepository repository,
        IAccessServices accessServices, IElaborationsUnitOfWork unitOfWork,
        IMapper mapper) : base(repository, unitOfWork, mapper)
    {
        _conceptRecordRepository = repository;
        _accessServices = accessServices;
    }

    public Result<ConceptRecordDto> Get(int id, int courseId, int instructorId)
    {
        if (!_accessServices.IsCourseOwner(courseId, instructorId))
            return Result.Fail(FailureCode.Forbidden);
        var record = _conceptRecordRepository.Get(id);
        if (record == null || record.CourseId != courseId)
            return Result.Fail(FailureCode.NotFound);
        return MapToDto(record);
    }

    public Result<List<ConceptRecordDto>> GetByCourse(int courseId, int instructorId)
    {
        if (!_accessServices.IsCourseOwner(courseId, instructorId))
            return Result.Fail(FailureCode.Forbidden);
        var records = _conceptRecordRepository.GetByCourse(courseId);
        return MapToDto(records);
    }

    public Result<ConceptRecordDto> Create(ConceptRecordDto conceptRecord, int instructorId)
    {
        if (!_accessServices.IsCourseOwner(conceptRecord.CourseId, instructorId))
            return Result.Fail(FailureCode.Forbidden);
        return Create(conceptRecord);
    }

    public Result<ConceptRecordDto> Update(ConceptRecordDto conceptRecord, int instructorId)
    {
        if (!_accessServices.IsCourseOwner(conceptRecord.CourseId, instructorId))
            return Result.Fail(FailureCode.Forbidden);
        return Update(conceptRecord);
    }

    public Result Delete(int id, int courseId, int instructorId)
    {
        if (!_accessServices.IsCourseOwner(courseId, instructorId))
            return Result.Fail(FailureCode.Forbidden);
        var record = _conceptRecordRepository.Get(id);
        if (record == null || record.CourseId != courseId)
            return Result.Fail(FailureCode.NotFound);
        return Delete(id);
    }
}
