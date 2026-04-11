using FluentResults;
using Tutor.Elaborations.API.Dtos.ConceptElaborationTasks;

namespace Tutor.Elaborations.API.Public.Authoring;

public interface IConceptElaborationTaskService
{
    Result<ConceptElaborationTaskDto> Get(int id, int unitId, int instructorId);
    Result<List<ConceptElaborationTaskSummaryDto>> GetByUnit(int unitId, int instructorId);
    Result<ConceptElaborationTaskDto> Create(ConceptElaborationTaskDto task, int instructorId);
    Result<ConceptElaborationTaskDto> Update(ConceptElaborationTaskDto task, int instructorId);
    Result Delete(int id, int unitId, int instructorId);
}
