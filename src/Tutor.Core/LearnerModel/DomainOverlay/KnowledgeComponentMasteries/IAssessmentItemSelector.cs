using System.Collections.Generic;
using FluentResults;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.AssessmentItemMasteries;

namespace Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries
{
    public interface IAssessmentItemSelector
    {
        Result<int> SelectSuitableAssessmentItemId(List<AssessmentItemMastery> assessmentMasteries, bool isPassed);
    }
}