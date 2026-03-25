using FluentResults;
using Tutor.Elaborations.API.Dtos.Conversations;

namespace Tutor.Elaborations.API.Public.Authoring;

public interface IElaborationTaskService
{
    Result<List<ElaborationTaskDto>> GetByUnit(int unitId, int instructorId);
    Result<ElaborationTaskDto> Create(ElaborationTaskDto task, int instructorId);
    Result<ElaborationTaskDto> Update(ElaborationTaskDto task, int instructorId);
    Result Delete(int id, int unitId, int instructorId);
}
