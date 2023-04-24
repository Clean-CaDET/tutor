using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Linq;
using Tutor.Core.UseCases.Management.Courses;
using Tutor.Infrastructure.Database;
using Tutor.Web.Controllers.Administrators.Courses;
using Tutor.Web.Mappings.Knowledge.DTOs;
using Xunit;

namespace Tutor.Web.Tests.Integration.Management.Courses;

[Collection("Sequential")]
public class CourseCommandTests : BaseWebIntegrationTest
{
    public CourseCommandTests(TutorApplicationTestFactory<Startup> factory) : base(factory) { }

    [Fact]
    public void Creates()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();
        var newEntity = new CourseDto
        {
            Code = "TT-1",
            Name = "Test-1"
        };
        dbContext.Database.BeginTransaction();

        var result = ((OkObjectResult)controller.Create(newEntity).Result)?.Value as CourseDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Id.ShouldNotBe(0);
        result.Code.ShouldBe(newEntity.Code);
        result.Name.ShouldBe(newEntity.Name);
        var storedEntity = dbContext.Courses.FirstOrDefault(i => i.Code == newEntity.Code);
        storedEntity.ShouldNotBeNull();
        storedEntity.Id.ShouldBe(result.Id);
        var storedLearnerGroup = dbContext.LearnerGroups.FirstOrDefault(g => g.Name == "Group 1");
        storedLearnerGroup.ShouldNotBeNull();
        storedLearnerGroup.CourseId.ShouldBe(result.Id);
    }

    [Fact]
    public void Updates()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();
        var updatedEntity = new CourseDto
        {
            Id = -1,
            Code = "TT-2",
            Name = "Test-2",
            Description = "Test-2"
        };
        dbContext.Database.BeginTransaction();

        var result = ((OkObjectResult)controller.Update(updatedEntity).Result)?.Value as CourseDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Id.ShouldBe(-1);
        result.Code.ShouldBe(updatedEntity.Code);
        result.Name.ShouldBe(updatedEntity.Name);
        result.Description.ShouldBe(updatedEntity.Description);
        var updatedCourse = dbContext.Courses.FirstOrDefault(i => i.Code == "TT-2");
        updatedCourse.ShouldNotBeNull();
        var oldCourse = dbContext.Courses.FirstOrDefault(i => i.Code == "T-1");
        oldCourse.ShouldBeNull();
    }

    [Fact]
    public void Update_fails_invalid_id()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();
        var updatedEntity = new CourseDto
        {
            Id = -1000
        };

        var result = (ObjectResult)controller.Update(updatedEntity).Result;

        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(409);
    }

    [Fact]
    public void Archives()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();
        dbContext.Database.BeginTransaction();

        var result = ((OkObjectResult)controller.Archive(-2, true).Result)?.Value as CourseDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.IsArchived.ShouldBe(true);
        var storedCourse = dbContext.Courses.FirstOrDefault(i => i.Id == -2);
        storedCourse.ShouldNotBeNull();
        storedCourse.IsArchived.ShouldBe(true);
    }

    [Fact]
    public void Deletes_empty_course()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();
        dbContext.Database.BeginTransaction();

        var result = (OkResult)controller.Delete(-3);

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(200);
        var storedCourse = dbContext.Courses.FirstOrDefault(i => i.Id == -3);
        storedCourse.ShouldBeNull();
    }

    [Fact]
    public void Deletes_course_with_ownerships()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();
        var instructorIds = dbContext.CourseOwnerships.Include(co => co.Course).Where(co => co.Id == -4).Select(co => co.InstructorId).ToList();
        dbContext.Database.BeginTransaction();

        var result = (OkResult)controller.Delete(-4);

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(200);
        var storedCourse = dbContext.Courses.FirstOrDefault(i => i.Id == -4);
        storedCourse.ShouldBeNull();
        var storedOwnerships = dbContext.CourseOwnerships.Include(co => co.Course).Where(co => co.Course.Id == -4);
        storedOwnerships.Count().ShouldBe(0);
        foreach (var id in instructorIds)
        {
            var instructor = dbContext.Instructors.Where(i => i.Id == id);
            instructor.ShouldNotBeNull();
        }
    }

    [Fact]
    public void Delete_fails_invalid_id()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();

        var result = (ObjectResult)controller.Delete(-1000);

        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(404);
    }

    [Fact]
    public void Delete_fails_existing_units()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();

        var result = (ObjectResult)controller.Delete(-1);

        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(403);
        var storedCourse = dbContext.Courses.FirstOrDefault(i => i.Id == -1);
        storedCourse.ShouldNotBeNull();
    }

    private CourseController SetupController(IServiceScope scope)
    {
        return new CourseController(Factory.Services.GetRequiredService<IMapper>(),
            scope.ServiceProvider.GetRequiredService<ICourseService>())
        {
            ControllerContext = BuildContext("0", "administrator")
        };
    }
}