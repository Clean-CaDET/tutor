using System.Collections.Generic;

namespace Tutor.Core.DomainModel.AssessmentItems.ShortAnswerQuestions;

public class SaqEvaluation : Evaluation
{
    public List<string> AcceptableAnswers { get; }
    public SaqEvaluation(int assessmentItemId, double correctnessLevel, List<string> acceptableAnswers) : base(assessmentItemId, correctnessLevel)
    {
        AcceptableAnswers = acceptableAnswers;
    }
}