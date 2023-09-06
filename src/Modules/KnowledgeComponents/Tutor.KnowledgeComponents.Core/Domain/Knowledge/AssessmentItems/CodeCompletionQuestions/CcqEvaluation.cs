namespace Tutor.KnowledgeComponents.Core.Domain.Knowledge.AssessmentItems.CodeCompletionQuestions;

public class CcqEvaluation : Evaluation
{
    public List<string> AcceptableAnswers { get; }
    public string Feedback { get; set; }
    public CcqEvaluation(double correctnessLevel, List<string> acceptableAnswers, string feedback) : base(correctnessLevel)
    {
        AcceptableAnswers = acceptableAnswers;
        Feedback = feedback;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return AcceptableAnswers;
        yield return Feedback;
    }
}