namespace Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.MoveOn
{
    public class Completed : IMoveOnCriteria
    {
        public bool IsSatisfied(bool isCompleted, bool isPassed)
        {
            return isCompleted;
        }
    }
}
