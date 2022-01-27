using System.Collections.Generic;

namespace Tutor.Core.DomainModel.AssessmentEvents.ShortAnswerQuestions;

public class SaqEvaluation : Evaluation
{
    public List<string> AcceptableAnswers { get; }
    public SaqEvaluation(int assessmentEventId, double correctnessLevel, List<string> acceptableAnswers) : base(assessmentEventId, correctnessLevel)
    {
        AcceptableAnswers = acceptableAnswers;
    }
}