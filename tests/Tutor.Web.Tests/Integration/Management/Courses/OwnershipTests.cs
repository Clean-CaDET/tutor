using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Linq;
using Tutor.Core.UseCases.Management.Stakeholders;
using Tutor.Infrastructure.Database;
using Tutor.Web.Controllers.Administrators.Courses;
using Tutor.Web.Mappings.Stakeholders;
using Xunit;

namespace Tutor.Web.Tests.Integration.Management.Courses;

[Collection("Sequential")]
public class OwnershipTests : BaseWebIntegrationTest
{
    public OwnershipTests(TutorApplicationTestFactory<Startup> factory) : base(factory) { }

    [Fact]
    public void Gets_all()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupController(scope);

        var result = ((OkObjectResult)controller.GetAll(-2).Result)?.Value as List<StakeholderAccountDto>;

        result.ShouldNotBeNull();
        result.Count.ShouldBe(1);
    }

    [Fact]
    public void Creates()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();
        dbContext.Database.BeginTransaction();

        var result = (OkResult)controller.Create(-3, -51);

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(200);
        var storedEntity = dbContext.CourseOwnerships.FirstOrDefault(o => o.Course.Id == -3 && o.InstructorId == -51);
        storedEntity.ShouldNotBeNull();
    }

    [Fact]
    public void Deletes()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();
        dbContext.Database.BeginTransaction();

        var result = (OkResult)controller.Delete(-1, -51);

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(200);
        var storedCourses = dbContext.CourseOwnerships.FirstOrDefault(o => o.Course.Id == -1 && o.InstructorId == -51);
        storedCourses.ShouldBeNull();
    }

    private CourseOwnerController SetupController(IServiceScope scope)
    {
        return new CourseOwnerController(Factory.Services.GetRequiredService<IMapper>(),
            scope.ServiceProvider.GetRequiredService<ICourseOwnershipService>())
        {
            ControllerContext = BuildContext("0", "administrator")
        };
    }
}