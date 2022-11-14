namespace Tutor.Core.Domain.Knowledge.AssessmentItems.Challenges
{
    public class ChallengeEvaluation : Evaluation
    {
        public HintDirectory ApplicableHints { get; }
        public string SolutionUrl { get; }

        public ChallengeEvaluation(double correctnessLevel, HintDirectory hints, string solutionUrl) : base(correctnessLevel)
        {
            ApplicableHints = hints ?? new HintDirectory();
            SolutionUrl = solutionUrl;
        }
    }
}
