namespace Tutor.Core.DomainModel.KnowledgeComponents.MoveOn
{
    public interface IMoveOnCriteria
    {
        bool IsSatisfied(bool isCompleted, bool isPassed);
    }
}
