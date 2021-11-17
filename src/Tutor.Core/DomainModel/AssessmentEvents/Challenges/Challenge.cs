﻿using System;
using System.Collections.Generic;
using System.Linq;
using CodeModel;
using CodeModel.CaDETModel;
using Tutor.Core.ContentModel.LearningObjects;
using Tutor.Core.ContentModel.Lectures;
using Tutor.Core.DomainModel.AssessmentEvents.Challenges.FulfillmentStrategy;
using Tutor.Core.DomainModel.AssessmentEvents.Challenges.FunctionalityTester;

namespace Tutor.Core.DomainModel.AssessmentEvents.Challenges
{
    public class Challenge : LearningObject
    {
        public string Url { get; private set; }
        public string Description { get; private set; }
        public string TestSuiteLocation { get; private set; }
        public LearningObjectSummary Solution { get; private set; }
        public List<ChallengeFulfillmentStrategy> FulfillmentStrategies { get; private set; }

        private Challenge() {}
        public Challenge(int id, int learningObjectSummaryId, List<ChallengeFulfillmentStrategy> fulfillmentStrategies) : base(id, learningObjectSummaryId)
        {
            FulfillmentStrategies = fulfillmentStrategies;
        }

        public ChallengeEvaluation CheckChallengeFulfillment(string[] solutionAttempt, IFunctionalityTester tester)
        {
            CaDETProject solution = BuildCaDETModel(solutionAttempt);
            
            var errorEvaluation = CheckSyntaxErrors(solution.SyntaxErrors);
            if (errorEvaluation != null) return errorEvaluation;

            if (tester == null) return StrategyEvaluation(solution);
            
            var functionalEvaluation = tester.IsFunctionallyCorrect(solutionAttempt, TestSuiteLocation);
            return functionalEvaluation ?? StrategyEvaluation(solution);
        }

        private ChallengeEvaluation CheckSyntaxErrors(IReadOnlyCollection<string> syntaxErrors)
        {
            if (syntaxErrors.Count == 0) return null;

            var evaluation = new ChallengeEvaluation(Id);
            evaluation.ApplicableHints.AddHint("SYNTAX ERRORS", new ChallengeHint(1, string.Join("\n", syntaxErrors)));
            return evaluation;
        }

        private ChallengeEvaluation StrategyEvaluation(CaDETProject solution)
        {
            var evaluation = new ChallengeEvaluation(Id);
            foreach (var strategy in FulfillmentStrategies)
            {
                var result = strategy.EvaluateSubmission(solution);
                evaluation.ApplicableHints.MergeHints(result);
            }

            if (!evaluation.ApplicableHints.IsEmpty()) return evaluation;
            evaluation.ChallengeCompleted = true;
            evaluation.ApplicableHints.AddAllHints(GetAllChallengeHints());

            return evaluation;
        }

        private static CaDETProject BuildCaDETModel(string[] sourceCode)
        {
            var solutionAttempt = new CodeModelFactory().CreateProject(sourceCode);
            if (solutionAttempt.Classes == null || solutionAttempt.Classes.Count == 0) throw new InvalidOperationException("Invalid submission.");
            return solutionAttempt;
        }

        private List<ChallengeHint> GetAllChallengeHints()
        {
            return FulfillmentStrategies.SelectMany(s => s.GetAllHints().Where(h => h != null)).ToList();
        }
    }
}