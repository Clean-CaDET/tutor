using System.Collections.Generic;

namespace Tutor.Core.Domain.Knowledge.AssessmentItems.MultiChoiceQuestions;

public class McqEvaluation : Evaluation
{
    public string CorrectAnswer { get; }
    public string Feedback { get; set; }
    public McqEvaluation(double correctnessLevel, string correctAnswer, string feedback) : base(correctnessLevel)
    {
        CorrectAnswer = correctAnswer;
        Feedback = feedback;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return CorrectAnswer;
        yield return Feedback;
    }
}