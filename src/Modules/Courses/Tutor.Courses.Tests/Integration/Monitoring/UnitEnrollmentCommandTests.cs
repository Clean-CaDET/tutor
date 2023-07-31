using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Instructor.Monitoring;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Public.Monitoring;
using Tutor.Courses.Core.Domain;
using Tutor.Courses.Infrastructure.Database;
using Tutor.KnowledgeComponents.Infrastructure.Database;

namespace Tutor.Courses.Tests.Integration.Monitoring;

[Collection("Sequential")]
public class UnitEnrollmentCommandTests : BaseCoursesIntegrationTest
{
    public UnitEnrollmentCommandTests(CoursesTestFactory factory) : base(factory) {}
    
    [Fact]
    public void Enrolls_in_bulk()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-51");
        var dbContext = scope.ServiceProvider.GetRequiredService<CoursesContext>();
        dbContext.Database.BeginTransaction();
        var secondaryDbContext = scope.ServiceProvider.GetRequiredService<KnowledgeComponentsContext>();
        secondaryDbContext.Database.BeginTransaction();

        var enrollmentRequest = new EnrollmentRequestDto
        {
            LearnerIds = new[] { -4, -5 },
            Start = DateTime.UnixEpoch
        };

        var result = ((OkObjectResult)controller.BulkEnroll(-2, enrollmentRequest).Result)?.Value as List<UnitEnrollmentDto>;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Count.ShouldBe(2);
        result.All(e => e.Status == "Active").ShouldBeTrue();
        var newEnrollments = dbContext.UnitEnrollments
            .Where(e => e.KnowledgeUnit.Id == -2 && enrollmentRequest.LearnerIds.Contains(e.LearnerId)).ToList();
        newEnrollments.Count.ShouldBe(2);
    }

    [Fact]
    public void Enrolls_single()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-51");
        var dbContext = scope.ServiceProvider.GetRequiredService<CoursesContext>();
        dbContext.Database.BeginTransaction();
        var secondaryDbContext = scope.ServiceProvider.GetRequiredService<KnowledgeComponentsContext>();
        secondaryDbContext.Database.BeginTransaction();
        var enrollmentRequest = new EnrollmentRequestDto
        {
            LearnerIds = new[] { -1 }
        };

        var result = ((OkObjectResult)controller.Enroll(-2, enrollmentRequest).Result)?.Value as UnitEnrollmentDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Status.ShouldBe("Active");
        var newEnrollments = dbContext.UnitEnrollments
            .Where(e => e.KnowledgeUnit.Id == -2 && e.LearnerId == -1).ToList();
        newEnrollments.Count.ShouldBe(1);
        newEnrollments[0].Status.ShouldBe(EnrollmentStatus.Active);
    }

    [Fact]
    public void Enrolls_single_and_creates_appropriate_masteries()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-51");
        var dbContext = scope.ServiceProvider.GetRequiredService<CoursesContext>();
        dbContext.Database.BeginTransaction();
        var secondaryDbContext = scope.ServiceProvider.GetRequiredService<KnowledgeComponentsContext>();
        secondaryDbContext.Database.BeginTransaction();
        var startingCount = secondaryDbContext.KcMasteries.Count();

        var enrollmentRequest = new EnrollmentRequestDto
        {
            LearnerIds = new[] { -1 }
        };

        controller.Enroll(-1, enrollmentRequest);

        dbContext.ChangeTracker.Clear();
        secondaryDbContext.ChangeTracker.Clear();
        var endingCount = secondaryDbContext.KcMasteries.Count();
        endingCount.ShouldBe(startingCount+6);
    }

    [Fact]
    public void Unenrolls()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-51");
        var dbContext = scope.ServiceProvider.GetRequiredService<CoursesContext>();

        var result = controller.Unenroll(-2, -2);

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();

        var enrollment = dbContext.UnitEnrollments
            .Where(e => e.KnowledgeUnit.Id == -2 && e.LearnerId == -2).ToList();
        enrollment.Count.ShouldBe(1);
        enrollment[0].Status.ShouldBe(EnrollmentStatus.Deactivated);
    }

    private static UnitEnrollmentController CreateController(IServiceScope scope, string id)
    {
        return new UnitEnrollmentController(scope.ServiceProvider.GetRequiredService<IEnrollmentService>())
        {
            ControllerContext = BuildContext(id, "instructor")
        };
    }
}