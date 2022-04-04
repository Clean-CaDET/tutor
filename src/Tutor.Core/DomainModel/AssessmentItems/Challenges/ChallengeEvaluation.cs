namespace Tutor.Core.DomainModel.AssessmentItems.Challenges
{
    public class ChallengeEvaluation: Evaluation
    {
        public HintDirectory ApplicableHints { get; }
        public string SolutionUrl { get; }

        public ChallengeEvaluation(int challengeId, double correctnessLevel, HintDirectory hints, string solutionUrl) : base(challengeId, correctnessLevel)
        {
            ApplicableHints = hints ?? new HintDirectory();
            SolutionUrl = solutionUrl;
        }
    }
}
