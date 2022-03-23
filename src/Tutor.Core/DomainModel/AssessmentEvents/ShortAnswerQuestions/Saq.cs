using System;
using System.Collections.Generic;
using System.Linq;

namespace Tutor.Core.DomainModel.AssessmentEvents.ShortAnswerQuestions
{
    public class Saq : AssessmentEvent
    {
        public string Text { get; private set; }
        public List<string> AcceptableAnswers { get; private set; }

        public override Evaluation EvaluateSubmission(Submission submission)
        {
            if (submission is SaqSubmission saqSubmission) return EvaluateSaq(saqSubmission);
            throw new ArgumentException("Incorrect submission supplied to SAQ with ID " + Id);
        }

        private SaqEvaluation EvaluateSaq(SaqSubmission saqSubmission)
        {
            return new SaqEvaluation(Id, CalculateWordListCorrectness(saqSubmission.Answer), AcceptableAnswers);
        }

        private double CalculateWordListCorrectness(string saqSubmissionAnswer)
        {
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
            return (double) largerArray.Count(smallerOrEqualArray.Contains) / largerArray.Length;
        }
    }
}
