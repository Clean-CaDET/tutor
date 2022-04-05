using CodeModel;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.DomainModel.AssessmentItems.Challenges;
using Tutor.Core.DomainModel.AssessmentItems.Challenges.FulfillmentStrategies;
using Tutor.Core.Tests.TestData;
using Xunit;

namespace Tutor.Core.Tests.Unit
{
    public class BasicMetricsCheckerTests
    {
        private readonly List<BasicMetricChecker> _basicMetricCheckers;

        public BasicMetricsCheckerTests()
        {
            _basicMetricCheckers = new List<BasicMetricChecker>
            {
                new(33701, "CLOC", 3, 30, new ChallengeHint(337001),"Methods.Small.PaymentService"),
                new(33702, "NMD", 0, 2, new ChallengeHint(5),"Methods.Small.PaymentService"),
                new(33701, "CLOC", 3, 30, new ChallengeHint(337001), "Methods.Small.Payment"),
                new(33702, "NMD", 0, 2, new ChallengeHint(5), "Methods.Small.Payment"),
                new(33703, "MELOC", 2, 5, new ChallengeHint(337002), "Methods.Small.PaymentService.CreatePayment(int, int)"),
                new(33704, "NOP", 2, 4, new ChallengeHint(6), "Methods.Small.PaymentService.CreatePayment(int, int)"),
                new(33703, "MELOC", 2, 5, new ChallengeHint(337002), "Methods.Small.PaymentService"),
                new(33704, "NOP", 2, 4, new ChallengeHint(6), "Methods.Small.PaymentService")
            };
        }

        [Theory]
        [MemberData(nameof(ChallengeTest))]
        public void Evaluates_solution_submission(string[] submissionAttempt, List<ChallengeHint> expectedHints)
        {
            var project = new CodeModelFactory().CreateProject(submissionAttempt);
            HintDirectory hints = new HintDirectory();
            foreach (var checker in _basicMetricCheckers)
            {
                var challengeEvaluation = checker.EvaluateSubmission(project);
                hints.MergeHints(challengeEvaluation);
            }

            var actualHints = hints.GetHints();

            actualHints.Count.ShouldBe(expectedHints.Count);
            actualHints.All(expectedHints.Contains).ShouldBeTrue();
        }

        public static IEnumerable<object[]> ChallengeTest =>
            new List<object[]>
            {
                new object[]
                {
                    ChallengeTestData.GetTwoPassingClasses(),
                    new List<ChallengeHint>()
                },
                new object[]
                {
                    ChallengeTestData.GetTwoViolatingClasses(),
                    new List<ChallengeHint>
                    {
                        new(6),
                        new(337002),
                        new(337001)
                    }
                }
            };
    }
}