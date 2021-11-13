using System.Collections.Generic;
using CodeModel.CaDETModel.CodeItems;

namespace Tutor.Core.DomainModel.AssessmentEvents.Challenges.FulfillmentStrategy
{
    public abstract class ChallengeFulfillmentStrategy
    {
        public int Id { get; private set; }

        public abstract HintDirectory EvaluateSubmission(List<CaDETClass> solutionAttempt);
        public abstract List<ChallengeHint> GetAllHints();
    }
}
