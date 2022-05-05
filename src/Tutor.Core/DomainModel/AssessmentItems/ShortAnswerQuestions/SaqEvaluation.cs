using System.Collections.Generic;

namespace Tutor.Core.DomainModel.AssessmentItems.ShortAnswerQuestions;

public class SaqEvaluation : Evaluation
{
    public List<string> AcceptableAnswers { get; }
    public SaqEvaluation(double correctnessLevel, List<string> acceptableAnswers) : base(correctnessLevel)
    {
        AcceptableAnswers = acceptableAnswers;
    }
}