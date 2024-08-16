using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Learner;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Public.Learning;

namespace Tutor.Courses.Tests.Integration.Learning;

[Collection("Sequential")]
public class EnrolledCourseTests : BaseCoursesIntegrationTest
{
    public EnrolledCourseTests(CoursesTestFactory factory) : base(factory) { }

    [Theory]
    [InlineData("-1", 2)]
    [InlineData("-2", 2)]
    public void Retrieves_enrolled_courses(string learnerId, int expectedCourseCount)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, learnerId);
        var result = ((OkObjectResult)controller.GetEnrolledCourses(0, 0).Result)?.Value as PagedResult<CourseDto>;

        result.ShouldNotBeNull();
        result.Results.Count.ShouldBe(expectedCourseCount);
        result.TotalCount.ShouldBe(expectedCourseCount);
    }

    [Theory]
    [InlineData(-2, -1, 2)]
    [InlineData(-1, -1, 0)]
    public void Retrieves_course_with_enrolled_and_active_units(int learnerId, int courseId, int expectedUnitCount)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, learnerId.ToString());

        var course = ((OkObjectResult)controller.GetCourseWithEnrolledAndActiveUnits(courseId).Result)?.Value as CourseDto;

        course.ShouldNotBeNull();
        course.KnowledgeUnits.Count.ShouldBe(expectedUnitCount);
    }

    [Fact]
    public void Does_not_retrieve_archived_course()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-1");

        var response = (ObjectResult)controller.GetCourseWithEnrolledAndActiveUnits(-5).Result;

        response.StatusCode.ShouldBe(403);
    }

    [Fact]
    public void Retrieves_unit()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-2");

        var unit = ((OkObjectResult)controller.GetEnrolledAndActiveUnit(-1).Result)?.Value as KnowledgeUnitDto;

        unit.ShouldNotBeNull();
        unit.Id.ShouldBe(-1);
    }

    [Theory]
    [MemberData(nameof(UnitIds))]
    public void Retrieves_mastered_unit_ids(List<int> unitIds, int expectedCount)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-4");

        var masteredUnitIds = ((OkObjectResult)controller.GetMasteredUnitIds(unitIds).Result)?.Value as List<int>;

        masteredUnitIds.ShouldNotBeNull();
        masteredUnitIds.Count.ShouldBe(expectedCount);
    }

    public static IEnumerable<object[]> UnitIds()
    {
        return new List<object[]>
        {
            new object[]
            {
                new List<int> {-4},
                1
            },
            new object[]
            {
                new List<int> {-50, -51},
                1
            },
            new object[]
            {
                new List<int> {-4, -50, -51},
                2
            }
        };
    }

    private static EnrolledCourseController CreateController(IServiceScope scope, string id)
    {
        return new EnrolledCourseController(scope.ServiceProvider.GetRequiredService<IEnrolledCourseService>(), scope.ServiceProvider.GetRequiredService<IUnitProgressService>())
        {
            ControllerContext = BuildContext(id, "learner")
        };
    }
}