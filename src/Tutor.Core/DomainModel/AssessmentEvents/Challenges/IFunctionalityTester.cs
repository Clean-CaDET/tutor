namespace Tutor.Core.DomainModel.AssessmentEvents.Challenges
{
    public interface IFunctionalityTester
    {
        public ChallengeEvaluation IsFunctionallyCorrect(string[] sourceCode, string testSuitePath);
    }
}
