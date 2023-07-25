using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.KnowledgeComponents.Core.Domain.Knowledge.AssessmentItems;

public class Feedback : ValueObject
{
    public FeedbackType FeedbackType { get; }
    public Hint Hint { get; }
    public Evaluation Evaluation { get; }

    public Feedback(FeedbackType feedbackType, Hint hint, Evaluation evaluation)
    {
        FeedbackType = feedbackType;
        Hint = hint;
        Evaluation = evaluation;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return FeedbackType;
        yield return Hint;
        yield return Evaluation;
    }
}

public enum FeedbackType
{
    Correctness, Pump, Hint, Solution
}