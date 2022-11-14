using FluentResults;
using Tutor.Core.Domain.Knowledge.AssessmentItems;

namespace Tutor.Core.UseCases.Learning.Assessment
{
    public interface ISelectionService
    {
        Result<AssessmentItem> SelectSuitableAssessmentItem(int knowledgeComponentId, int learnerId);
    }
}
