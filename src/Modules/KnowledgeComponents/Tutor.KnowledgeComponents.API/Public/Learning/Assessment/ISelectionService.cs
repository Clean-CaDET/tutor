using FluentResults;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems;

namespace Tutor.KnowledgeComponents.API.Public.Learning.Assessment;

public interface ISelectionService
{
    Result<AssessmentItemDto> SelectSuitableAssessmentItem(int knowledgeComponentId, int learnerId, string appClientId);
    Result<List<AssessmentItemDto>> GetAssessmentItems(int kcId, int learnerId, string appClientId);
}