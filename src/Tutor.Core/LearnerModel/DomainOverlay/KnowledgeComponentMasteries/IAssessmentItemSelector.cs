using System.Collections.Generic;
using FluentResults;

namespace Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries
{
    public interface IAssessmentItemSelector
    {
        Result<int> SelectSuitableAssessmentItemId(List<AssessmentItemMastery> assessmentMasteries, bool isPassed);
    }
}