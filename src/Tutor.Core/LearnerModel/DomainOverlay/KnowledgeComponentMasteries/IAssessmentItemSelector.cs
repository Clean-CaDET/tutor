using System.Collections.Generic;
using Tutor.Core.DomainModel.AssessmentItems;

namespace Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries
{
    public interface IAssessmentItemSelector
    {
        AssessmentItem SelectSuitableAssessmentItem(List<AssessmentItem> itemsWithSubmissions);
    }
}