namespace Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.MoveOn
{
    public class NotApplicable : IMoveOnCriteria
    {
        public bool IsSatisfied(bool isCompleted, bool isPassed)
        {
            return true;
        }
    }
}
