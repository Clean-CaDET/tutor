using CodeModel;
using CodeModel.CaDETModel;
using System;
using System.Collections.Generic;
using Tutor.Core.DomainModel.AssessmentEvents.Challenges.FulfillmentStrategy;
using Tutor.Core.DomainModel.AssessmentEvents.Challenges.FunctionalityTester;

namespace Tutor.Core.DomainModel.AssessmentEvents.Challenges
{
    public class Challenge : AssessmentEvent
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

            if (tester == null) return StrategyEvaluation(solution);
            
            var functionalEvaluation = tester.IsFunctionallyCorrect(solutionAttempt, TestSuiteLocation);
            return functionalEvaluation ?? StrategyEvaluation(solution);
        }

        private ChallengeEvaluation CheckSyntaxErrors(IReadOnlyCollection<string> syntaxErrors)
        {
            if (syntaxErrors.Count == 0) return null;

            var evaluation = new ChallengeEvaluation(Id, 0, null);
            evaluation.ApplicableHints.AddHint("SYNTAX ERRORS", new ChallengeHint(1, string.Join("\n", syntaxErrors)));
            return evaluation;
        }

        private ChallengeEvaluation StrategyEvaluation(CaDETProject solution)
        {
            var hints = new HintDirectory();
            foreach (var strategy in FulfillmentStrategies)
            {
                //TODO: Calculate correctness.
                var result = strategy.EvaluateSubmission(solution);
                hints.MergeHints(result);
            }
            //TODO: Pass calculated correctness.
            return hints.IsEmpty() ? new ChallengeEvaluation(Id, 1, null) : new ChallengeEvaluation(Id, 0, hints);
        }

        private static CaDETProject BuildCodeModel(string[] sourceCode)
        {
            var solutionAttempt = new CodeModelFactory().CreateProject(sourceCode);
            if (solutionAttempt.Classes == null || solutionAttempt.Classes.Count == 0) throw new InvalidOperationException("Invalid submission.");
            return solutionAttempt;
        }
    }
}