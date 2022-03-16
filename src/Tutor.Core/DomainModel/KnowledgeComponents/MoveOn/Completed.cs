namespace Tutor.Core.DomainModel.KnowledgeComponents.MoveOn
{
    public class Completed : IMoveOnCriteria
    {
        public bool IsSatisfied(bool isCompleted, bool isPassed)
        {
            return isCompleted;
        }
    }
}
