﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Tutor.Core.DomainModel.AssessmentEvents.ShortAnswerQuestions
{
    public class Saq : AssessmentEvent
    {
        public string Text { get; private set; }
        public List<string> AcceptableAnswers { get; private set; }

        public override void ValidateInteraction(AssessmentEventInteraction interaction)
        {
            if (interaction is not SaqInteraction)
                throw new ArgumentException("Incorrect interaction supplied to SAQ with ID " + Id);
        }

        public override Evaluation EvaluateSubmission(Submission submission)
        {
            if (submission is SaqSubmission saqSubmission) return EvaluateSaq(saqSubmission);
            throw new ArgumentException("Incorrect submission supplied to SAQ with ID " + Id);
        }

        private SaqEvaluation EvaluateSaq(SaqSubmission saqSubmission)
        {
            if (saqSubmission.Answer.Contains(','))
            {
                return new SaqEvaluation(Id, CalculateWordListCorrectness(saqSubmission.Answer), AcceptableAnswers);
            }
            var correctness = AcceptableAnswers.Contains(saqSubmission.Answer) ? 1 : 0;
            return new SaqEvaluation(Id, correctness, AcceptableAnswers);
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
