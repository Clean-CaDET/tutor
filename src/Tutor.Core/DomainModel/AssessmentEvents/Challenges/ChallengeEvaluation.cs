namespace Tutor.Core.DomainModel.AssessmentEvents.Challenges
{
    public class ChallengeEvaluation: Evaluation
    {
        public HintDirectory ApplicableHints { get; }

        public ChallengeEvaluation(int challengeId, int correctnessLevel, HintDirectory hints) : base(challengeId, correctnessLevel)
        {
            ApplicableHints = hints ?? new HintDirectory();
        }
    }
}
