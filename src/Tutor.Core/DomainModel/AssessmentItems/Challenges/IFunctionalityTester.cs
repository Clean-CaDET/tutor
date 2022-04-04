namespace Tutor.Core.DomainModel.AssessmentItems.Challenges
{
    public interface IFunctionalityTester
    {
        public ChallengeEvaluation IsFunctionallyCorrect(string[] sourceCode, string testSuitePath);
    }
}
