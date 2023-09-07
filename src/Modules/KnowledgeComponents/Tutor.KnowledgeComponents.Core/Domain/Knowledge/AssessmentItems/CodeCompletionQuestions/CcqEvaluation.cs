namespace Tutor.KnowledgeComponents.Core.Domain.Knowledge.AssessmentItems.CodeCompletionQuestions;

public class CcqEvaluation : Evaluation
{
    public List<CcqItem> Items { get; }
    public string Feedback { get; set; }
    public CcqEvaluation(double correctnessLevel, List<CcqItem> items, string feedback) : base(correctnessLevel)
    {
        Items = items;
        Feedback = feedback;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Items;
        yield return Feedback;
    }
}