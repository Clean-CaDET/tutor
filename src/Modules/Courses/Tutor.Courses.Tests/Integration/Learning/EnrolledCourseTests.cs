using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Learner;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Public.Learning;
using Tutor.Courses.Core.Domain;
using Tutor.Courses.Infrastructure.Database;

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

        var course = ((OkObjectResult)controller.GetCourseWithAccessibleUnits(courseId).Result)?.Value as CourseDto;

        course.ShouldNotBeNull();
        course.KnowledgeUnits.Count.ShouldBe(expectedUnitCount);
    }

    [Fact]
    public void Does_not_retrieve_archived_course()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-1");

        var response = (ObjectResult)controller.GetCourseWithAccessibleUnits(-5).Result;

        response.StatusCode.ShouldBe(403);
    }

    [Fact]
    public void Retrieves_unit()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-2");

        var unit = ((OkObjectResult)controller.GetAccessibleUnit(-1).Result)?.Value as KnowledgeUnitDto;

        unit.ShouldNotBeNull();
        unit.Id.ShouldBe(-1);
    }

    [Theory]
    [MemberData(nameof(UnitIds))]
    public void Retrieves_mastered_unit_ids(int courseId, List<int> unitIds, List<int> expectedUnits)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-4");
        var dbContext = scope.ServiceProvider.GetRequiredService<CoursesContext>();
        dbContext.Database.BeginTransaction();
        
        var masteredUnitIds = ((OkObjectResult)controller.CompleteMasteredUnits(courseId, unitIds).Result)?.Value as List<int>;

        dbContext.ChangeTracker.Clear();
        masteredUnitIds.ShouldNotBeNull();
        masteredUnitIds.Count.ShouldBe(expectedUnits.Count);
        masteredUnitIds.All(expectedUnits.Contains).ShouldBeTrue();
        var storedEnrollments =
            dbContext.UnitEnrollments.Where(e => expectedUnits.Contains(e.KnowledgeUnitId)).ToList();
        storedEnrollments.ShouldNotBeNull();
        storedEnrollments.All(e => e.Status == EnrollmentStatus.Completed).ShouldBeTrue();
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

    private static EnrolledCourseController CreateController(IServiceScope scope, string id)
    {
        return new EnrolledCourseController(scope.ServiceProvider.GetRequiredService<IEnrolledCourseService>(), scope.ServiceProvider.GetRequiredService<IUnitProgressService>())
        {
            ControllerContext = BuildContext(id, "learner")
        };
    }
}