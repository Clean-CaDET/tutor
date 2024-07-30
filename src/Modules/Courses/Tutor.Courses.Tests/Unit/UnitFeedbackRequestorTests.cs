using Shouldly;
using Tutor.Courses.Core.Domain;

namespace Tutor.Courses.Tests.Unit;

[Collection("Sequential")]
public class UnitFeedbackRequestorTests
{
    [Theory]
    [MemberData(nameof(RequestTestData))]
    public void Requests_feedback(Tuple<int, int> kcMasteryCount, Tuple<int, int> taskProgressCount, List<UnitProgressRating> ratings, bool expectedKcFeedback, bool expectedTaskFeedback)
    {
        var actualFeedbackRequest = UnitFeedbackRequestor.ShouldRequestFeedback(kcMasteryCount, taskProgressCount, ratings).Value;

        actualFeedbackRequest.RequestKcFeedback.ShouldBe(expectedKcFeedback);
        actualFeedbackRequest.RequestTaskFeedback.ShouldBe(expectedTaskFeedback);
    }

    public static IEnumerable<object[]> RequestTestData()
    {
        return new List<object[]>
        {
            new object[]
            {
              new Tuple<int, int>(6, 3),
              new Tuple<int, int>(6, 3),
              new List<UnitProgressRating>
              {
                  new(new [] {1, 2, 3}, new int[]{}, DateTime.UtcNow - TimeSpan.FromHours(2), false),
                  new(new int[] {}, new []{1, 2, 3}, DateTime.UtcNow - TimeSpan.FromHours(1), false)
              },
              false,
              false
            },
            new object[]
            {
                new Tuple<int, int>(6, 4),
                new Tuple<int, int>(6, 3),
                new List<UnitProgressRating>
                {
                    new(new [] {1, 2, 3}, new int[]{}, DateTime.UtcNow - TimeSpan.FromHours(2), false),
                    new(new int[] {}, new []{1, 2, 3}, DateTime.UtcNow - TimeSpan.FromHours(1), false)
                },
                false,
                false
            },
            new object[]
            {
                new Tuple<int, int>(6, 5),
                new Tuple<int, int>(6, 3),
                new List<UnitProgressRating>
                {
                    new(new [] {1, 2, 3}, new int[]{}, DateTime.UtcNow - TimeSpan.FromHours(2), false),
                    new(new int[] {}, new []{1, 2, 3}, DateTime.UtcNow - TimeSpan.FromHours(1), false)
                },
                true,
                false
            },
            new object[]
            {
                new Tuple<int, int>(6, 4),
                new Tuple<int, int>(6, 4),
                new List<UnitProgressRating>
                {
                    new(new [] {1, 2, 3}, new int[]{}, DateTime.UtcNow - TimeSpan.FromHours(2), false),
                    new(new int[] {}, new []{1, 2, 3}, DateTime.UtcNow - TimeSpan.FromHours(1), false)
                },
                true,
                true
            },
            new object[]
            {
                new Tuple<int, int>(6, 3),
                new Tuple<int, int>(6, 5),
                new List<UnitProgressRating>
                {
                    new(new [] {1, 2, 3}, new int[]{}, DateTime.UtcNow - TimeSpan.FromHours(2), false),
                    new(new int[] {}, new []{1, 2, 3}, DateTime.UtcNow - TimeSpan.FromHours(1), false)
                },
                false,
                true
            },
            new object[]
            {
                new Tuple<int, int>(6, 3),
                new Tuple<int, int>(6, 4),
                new List<UnitProgressRating>
                {
                    new(new [] {1, 2, 3}, new int[]{}, DateTime.UtcNow - TimeSpan.FromHours(2), false),
                    new(new int[] {}, new []{1, 2, 3}, DateTime.UtcNow - TimeSpan.FromHours(1.5), false)
                },
                false,
                true
            },
            new object[]
            {
                new Tuple<int, int>(6, 4),
                new Tuple<int, int>(6, 3),
                new List<UnitProgressRating>
                {
                    new(new [] {1, 2, 3}, new int[]{}, DateTime.UtcNow - TimeSpan.FromHours(2), false),
                    new(new int[] {}, new []{1, 2, 3}, DateTime.UtcNow - TimeSpan.FromHours(1.5), false)
                },
                true,
                false
            },
            new object[]
            {
                new Tuple<int, int>(6, 4),
                new Tuple<int, int>(6, 4),
                new List<UnitProgressRating>
                {
                    new(new [] {1, 2, 3}, new int[]{}, DateTime.UtcNow - TimeSpan.FromHours(2), false),
                    new(new int[] {}, new []{1, 2, 3}, DateTime.UtcNow - TimeSpan.FromHours(0.5), false)
                },
                false,
                false
            },
            new object[]
            {
                new Tuple<int, int>(6, 5),
                new Tuple<int, int>(6, 4),
                new List<UnitProgressRating>
                {
                    new(new [] {1, 2, 3}, new int[]{}, DateTime.UtcNow - TimeSpan.FromHours(2), false),
                    new(new int[] {}, new []{1, 2, 3}, DateTime.UtcNow - TimeSpan.FromHours(0.5), false)
                },
                true,
                true
            },
            new object[]
            {
                new Tuple<int, int>(6, 5),
                new Tuple<int, int>(6, 6),
                new List<UnitProgressRating>
                {
                    new(new [] {1, 2, 3}, new int[]{}, DateTime.UtcNow - TimeSpan.FromHours(2), false),
                    new(new int[] {}, new []{1, 2, 3}, DateTime.UtcNow - TimeSpan.FromHours(1), false),
                    new(new [] {4, 5}, new []{4, 5}, DateTime.UtcNow - TimeSpan.FromHours(0.1), false)
                },
                false,
                false
            },
            new object[]
            {
                new Tuple<int, int>(6, 6),
                new Tuple<int, int>(6, 6),
                new List<UnitProgressRating>
                {
                    new(new [] {1, 2, 3}, new int[]{}, DateTime.UtcNow - TimeSpan.FromHours(2), false),
                    new(new int[] {}, new []{1, 2, 3}, DateTime.UtcNow - TimeSpan.FromHours(1), false),
                    new(new [] {4, 5}, new []{4, 5, 6}, DateTime.UtcNow - TimeSpan.FromHours(0.1), false)
                },
                true,
                false
            },
            new object[]
            {
                new Tuple<int, int>(6, 6),
                new Tuple<int, int>(6, 6),
                new List<UnitProgressRating>
                {
                    new(new [] {1, 2, 3}, new int[]{}, DateTime.UtcNow - TimeSpan.FromHours(2), false),
                    new(new int[] {}, new []{1, 2, 3}, DateTime.UtcNow - TimeSpan.FromHours(1), false),
                    new(new [] {4, 5, 6}, new []{4, 5}, DateTime.UtcNow - TimeSpan.FromHours(0.1), false)
                },
                false,
                true
            },
            new object[]
            {
                new Tuple<int, int>(6, 6),
                new Tuple<int, int>(6, 6),
                new List<UnitProgressRating>
                {
                    new(new [] {1, 2, 3}, new int[]{}, DateTime.UtcNow - TimeSpan.FromHours(4), false),
                    new(new int[] {}, new []{1, 2, 3}, DateTime.UtcNow - TimeSpan.FromHours(3), false),
                    new(new [] {4, 5, 6}, new []{4, 5, 6}, DateTime.UtcNow - TimeSpan.FromHours(2), false)
                },
                false,
                false
            },
            new object[]
            {
                new Tuple<int, int>(6, 4),
                new Tuple<int, int>(6, 4),
                new List<UnitProgressRating>
                {
                    new(new [] {1, 2, 3}, new int[]{}, DateTime.UtcNow - TimeSpan.FromHours(4), false),
                    new(new int[] {}, new []{1, 2, 3}, DateTime.UtcNow - TimeSpan.FromHours(3), false),
                    new(new [] {4}, new int[]{}, DateTime.UtcNow - TimeSpan.FromHours(0.1), true)
                },
                false,
                true
            },
            new object[]
            {
                new Tuple<int, int>(6, 4),
                new Tuple<int, int>(6, 4),
                new List<UnitProgressRating>
                {
                    new(new [] {1, 2, 3}, new int[]{}, DateTime.UtcNow - TimeSpan.FromHours(4), false),
                    new(new int[] {}, new []{1, 2, 3}, DateTime.UtcNow - TimeSpan.FromHours(3), false),
                    new(new [] {4}, new int[]{}, DateTime.UtcNow - TimeSpan.FromHours(0.2), true),
                    new(new int[] {}, new []{4}, DateTime.UtcNow - TimeSpan.FromHours(0.1), true)
                },
                false,
                false
            }
        };
    }
}