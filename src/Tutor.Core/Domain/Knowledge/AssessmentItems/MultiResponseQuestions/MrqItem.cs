using System.Collections.Generic;
using System.Text.Json.Serialization;
using Tutor.Core.BuildingBlocks;

namespace Tutor.Core.Domain.Knowledge.AssessmentItems.MultiResponseQuestions;

public class MrqItem : ValueObject
{
    [JsonConstructor]
    public MrqItem(int id, string text, bool isCorrect, string feedback)
    {
        Id = id;
        Text = text;
        IsCorrect = isCorrect;
        Feedback = feedback;
    }

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