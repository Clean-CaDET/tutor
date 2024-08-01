using Shouldly;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.DomainServices;

namespace Tutor.KnowledgeComponents.Tests.Unit.Learning;

[Collection("Sequential")]
public class LeastCorrectAssessmentItemSelectorTests
{
    [Theory]
    [MemberData(nameof(PassedTestData))]
    public void Gets_suitable_assessment_item_when_passed(List<AssessmentItemMastery> masteries, int expectedSelectedItemId)
    {
        var selector = new LeastCorrectAssessmentItemSelector();

        var actualSelectedItemId = selector.SelectSuitableAssessmentItemId(masteries, true);

        actualSelectedItemId.ShouldBe(expectedSelectedItemId);
    }

    public static IEnumerable<object[]> PassedTestData()
    {
        return new List<object[]>
        {
            new object[]
            {
              new List<AssessmentItemMastery>
              {
                  new (1, 1, 1, new DateTime(2024, 12, 1), 0)
              },
              1
            },
            new object[]
            {
                new List<AssessmentItemMastery>
                {
                    new (1, 1, 1, new DateTime(2024, 12, 1), 0),
                    new (2, 1, 1, new DateTime(2024, 12, 2), 0)
                },
                1
            },
            new object[]
            {
                new List<AssessmentItemMastery>
                {
                    new (1, 1, 1, new DateTime(2024, 12, 1), 0),
                    new (2, 0.8, 1, new DateTime(2024, 12, 2), 0)
                },
                2
            },
            new object[]
            {
                new List<AssessmentItemMastery>
                {
                    new (1, 1, 1, new DateTime(2024, 12, 1), 0),
                    new (2, 0.8, 1, new DateTime(2024, 12, 2), 0),
                    new (3, 1, 1, new DateTime(2024, 12, 3), 0)
                },
                2
            }
        };
    }

    [Theory]
    [MemberData(nameof(NotPassedTestData))]
    public void Gets_suitable_assessment_item_when_not_passed(List<AssessmentItemMastery> masteries, int expectedSelectedItemId)
    {
        var selector = new LeastCorrectAssessmentItemSelector();

        var actualSelectedItemId = selector.SelectSuitableAssessmentItemId(masteries, false);

        actualSelectedItemId.ShouldBe(expectedSelectedItemId);
    }

    public static IEnumerable<object[]> NotPassedTestData()
    {
        return new List<object[]>
        {
            new object[]
            {
                new List<AssessmentItemMastery>
                {
                    new (1, 0, 0, null, 0),
                    new (2, 0, 0, null, 0),
                    new (3, 0, 0, null, 0)
                },
                1
            },
            new object[]
            {
                new List<AssessmentItemMastery>
                {
                    new (1, 0, 1, new DateTime(2024, 12, 1), 0),
                    new (2, 0, 0, null, 0),
                    new (3, 0, 0, null, 0)
                },
                2
            },
            new object[]
            {
                new List<AssessmentItemMastery>
                {
                    new (1, 0, 1, new DateTime(2024, 12, 1), 0),
                    new (2, 0, 1, new DateTime(2024, 12, 2), 0),
                    new (3, 0, 1, new DateTime(2024, 12, 3), 0)
                },
                1
            },
            new object[]
            {
                new List<AssessmentItemMastery>
                {
                    new (1, 0.5, 1, new DateTime(2024, 12, 1), 0),
                    new (2, 0, 1, new DateTime(2024, 12, 2), 0),
                    new (3, 0, 1, new DateTime(2024, 12, 3), 0)
                },
                2
            },
            new object[]
            {
                new List<AssessmentItemMastery>
                {
                    new (1, 0.6, 1, new DateTime(2024, 12, 1), 0),
                    new (2, 0.5, 1, new DateTime(2024, 12, 2), 0),
                    new (3, 0, 1, new DateTime(2024, 12, 3), 0)
                },
                2
            },
            new object[]
            {
                new List<AssessmentItemMastery>
                {
                    new (1, 0.5, 1, new DateTime(2024, 12, 1), 0),
                    new (2, 0.6, 1, new DateTime(2024, 12, 2), 0),
                    new (3, 0, 1, new DateTime(2024, 12, 3), 0)
                },
                1
            },
            new object[]
            {
                new List<AssessmentItemMastery>
                {
                    new (1, 1, 1, new DateTime(2024, 12, 1), 0),
                    new (2, 1, 1, new DateTime(2024, 12, 2), 0),
                    new (3, 0.5, 1, new DateTime(2024, 12, 3), 0)
                },
                3
            }
        };
    }

    [Fact]
    public void Throws_when_masteries_are_undefined()
    {
        var selector = new LeastCorrectAssessmentItemSelector();

        Should.Throw<ArgumentException>(() =>
        {
            selector.SelectSuitableAssessmentItemId(new List<AssessmentItemMastery>(), true);
        });
    }
}