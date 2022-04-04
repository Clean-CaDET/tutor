using CodeModel;
using CodeModel.CaDETModel;
using System;
using System.Collections.Generic;

namespace Tutor.Core.DomainModel.AssessmentItems.Challenges
{
    public class Challenge : AssessmentItem
    {
        public string Url { get; private set; }
        public string Description { get; private set; }
        public string TestSuiteLocation { get; private set; }
        public string SolutionUrl { get; private set; }
        public List<ChallengeFulfillmentStrategy> FulfillmentStrategies { get; private set; }

        private Challenge() {}
        public Challenge(int id, int learningObjectSummaryId, List<ChallengeFulfillmentStrategy> fulfillmentStrategies) : base(id, learningObjectSummaryId)
        {
            FulfillmentStrategies = fulfillmentStrategies;
        }

        public override Evaluation EvaluateSubmission(Submission submission)
        {
            if (submission is ChallengeSubmission challengeSubmission) return EvaluateChallenge(challengeSubmission.SourceCode, null);
            throw new ArgumentException("Incorrect submission supplied to challenge with ID " + Id);
        }

        public ChallengeEvaluation EvaluateChallenge(string[] solutionAttempt, IFunctionalityTester tester)
        {
            CaDETProject solution = BuildCodeModel(solutionAttempt);
            
            var errorEvaluation = CheckSyntaxErrors(solution.SyntaxErrors);
            if (errorEvaluation != null) return errorEvaluation;

            if (tester == null) return ApplyEvaluationStrategies(solution);
            
            var functionalEvaluation = tester.IsFunctionallyCorrect(solutionAttempt, TestSuiteLocation);
            return functionalEvaluation ?? ApplyEvaluationStrategies(solution);
        }

        private static CaDETProject BuildCodeModel(string[] sourceCode)
        {
            var solutionAttempt = new CodeModelFactory().CreateProject(sourceCode);
            if (solutionAttempt.Classes == null || solutionAttempt.Classes.Count == 0) throw new ArgumentException("Invalid submission, no classes found.");
            return solutionAttempt;
        }

        private ChallengeEvaluation CheckSyntaxErrors(IReadOnlyCollection<string> syntaxErrors)
        {
            if (syntaxErrors.Count == 0) return null;

            var evaluation = new ChallengeEvaluation(Id, 0, null, null);
            evaluation.ApplicableHints.AddHint("SYNTAX ERRORS", new ChallengeHint(1, string.Join("\n", syntaxErrors)));
            return evaluation;
        }

        private ChallengeEvaluation ApplyEvaluationStrategies(CaDETProject solution)
        {
            var hints = new HintDirectory();
            foreach (var strategy in FulfillmentStrategies)
            {
                var result = strategy.EvaluateSubmission(solution);
                hints.MergeHints(result);
            }
            return new ChallengeEvaluation(Id, CalculateCorrectness(hints), hints, SolutionUrl);
        }

        private double CalculateCorrectness(HintDirectory hints)
        {
            return 1 - Math.Round((double)hints.GetHints().Count / FulfillmentStrategies.Count, 2);
        }
    }
}