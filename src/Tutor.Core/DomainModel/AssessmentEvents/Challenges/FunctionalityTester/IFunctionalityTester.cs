namespace Tutor.Core.DomainModel.AssessmentEvents.Challenges.FunctionalityTester
{
    public interface IFunctionalityTester
    {
        public ChallengeEvaluation IsFunctionallyCorrect(string[] sourceCode, string testSuitePath);
    }
}
