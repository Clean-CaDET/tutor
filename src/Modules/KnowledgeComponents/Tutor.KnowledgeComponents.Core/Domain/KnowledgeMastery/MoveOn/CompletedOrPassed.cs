﻿namespace Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.MoveOn;

public class CompletedOrPassed : IMoveOnCriteria
{
    public bool IsSatisfied(bool isCompleted, bool isPassed)
    {
        return isCompleted || isPassed;
    }
}