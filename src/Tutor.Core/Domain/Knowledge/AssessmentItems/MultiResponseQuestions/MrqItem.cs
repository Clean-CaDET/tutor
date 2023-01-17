using System.Collections.Generic;
using Tutor.Core.BuildingBlocks;

namespace Tutor.Core.Domain.Knowledge.AssessmentItems.MultiResponseQuestions;

public class MrqItem : ValueObject
{
    public int Id { get; private set; }
    public string Text { get; private set; }
    public bool IsCorrect { get; internal set; }
    public string Feedback { get; internal set; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Text;
        yield return IsCorrect;
        yield return Feedback;
    }
}