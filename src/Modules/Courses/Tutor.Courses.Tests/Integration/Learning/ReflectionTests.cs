using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Learner.Learning;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Dtos.Reflections;
using Tutor.Courses.API.Public.Learning;
using Tutor.Courses.Core.Domain;
using Tutor.Courses.Infrastructure.Database;

namespace Tutor.Courses.Tests.Integration.Learning;

[Collection("Sequential")]
public class ReflectionTests : BaseCoursesIntegrationTest
{
    public ReflectionTests(CoursesTestFactory factory) : base(factory) { }

    [Theory]
    [InlineData("-2", -2, 1, 5)]
    [InlineData("-2", -3, 1, 3)]
    public void Gets_reflections_for_enrolled_unit(string learnerId, int unitId, int expectedReflectionCount, int expectedQuestionCount)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, learnerId);
        var result = ((OkObjectResult)controller.GetAll(unitId).Result!).Value as List<ReflectionDto>;

        result.ShouldNotBeNull();
        result.Count.ShouldBe(expectedReflectionCount);
        result[0].Questions.Count.ShouldBe(expectedQuestionCount);
    }

    [Fact]
    public void Does_not_retrieve_reflections_for_unenrolled_unit()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-1");

        var response = (ObjectResult)controller.GetAll(-2).Result!;

        response.ShouldNotBeNull();
        response.StatusCode.ShouldBe(403);
    }

    public static IEnumerable<object[]> UnitIds()
    {
        return new List<object[]>
        {
            new object[]
            {
                -1,
                new List<int> {-4},
                new List<int> {-4},
            },
            new object[]
            {
                -50,
                new List<int> {-50, -51},
                new List<int> {-50}
            }
        };
    }

    private static ReflectionController CreateController(IServiceScope scope, string id)
    {
        return new ReflectionController(scope.ServiceProvider.GetRequiredService<IReflectionService>())
        {
            ControllerContext = BuildContext(id, "learner")
        };
    }
}