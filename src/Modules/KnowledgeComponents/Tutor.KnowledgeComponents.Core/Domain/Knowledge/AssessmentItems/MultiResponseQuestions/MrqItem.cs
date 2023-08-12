using System.Text.Json.Serialization;
using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.KnowledgeComponents.Core.Domain.Knowledge.AssessmentItems.MultiResponseQuestions;

public class MrqItem : ValueObject
{
    [JsonConstructor]
    public MrqItem(string text, bool isCorrect, string feedback)
    {
        Text = text;
        IsCorrect = isCorrect;
        Feedback = feedback;
    }

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