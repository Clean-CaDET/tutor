namespace Tutor.Core.DomainModel.KnowledgeComponents.MoveOn
{
    public class Passed : IMoveOnCriteria
    {
        public bool IsSatisfied(bool isCompleted, bool isPassed)
        {
            return isPassed;
        }
    }
}
