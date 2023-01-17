using System;
using System.Collections.Generic;
using System.Linq;

namespace Tutor.Core.Domain.Knowledge.AssessmentItems.ShortAnswerQuestions;

public class Saq : AssessmentItem
{
    public string Text { get; private set; }
    public List<string> AcceptableAnswers { get; private set; }

    public override void ClearFeedback()
    {
        AcceptableAnswers = null;
    }

    public override Evaluation Evaluate(Submission submission)
    {
        if (submission is SaqSubmission saqSubmission) return EvaluateSaq(saqSubmission);
        throw new ArgumentException("Incorrect submission supplied to SAQ with ID " + Id);
    }

    private SaqEvaluation EvaluateSaq(SaqSubmission saqSubmission)
    {
        return new SaqEvaluation(CalculateWordListCorrectness(saqSubmission.Answer), AcceptableAnswers);
    }

    private double CalculateWordListCorrectness(string saqSubmissionAnswer)
    {
        if (string.IsNullOrEmpty(saqSubmissionAnswer)) return 0;

        var submissionWords = saqSubmissionAnswer.Split(',', StringSplitOptions.TrimEntries).Distinct().ToArray();
        double maxCorrectness = 0;
        foreach (var acceptableAnswer in AcceptableAnswers)
        {
            var acceptableWords = acceptableAnswer.Split(',', StringSplitOptions.TrimEntries);
            maxCorrectness = submissionWords.Length > acceptableWords.Length ?
                Math.Max(GetDegreeOfOverlap(submissionWords, acceptableWords), maxCorrectness) :
                Math.Max(GetDegreeOfOverlap(acceptableWords, submissionWords), maxCorrectness);
        }

        return maxCorrectness;
    }

    private static double GetDegreeOfOverlap(string[] largerArray, string[] smallerOrEqualArray)
    {
        return (double)largerArray.Count(smallerOrEqualArray.Contains) / largerArray.Length;
    }
}