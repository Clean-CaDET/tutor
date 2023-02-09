using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.Domain.CourseIteration;
using Tutor.Core.UseCases.Monitoring;
using Tutor.Infrastructure.Database;
using Tutor.Web.Controllers.Instructors.Monitoring;
using Tutor.Web.Mappings.Enrollments;
using Xunit;

namespace Tutor.Web.Tests.Integration.Monitoring;

[Collection("Sequential")]
public class UnitEnrollmentCommandTests : BaseWebIntegrationTest
{
    public UnitEnrollmentCommandTests(TutorApplicationTestFactory<Startup> factory) : base(factory) {}
    
    [Fact]
    public void Enrolls_in_bulk()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupController(scope, "-51");
        var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();
        var learnerIds = new[] { -4, -5 };

        var result = ((OkObjectResult)controller.BulkEnroll(-2, learnerIds).Result)?.Value as List<UnitEnrollmentDto>;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Count.ShouldBe(2);
        result.All(e => e.Status == "Active").ShouldBeTrue();
        var newEnrollments = dbContext.UnitEnrollments
            .Where(e => e.KnowledgeUnitId == -2 && learnerIds.Contains(e.LearnerId)).ToList();
        newEnrollments.Count.ShouldBe(2);

        var kcIds = new[] { -21, -211 };
        var newKcMasteries = dbContext.KcMasteries
            .Where(kcm => learnerIds.Contains(kcm.LearnerId) && kcIds.Contains(kcm.KnowledgeComponentId)).ToList();
        newKcMasteries.Count.ShouldBe(4);
    }

    [Fact]
    public void Enrolls_single()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupController(scope, "-51");
        var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();

        var result = ((OkObjectResult)controller.Enroll(-2, -1).Result)?.Value as UnitEnrollmentDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Status.ShouldBe("Active");
        var newEnrollments = dbContext.UnitEnrollments
            .Where(e => e.KnowledgeUnitId == -2 && e.LearnerId == -1).ToList();
        newEnrollments.Count.ShouldBe(1);

        var kcIds = new[] { -21, -211 };
        var newKcMasteries = dbContext.KcMasteries
            .Where(kcm => kcm.LearnerId == -1 && kcIds.Contains(kcm.KnowledgeComponentId)).ToList();
        newKcMasteries.Count.ShouldBe(2);
    }

    [Fact]
    public void Unenrolls()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupController(scope, "-51");
        var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();

        var result = controller.Unenroll(-2, -2);

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();

        var enrollment = dbContext.UnitEnrollments
            .Where(e => e.KnowledgeUnitId == -2 && e.LearnerId == -2).ToList();
        enrollment.Count.ShouldBe(1);
        enrollment[0].Status.ShouldBe(EnrollmentStatus.Hidden);

        var kcIds = new[] { -21, -211 };
        var relatedMasteries = dbContext.KcMasteries
            .Where(kcm => kcm.LearnerId == -2 && kcIds.Contains(kcm.KnowledgeComponentId)).ToList();
        relatedMasteries.Count.ShouldBe(2);
    }

    private UnitEnrollmentController SetupController(IServiceScope scope, string id)
    {
        return new UnitEnrollmentController(Factory.Services.GetRequiredService<IMapper>(),
            scope.ServiceProvider.GetRequiredService<IEnrollmentService>())
        {
            ControllerContext = BuildContext(id, "instructor")
        };
    }
}