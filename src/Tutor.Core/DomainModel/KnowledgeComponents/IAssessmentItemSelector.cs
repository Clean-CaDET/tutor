using FluentResults;
using Tutor.Core.DomainModel.AssessmentItems;

namespace Tutor.Core.DomainModel.KnowledgeComponents
{
    public interface IAssessmentItemSelector
    {
        Result<AssessmentItem> SelectSuitableAssessmentItem(int knowledgeComponentId, int learnerId);
    }
}