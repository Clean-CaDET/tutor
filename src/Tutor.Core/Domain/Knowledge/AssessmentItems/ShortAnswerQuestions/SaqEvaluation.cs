using System.Collections.Generic;

namespace Tutor.Core.Domain.Knowledge.AssessmentItems.ShortAnswerQuestions;

public class SaqEvaluation : Evaluation
{
    public List<string> AcceptableAnswers { get; }
    public string Feedback { get; set; }
    public SaqEvaluation(double correctnessLevel, List<string> acceptableAnswers, string feedback) : base(correctnessLevel)
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