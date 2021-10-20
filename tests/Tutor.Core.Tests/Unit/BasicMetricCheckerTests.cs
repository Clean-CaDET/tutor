﻿using CodeModel;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.ContentModel.LearningObjects.Challenges;
using Tutor.Core.ContentModel.LearningObjects.Challenges.FulfillmentStrategy.MetricChecker;
using Tutor.Core.Tests.TestData;
using Xunit;

namespace Tutor.Core.Tests.Unit
{
    public class BasicMetricsCheckerTests
    {
        private readonly BasicMetricChecker _basicMetricChecker;

        public BasicMetricsCheckerTests()
        {
            _basicMetricChecker = new BasicMetricChecker(
                new List<MetricRangeRule>
                {
                    new(33701,"CLOC",3,30,new ChallengeHint(337001)),
                    new(33702, "NMD", 0, 2, new ChallengeHint(5))
                },
                new List<MetricRangeRule>
                {
                    new(33703, "MELOC", 2, 5, new ChallengeHint(337002)),
                    new(33704, "NOP", 2, 4, new ChallengeHint(6))
                }
            );
        }

        [Theory]
        [MemberData(nameof(ChallengeTest))]
        public void Evaluates_solution_submission(string[] submissionAttempt, List<ChallengeHint> expectedHints)
        {
            var project = new CodeModelFactory().CreateProject(submissionAttempt);
            var challengeEvaluation = _basicMetricChecker.EvaluateSubmission(project.Classes);
            var actualHints = challengeEvaluation.GetHints();

            actualHints.Count.ShouldBe(expectedHints.Count);
            actualHints.All(expectedHints.Contains).ShouldBeTrue();
        }

        public static IEnumerable<object[]> ChallengeTest =>
            new List<object[]>
            {
                new object[]
                {
                    //TODO: Find better names for these methods and add more test data and more thorough HintDirectory evaluation (probably separate tests for MetricRangeRules and HintDirectory)
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