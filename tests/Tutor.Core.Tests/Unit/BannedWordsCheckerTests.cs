using Shouldly;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.DomainModel.AssessmentItems.Challenges;
using Tutor.Core.DomainModel.AssessmentItems.Challenges.FulfillmentStrategies;
using Tutor.Core.Tests.TestData;
using Xunit;

namespace Tutor.Core.Tests.Unit
{
    public class BannedWordsCheckerTests
    {
        [Theory]
        [MemberData(nameof(ChallengeTest))]
        public void Evaluates_solution_submission(string[] submissionAttempt, List<ChallengeHint> expectedHints, bool expectedCompletion)
        {
            var challenge = new Challenge(1, 1, new List<ChallengeFulfillmentStrategy>
            {
                new BannedWordsChecker(new List<string>
                {
                    "Class", "Method", "List"
                }, new ChallengeHint(21), null)
            });

            var challengeEvaluation = challenge.EvaluateChallenge(submissionAttempt, null);
            var actualHints = challengeEvaluation.ApplicableHints.GetHints();

            actualHints.Count.ShouldBe(expectedHints.Count);
            actualHints.All(expectedHints.Contains).ShouldBeTrue();
            challengeEvaluation.Correct.ShouldBe(expectedCompletion);
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
                        new(21)
                    },
                    false
                }
            };
    }
}