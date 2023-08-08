using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Administrator.Courses;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Public.Management;
using Tutor.Courses.Infrastructure.Database;

namespace Tutor.Courses.Tests.Integration.Management;

[Collection("Sequential")]
public class GroupCommandTests : BaseCoursesIntegrationTest
{
    public GroupCommandTests(CoursesTestFactory factory) : base(factory) { }

    [Fact]
    public void Creates()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<CoursesContext>();
        var newEntity = new GroupDto
        {
            Name = "TT-1"
        };
        dbContext.Database.BeginTransaction();

        var result = ((OkObjectResult)controller.Create(-1, newEntity).Result)?.Value as GroupDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Id.ShouldNotBe(0);
        result.Name.ShouldBe(newEntity.Name);
        var storedEntity = dbContext.LearnerGroups.FirstOrDefault(g => g.Name == newEntity.Name);
        storedEntity.ShouldNotBeNull();
        storedEntity.Id.ShouldBe(result.Id);
    }

    [Fact]
    public void Updates()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<CoursesContext>();
        var newEntity = new GroupDto
        {
            Name = "TT-2"
        };
        dbContext.Database.BeginTransaction();

        var result = ((OkObjectResult)controller.Update(-11, newEntity).Result)?.Value as GroupDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Id.ShouldBe(-11);
        result.Name.ShouldBe(newEntity.Name);
        var updatedCourse = dbContext.LearnerGroups.FirstOrDefault(i => i.Name == "TT-2");
        updatedCourse.ShouldNotBeNull();
        var oldCourse = dbContext.LearnerGroups.FirstOrDefault(i => i.Name == "Test Group 2");
        oldCourse.ShouldBeNull();
    }

    [Fact]
    public void Deletes()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<CoursesContext>();
        dbContext.Database.BeginTransaction();

        var result = (OkResult)controller.Delete(-12);

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(200);
        var storedGroup = dbContext.LearnerGroups.FirstOrDefault(i => i.Id == -12);
        storedGroup.ShouldBeNull();
    }

    private static GroupController CreateController(IServiceScope scope)
    {
        return new GroupController(scope.ServiceProvider.GetRequiredService<IGroupService>())
        {
            ControllerContext = BuildContext("0", "administrator")
        };
    }
}