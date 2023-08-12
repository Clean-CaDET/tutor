namespace Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.MoveOn;

public class Passed : IMoveOnCriteria
{
    public bool IsSatisfied(bool isCompleted, bool isPassed)
    {
        return isPassed;
    }
}