using Shouldly;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.ContentModel.LearningObjects.Challenges;
using Tutor.Core.ContentModel.LearningObjects.Challenges.FulfillmentStrategy;
using Tutor.Core.ContentModel.LearningObjects.Challenges.FulfillmentStrategy.NameChecker;
using Tutor.Core.Tests.TestData;
using Xunit;

namespace Tutor.Core.Tests.Unit
{
    public class BasicNameCheckerTests
    {
        [Theory]
        [MemberData(nameof(ChallengeTest))]
        public void Evaluates_solution_submission(string[] submissionAttempt, List<ChallengeHint> expectedHints, bool expectedCompletion)
        {
            //TODO: Readonly lists
            var challenge = new Challenge(1, 1, new List<ChallengeFulfillmentStrategy>
            {
                new BasicNameChecker(null, new List<string> { "PaymentService" },
                    new ChallengeHint(11),
                    "Methods.Small.PaymentService", null),
                new BasicNameChecker(null, new List<string> { "Payment", "compensation" },
                    new ChallengeHint(11),
                    "Methods.Small.PaymentService.CreatePayment(int, int)", null),
                new BasicNameChecker(new List<string>
                {
                    "Class", "Method"
                }, null, new ChallengeHint(21), "Methods.Small.PaymentClass", new List<string> { "Methods.Small.Payment" }),
                new BasicNameChecker(new List<string>
                {
                    "Class", "Method"
                }, null, new ChallengeHint(21), "Methods.Small.PaymentService", null),
                new BasicNameChecker(new List<string>
                {
                    "Class", "List", "Method"
                }, null, new ChallengeHint(21), "Methods.Small.PaymentService.CreatePayment(int, int)", null)
            });

            var challengeEvaluation = challenge.CheckChallengeFulfillment(submissionAttempt, null);
            var actualHints = challengeEvaluation.ApplicableHints.GetHints();

            actualHints.Count.ShouldBe(expectedHints.Count);
            actualHints.All(expectedHints.Contains).ShouldBeTrue();
            challengeEvaluation.ChallengeCompleted.ShouldBe(expectedCompletion);
        }

        public static IEnumerable<object[]> ChallengeTest =>
            new List<object[]>
            {
                new object[]
                {
                    //TODO: Find better names for these methods and add more test data and more thorough HintDirectory evaluation (probably separate tests for MetricRangeRules and HintDirectory)
                    ChallengeTestData.GetTwoPassingClasses(),
                    new List<ChallengeHint>
                    {
                        new(11),
                        new(21)
                    },
                    true
                },
                new object[]
                {
                    ChallengeTestData.GetTwoViolatingClasses(),
                    new List<ChallengeHint>
                    {
                        new(11),
                        new(21)
                    },
                    false
                }
            };
    }
}