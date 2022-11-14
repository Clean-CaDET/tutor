namespace Tutor.Core.Domain.KnowledgeMastery.MoveOn
{
    public class Completed : IMoveOnCriteria
    {
        public bool IsSatisfied(bool isCompleted, bool isPassed)
        {
            return isCompleted;
        }
    }
}
