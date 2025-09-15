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
                new Tuple<int, int>(6, 1),
                new Tuple<int, int>(6, 0),
                new List<UnitProgressRating>(),
                false,
                false
            },
            new object[]
            {
                new Tuple<int, int>(6, 2),
                new Tuple<int, int>(6, 0),
                new List<UnitProgressRating>(),
                true,
                false
            },
            new object[]
            {
                new Tuple<int, int>(6, 1),
                new Tuple<int, int>(6, 1),
                new List<UnitProgressRating>(),
                true,
                true
            },
            new object[]
            {
              new Tuple<int, int>(6, 3),
              new Tuple<int, int>(6, 3),
              new List<UnitProgressRating>
              {
                  new(new [] {1, 2, 3}, Array.Empty<int>(), DateTime.UtcNow - TimeSpan.FromHours(2.1), false),
                  new(Array.Empty<int>(), new []{1, 2, 3}, DateTime.UtcNow - TimeSpan.FromHours(1.1), false)
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
                    new(new [] {1, 2, 3}, Array.Empty<int>(), DateTime.UtcNow - TimeSpan.FromHours(2.1), false),
                    new(Array.Empty<int>(), new []{1, 2, 3}, DateTime.UtcNow - TimeSpan.FromHours(1.1), false)
                },
                false,
                false
            },
            new object[]
            {
                new Tuple<int, int>(6, 6),
                new Tuple<int, int>(6, 3),
                new List<UnitProgressRating>
                {
                    new(new [] {1, 2, 3}, Array.Empty<int>(), DateTime.UtcNow - TimeSpan.FromHours(2.1), false),
                    new(Array.Empty<int>(), new []{1, 2, 3}, DateTime.UtcNow - TimeSpan.FromHours(1.1), false)
                },
                true,
                false
            },
            new object[]
            {
                new Tuple<int, int>(6, 5),
                new Tuple<int, int>(6, 4),
                new List<UnitProgressRating>
                {
                    new(new [] {1, 2, 3}, Array.Empty<int>(), DateTime.UtcNow - TimeSpan.FromHours(2.1), false),
                    new(Array.Empty<int>(), new []{1, 2, 3}, DateTime.UtcNow - TimeSpan.FromHours(1.1), false)
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
                    new(new [] {1, 2, 3}, Array.Empty<int>(), DateTime.UtcNow - TimeSpan.FromHours(2.1), false),
                    new(Array.Empty<int>(), new []{1, 2, 3}, DateTime.UtcNow - TimeSpan.FromHours(1.6), false)
                },
                false,
                true
            },
            new object[]
            {
                new Tuple<int, int>(6, 3),
                new Tuple<int, int>(6, 5),
                new List<UnitProgressRating>
                {
                    new(new [] {1, 2, 3}, Array.Empty<int>(), DateTime.UtcNow - TimeSpan.FromHours(2.1), false),
                    new(Array.Empty<int>(), new []{1, 2, 3}, DateTime.UtcNow - TimeSpan.FromHours(1.6), false)
                },
                false,
                true
            },
            new object[]
            {
                new Tuple<int, int>(6, 5),
                new Tuple<int, int>(6, 3),
                new List<UnitProgressRating>
                {
                    new(new [] {1, 2, 3}, Array.Empty<int>(), DateTime.UtcNow - TimeSpan.FromHours(2.1), false),
                    new(Array.Empty<int>(), new []{1, 2, 3}, DateTime.UtcNow - TimeSpan.FromHours(1.6), false)
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
                    new(new [] {1, 2, 3}, Array.Empty<int>(), DateTime.UtcNow - TimeSpan.FromHours(2.1), false),
                    new(Array.Empty<int>(), new []{1, 2, 3}, DateTime.UtcNow - TimeSpan.FromHours(0.6), false)
                },
                false,
                false
            },
            new object[]
            {
                new Tuple<int, int>(6, 6),
                new Tuple<int, int>(6, 4),
                new List<UnitProgressRating>
                {
                    new(new [] {1, 2, 3}, Array.Empty<int>(), DateTime.UtcNow - TimeSpan.FromHours(2.1), false),
                    new(Array.Empty<int>(), new []{1, 2, 3}, DateTime.UtcNow - TimeSpan.FromHours(0.6), false)
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
                    new(new [] {1, 2, 3}, Array.Empty<int>(), DateTime.UtcNow - TimeSpan.FromHours(2.1), false),
                    new(Array.Empty<int>(), new []{1, 2, 3}, DateTime.UtcNow - TimeSpan.FromHours(1.1), false),
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
                    new(new [] {1, 2, 3}, Array.Empty<int>(), DateTime.UtcNow - TimeSpan.FromHours(2.1), false),
                    new(Array.Empty<int>(), new []{1, 2, 3}, DateTime.UtcNow - TimeSpan.FromHours(1.1), false),
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
                    new(new [] {1, 2, 3}, Array.Empty<int>(), DateTime.UtcNow - TimeSpan.FromHours(2.1), false),
                    new(Array.Empty<int>(), new []{1, 2, 3}, DateTime.UtcNow - TimeSpan.FromHours(1.1), false),
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
                    new(new [] {1, 2, 3}, Array.Empty<int>(), DateTime.UtcNow - TimeSpan.FromHours(4.1), false),
                    new(Array.Empty<int>(), new []{1, 2, 3}, DateTime.UtcNow - TimeSpan.FromHours(3.1), false),
                    new(new [] {4, 5, 6}, new []{4, 5, 6}, DateTime.UtcNow - TimeSpan.FromHours(2.1), false)
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
                    new(new [] {1, 2, 3}, Array.Empty<int>(), DateTime.UtcNow - TimeSpan.FromHours(4.1), false),
                    new(Array.Empty<int>(), new []{1, 2, 3}, DateTime.UtcNow - TimeSpan.FromHours(3.1), false),
                    new(new [] {4}, Array.Empty<int>(), DateTime.UtcNow - TimeSpan.FromHours(0.1), true)
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
                    new(new [] {1, 2, 3}, Array.Empty<int>(), DateTime.UtcNow - TimeSpan.FromHours(4.1), false),
                    new(Array.Empty<int>(), new []{1, 2, 3}, DateTime.UtcNow - TimeSpan.FromHours(3.1), false),
                    new(new [] {4}, Array.Empty<int>(), DateTime.UtcNow - TimeSpan.FromHours(0.2), true),
                    new(Array.Empty<int>(), new []{4}, DateTime.UtcNow - TimeSpan.FromHours(0.1), true)
                },
                false,
                false
            }
        };
    }
}