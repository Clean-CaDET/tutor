using Quickenshtein;

namespace Tutor.KnowledgeComponents.Core.Domain.Knowledge.AssessmentItems.ShortAnswerQuestions;

public class Saq : AssessmentItem
{
    public string Text { get; private set; }
    public List<string> AcceptableAnswers { get; private set; }
    public string Feedback { get; private set; }
    public int Tolerance { get; private set; }

    protected override void ClearSolution()
    {
        AcceptableAnswers = null;
        Feedback = string.Empty;
    }

    public override Evaluation Evaluate(Submission submission)
    {
        if (submission is SaqSubmission saqSubmission) return EvaluateSaq(saqSubmission);
        throw new ArgumentException("Incorrect submission supplied to SAQ with ID " + Id);
    }

    private SaqEvaluation EvaluateSaq(SaqSubmission saqSubmission)
    {
        return new SaqEvaluation(CalculateWordListCorrectness(saqSubmission.Answer), AcceptableAnswers, Feedback);
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
                Math.Max(GetDegreeOfOverlap(submissionWords, acceptableWords, Tolerance), maxCorrectness) :
                Math.Max(GetDegreeOfOverlap(acceptableWords, submissionWords, Tolerance), maxCorrectness);
        }

        return maxCorrectness;
    }

    private static double GetDegreeOfOverlap(string[] largerArray, string[] smallerOrEqualArray, int tolerance)
    {
        int matching = 0;
        foreach (var largerArrayValue in largerArray)
        {
            foreach (var smallerArrayValue in smallerOrEqualArray)
            {
                if (Levenshtein.GetDistance(largerArrayValue, smallerArrayValue, CalculationOptions.DefaultWithThreading) <= tolerance)
                    matching += 1;
            }
        }
        return (double)matching / largerArray.Length;
    }
}