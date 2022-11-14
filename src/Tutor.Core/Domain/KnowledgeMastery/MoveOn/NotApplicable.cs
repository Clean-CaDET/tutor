namespace Tutor.Core.Domain.KnowledgeMastery.MoveOn
{
    public class NotApplicable : IMoveOnCriteria
    {
        public bool IsSatisfied(bool isCompleted, bool isPassed)
        {
            return true;
        }
    }
}
