﻿using CodeModel.CaDETModel;
using System.Collections.Generic;

namespace Tutor.Core.DomainModel.AssessmentEvents.Challenges.FulfillmentStrategy
{
    public abstract class ChallengeFulfillmentStrategy
    {
        public int Id { get; private set; }
        public string CodeSnippetId { get; private set; }
        protected List<string> PossibleRenames { get; private set; }

        protected ChallengeFulfillmentStrategy() {}
        protected ChallengeFulfillmentStrategy(int id, string codeSnippetId): this()
        {
            Id = id;
            CodeSnippetId = codeSnippetId;
        }

        public abstract HintDirectory EvaluateSubmission(CaDETProject solutionAttempt);
        public abstract List<ChallengeHint> GetAllHints();
    }
}