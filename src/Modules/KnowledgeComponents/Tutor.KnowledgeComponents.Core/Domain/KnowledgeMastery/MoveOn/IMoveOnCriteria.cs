namespace Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.MoveOn;

public interface IMoveOnCriteria
{
    bool IsSatisfied(bool isCompleted, bool isPassed);
}