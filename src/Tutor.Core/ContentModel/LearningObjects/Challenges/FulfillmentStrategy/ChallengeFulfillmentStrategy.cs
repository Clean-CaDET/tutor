using System.Collections.Generic;
using CodeModel.CaDETModel;
using CodeModel.CaDETModel.CodeItems;

namespace Tutor.Core.ContentModel.LearningObjects.Challenges.FulfillmentStrategy
{
    public abstract class ChallengeFulfillmentStrategy
    {
        public int Id { get; private set; }
        public string CodeSnippetId { get; private set; }
        protected List<string> PossibleRenames { get; private set; }

        protected ChallengeFulfillmentStrategy() {}
        protected ChallengeFulfillmentStrategy(int id, string codeSnippetId, List<string> possibleRenames): this()
        {
            Id = id;
            CodeSnippetId = codeSnippetId;
            PossibleRenames = possibleRenames;
        }

        public abstract HintDirectory EvaluateSubmission(CaDETProject solutionAttempt);
        public abstract List<ChallengeHint> GetAllHints();
    }
}
