using Shouldly;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.Domain.Knowledge.AssessmentItems.Challenges;
using Tutor.Core.Domain.Knowledge.AssessmentItems.Challenges.FulfillmentStrategies;
using Tutor.Core.Tests.TestData;
using Xunit;

namespace Tutor.Core.Tests.Unit;

public class BannedWordsCheckerTests
{
    [Theory]
    [MemberData(nameof(ChallengeTest))]
    public void Evaluates_challenge_submission(string[] submissionAttempt,
        List<ChallengeHint> expectedHints, bool expectedCorrectness)
    {
        var challenge = SetupChallenge();

        var challengeEvaluation = challenge.EvaluateChallenge(submissionAttempt, null);
            
        var actualHints = challengeEvaluation.ApplicableHints.GetHints();
        actualHints.Count.ShouldBe(expectedHints.Count);
        actualHints.All(expectedHints.Contains).ShouldBeTrue();
        challengeEvaluation.Correct.ShouldBe(expectedCorrectness);
    }

    private static Challenge SetupChallenge()
    {
        return new Challenge(1, 1, new List<ChallengeFulfillmentStrategy>
        {
            new BannedWordsChecker(new List<string>
            {
                "Class", "Method", "List"
            }, new ChallengeHint(21, "21"), null)
        });
    }

    public static IEnumerable<object[]> ChallengeTest =>
        new List<object[]>
        {
            new object[]
            {
                ChallengeTestData.GetTwoPassingClasses(),
                new List<ChallengeHint>(),
                true
            },
            new object[]
            {
                ChallengeTestData.GetTwoViolatingClasses(),
                new List<ChallengeHint>
                {
                    new(21, "21")
                },
                false
            }
        };
}