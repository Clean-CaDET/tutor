using Tutor.Core.DomainModel.InstructionalEvents;

namespace Tutor.Core.DomainModel.AssessmentEvents.Challenges
{
    public class ChallengeEvaluation
    {
        public int ChallengeId { get; private set; }
        public bool ChallengeCompleted { get; internal set; }
        public HintDirectory ApplicableHints { get; }
        public InstructionalEvent Solution { get; internal set; }

        public ChallengeEvaluation(int challengeId)
        {
            ChallengeId = challengeId;
            ApplicableHints = new HintDirectory();
        }
    }
}
