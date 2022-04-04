namespace Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.MoveOn
{
    public class CompletedAndPassed : IMoveOnCriteria
    {
        public bool IsSatisfied(bool isCompleted, bool isPassed)
        {
            return isCompleted && isPassed;
        }
    }
}
