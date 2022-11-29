using System;
using System.Collections.Generic;
using Tutor.Core.BuildingBlocks;

namespace Tutor.Core.Domain.Knowledge.AssessmentItems.ArrangeTasks;

public class ArrangeTaskContainerEvaluation : ValueObject
{
    public ArrangeTaskContainer FullAnswer { get; }
    public int IncorrectElementsCount { get; }

    public ArrangeTaskContainerEvaluation(ArrangeTaskContainer fullAnswer, int incorrectElementsCount)
    {
        FullAnswer = fullAnswer;
        IncorrectElementsCount = incorrectElementsCount;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return FullAnswer;
        yield return IncorrectElementsCount;
    }
}