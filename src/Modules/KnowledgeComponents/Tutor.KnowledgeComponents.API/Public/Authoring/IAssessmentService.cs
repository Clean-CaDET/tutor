using FluentResults;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems;

namespace Tutor.KnowledgeComponents.API.Public.Authoring;

public interface IAssessmentService
{
    Result<List<AssessmentItemDto>> GetByKc(int kcId, int instructorId);
    Result<AssessmentItemDto> Create(AssessmentItemDto item, int instructorId);
    Result<AssessmentItemDto> Update(AssessmentItemDto item, int instructorId);
    Result<List<AssessmentItemDto>> UpdateOrdering(List<AssessmentItemDto> items, int instructorId);
    Result Delete(int id, int kcId, int instructorId);
}