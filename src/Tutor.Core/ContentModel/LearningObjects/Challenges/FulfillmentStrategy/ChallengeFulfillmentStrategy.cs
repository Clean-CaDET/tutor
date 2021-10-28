using System.Collections.Generic;
using CodeModel.CaDETModel.CodeItems;

namespace Tutor.Core.ContentModel.LearningObjects.Challenges.FulfillmentStrategy
{
    public abstract class ChallengeFulfillmentStrategy
    {
        public int Id { get; private set; }
        public string CodeSnippedId { get; protected set; }

        public abstract HintDirectory EvaluateSubmission(List<CaDETClass> solutionAttempt);
        public abstract List<ChallengeHint> GetAllHints();
    }
}
