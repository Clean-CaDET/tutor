namespace Tutor.Core.DomainModel.KnowledgeComponents.MoveOn
{
    public class NotApplicable : IMoveOnCriteria
    {
        public bool IsSatisfied(bool isCompleted, bool isPassed)
        {
            return true;
        }
    }
}
