namespace Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.MoveOn
{
    public class Passed : IMoveOnCriteria
    {
        public bool IsSatisfied(bool isCompleted, bool isPassed)
        {
            return isPassed;
        }
    }
}
