namespace Tutor.Core.DomainModel.KnowledgeComponents.MoveOn
{
    public class CompletedOrPassed : IMoveOnCriteria
    {
        public bool IsSatisfied(bool isCompleted, bool isPassed)
        {
            return isCompleted || isPassed;
        }
    }
}
