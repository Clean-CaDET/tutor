using System.Collections.Generic;

namespace Tutor.Core.DomainModel.AssessmentItems
{
    public interface IAssessmentItemRepository
    {
        AssessmentItem GetDerivedAssessmentItem(int assessmentItemId);

        public List<AssessmentItem> GetAssessmentItemsByKnowledgeComponent(int id);

        public List<AssessmentItem> GetAssessmentItemsWithLearnerSubmissions(int knowledgeComponentId,
            int learnerId);

        Submission FindSubmissionWithMaxCorrectness(int assessmentItemId, int learnerId);
    }
}