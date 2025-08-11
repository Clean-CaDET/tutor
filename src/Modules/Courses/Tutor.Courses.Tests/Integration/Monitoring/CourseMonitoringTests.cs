using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Administrator;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Dtos.Groups;
using Tutor.Courses.API.Dtos.Reflections;
using Tutor.Courses.API.Public.Monitoring;

namespace Tutor.Courses.Tests.Integration.Monitoring;

[Collection("Sequential")]
public class CourseMonitoringTests : BaseCoursesIntegrationTest
{
    public CourseMonitoringTests(CoursesTestFactory factory) : base(factory) {}

    [Fact]
    public void GetActiveCourses_ReturnsActiveCourses()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        
        var result = ((OkObjectResult)controller.GetActiveCourses().Result)?.Value as List<CourseDto>;

        result.ShouldNotBeNull();
        result.Count.ShouldBeGreaterThan(0);
        
        var monitoringCourse = result.FirstOrDefault(c => c.Id == -9999);
        monitoringCourse.ShouldNotBeNull();
        monitoringCourse.Name.ShouldBe("Monitoring Course");
        monitoringCourse.Code.ShouldBe("T-9999");
        monitoringCourse.IsArchived.ShouldBe(false);
    }

    [Fact]
    public void GetActiveCourses_IgnoresArchivedCourses()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        
        var result = ((OkObjectResult)controller.GetActiveCourses().Result)?.Value as List<CourseDto>;

        result.ShouldNotBeNull();
        result.Any(c => c.Id == -5).ShouldBe(false); // Archived course should not be returned
    }

    [Fact]
    public void GetGroupOverview_WithValidCourseId_ReturnsGroupsWithLearners()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        
        var result = ((OkObjectResult)controller.GetGroupOverview(-9999).Result)?.Value as List<GroupDto>;

        result.ShouldNotBeNull();
        result.Count.ShouldBe(1);
        
        var group = result.First();
        group.Id.ShouldBe(-9999);
        group.Name.ShouldBe("Monitoring Group 1");
        group.Learners.Count.ShouldBe(3);
        
        // Verify learners have weekly feedback data
        var learnersWithFeedback = group.Learners.Where(l => l.WeeklyFeedback != null && l.WeeklyFeedback.Any()).ToList();
        learnersWithFeedback.Count.ShouldBe(3);
        
        // Verify specific learner feedback
        var learner9999 = group.Learners.FirstOrDefault(l => l.Id == -9999);
        learner9999.ShouldNotBeNull();
        learner9999.WeeklyFeedback.ShouldNotBeNull();
        learner9999.WeeklyFeedback.Count.ShouldBe(1);
        learner9999.WeeklyFeedback.First().Semaphore.ShouldBe(3);
        learner9999.WeeklyFeedback.First().AverageSatisfaction.ShouldBe(4.5);
    }

    [Fact]
    public void GetGroupOverview_WithNonExistentCourseId_ReturnsEmptyList()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        
        var result = ((OkObjectResult)controller.GetGroupOverview(-99999).Result)?.Value as List<GroupDto>;

        result.ShouldNotBeNull();
        result.Count.ShouldBe(0);
    }

    [Fact]
    public void GetReflections_WithValidLearnerAndReflectionIds_ReturnsReflectionsWithSubmissions()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var reflectionIds = new List<int> { -9999, -9998 };
        
        var result = ((OkObjectResult)controller.GetReflections(-2, reflectionIds).Result)?.Value as List<ReflectionDto>;

        result.ShouldNotBeNull();
        result.Count.ShouldBe(2);
        
        // Verify reflection -9999 with submission from learner -2
        var reflection9999 = result.FirstOrDefault(r => r.Id == -9999);
        reflection9999.ShouldNotBeNull();
        reflection9999.Name.ShouldBe("Refleksija za monitoring 1");
        reflection9999.Questions.Count.ShouldBe(2);
        reflection9999.Submissions.ShouldNotBeNull();
        reflection9999.Submissions.Count.ShouldBe(1);
        
        // Verify reflection -9998 with submission from learner -2
        var reflection9998 = result.FirstOrDefault(r => r.Id == -9998);
        reflection9998.ShouldNotBeNull();
        reflection9998.Name.ShouldBe("Refleksija za monitoring 2");
        reflection9998.Questions.Count.ShouldBe(1);
        reflection9998.Submissions.ShouldNotBeNull();
        reflection9998.Submissions.Count.ShouldBe(1);
    }

    [Fact]
    public void GetReflections_WithLearnerWithNoSubmissions_ReturnsReflectionsWithEmptySubmissions()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var reflectionIds = new List<int> { -9999, -9998 };
        
        var result = ((OkObjectResult)controller.GetReflections(-9999, reflectionIds).Result)?.Value as List<ReflectionDto>;

        result.ShouldNotBeNull();
        result.Count.ShouldBe(2);
        result.All(r => r.Submissions?.Count == 0).ShouldBeTrue();
    }

    [Fact]
    public void GetReflections_WithEmptyReflectionIds_ReturnsEmptyList()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var reflectionIds = new List<int>();
        
        var result = ((OkObjectResult)controller.GetReflections(-2, reflectionIds).Result)?.Value as List<ReflectionDto>;

        result.ShouldNotBeNull();
        result.Count.ShouldBe(0);
    }

    [Fact]
    public void GetReflections_WithNonExistentReflectionIds_ReturnsEmptyList()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var reflectionIds = new List<int> { -99999, -99998 };
        
        var result = ((OkObjectResult)controller.GetReflections(-2, reflectionIds).Result)?.Value as List<ReflectionDto>;

        result.ShouldNotBeNull();
        result.Count.ShouldBe(0);
    }

    [Theory]
    [InlineData(-2, -9999, 1)] // Learner -2 has submission for reflection -9999
    [InlineData(-3, -9999, 1)] // Learner -3 has submission for reflection -9999
    [InlineData(-2, -9998, 1)] // Learner -2 has submission for reflection -9998
    [InlineData(-3, -9998, 0)] // Learner -3 has no submission for reflection -9998
    public void GetReflections_WithSingleReflectionId_ReturnsCorrectSubmissionCount(int learnerId, int reflectionId, int expectedSubmissionCount)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var reflectionIds = new List<int> { reflectionId };
        
        var result = ((OkObjectResult)controller.GetReflections(learnerId, reflectionIds).Result)?.Value as List<ReflectionDto>;

        result.ShouldNotBeNull();
        result.Count.ShouldBe(1);
        result.First().Submissions.ShouldNotBeNull();
        result.First().Submissions?.Count.ShouldBe(expectedSubmissionCount);
    }

    private static CourseMonitoringController CreateController(IServiceScope scope)
    {
        return new CourseMonitoringController(scope.ServiceProvider.GetRequiredService<ICourseMonitoringService>())
        {
            ControllerContext = BuildContext("0", "administrator")
        };
    }
}