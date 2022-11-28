namespace Tutor.Core.Domain.Knowledge.AssessmentItems.Challenges;

public interface IFunctionalityTester
{
    public ChallengeEvaluation IsFunctionallyCorrect(string[] sourceCode, string testSuitePath);
}