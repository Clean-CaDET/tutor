using FluentResults;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems;

namespace Tutor.KnowledgeComponents.API.Interfaces.Learning.Assessment;

public interface ISelectionService
{
    Result<AssessmentItemDto> SelectSuitableAssessmentItem(int knowledgeComponentId, int learnerId);
}