using FluentResults;
using Tutor.Elaborations.API.Dtos.ConceptRecords;

namespace Tutor.Elaborations.API.Public.Authoring;

public interface IConceptRecordService
{
    Result<ConceptRecordDto> Get(int id, int courseId, int instructorId);
    Result<List<ConceptRecordDto>> GetByCourse(int courseId, int instructorId);
    Result<ConceptRecordDto> Create(ConceptRecordDto conceptRecord, int instructorId);
    Result<ConceptRecordDto> Update(ConceptRecordDto conceptRecord, int instructorId);
    Result Delete(int id, int courseId, int instructorId);
}
