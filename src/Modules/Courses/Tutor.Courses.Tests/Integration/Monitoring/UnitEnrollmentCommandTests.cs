﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Instructor.Monitoring;
using Tutor.Courses.API.Dtos.Enrollments;
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
        var startingCount = secondaryDbContext.KcMasteries.Count();

        var enrollmentRequest = new EnrollmentRequestDto
        {
            LearnerIds = new[] { -4, -5 },
            NewEnrollment = new EnrollmentDto
            {
                AvailableFrom = DateTime.UnixEpoch,
                BestBefore = DateTime.UnixEpoch
            }
        };

        var result = ((OkObjectResult)controller.BulkEnroll(-2, enrollmentRequest).Result)?.Value as List<EnrollmentDto>;

        dbContext.ChangeTracker.Clear();
        secondaryDbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Count.ShouldBe(2);
        result.All(e => e.Status == "Active").ShouldBeTrue();
        var newEnrollments = dbContext.UnitEnrollments
            .Where(e => e.KnowledgeUnit.Id == -2 && enrollmentRequest.LearnerIds.Contains(e.LearnerId)).ToList();
        newEnrollments.Count.ShouldBe(2);
        var endingCount = secondaryDbContext.KcMasteries.Count();
        endingCount.ShouldBe(startingCount + 4);
    }
    
    [Fact]
    public void Unenrolls_in_bulk()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-51");
        var dbContext = scope.ServiceProvider.GetRequiredService<CoursesContext>();

        var result = controller.BulkUnenroll(-1, new[] {-4, -5});

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();

        var enrollments = dbContext.UnitEnrollments
            .Where(e => e.KnowledgeUnit.Id == -1 && (e.LearnerId == -4 || e.LearnerId == -5)).ToList();
        enrollments.Count.ShouldBe(2);
        enrollments[0].Status.ShouldBe(EnrollmentStatus.Deactivated);
        enrollments[1].Status.ShouldBe(EnrollmentStatus.Deactivated);
    }

    private static UnitEnrollmentController CreateController(IServiceScope scope, string id)
    {
        return new UnitEnrollmentController(scope.ServiceProvider.GetRequiredService<IEnrollmentService>())
        {
            ControllerContext = BuildContext(id, "instructor")
        };
    }
}