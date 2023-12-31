using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Instructor.Authoring;
using Tutor.LearningTasks.API.Dtos.Activities;
using Tutor.LearningTasks.API.Public.Authoring;
using Tutor.LearningTasks.Infrastructure.Database;

namespace Tutor.LearningTasks.Tests.Integration;

public class ActivityTests : BaseLearningTasksIntegrationTest
{
    public ActivityTests(LearningTasksTestFactory factory) : base(factory) { }

    [Fact]
    public void GetById()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();

        var result = ((OkObjectResult) controller.Get(-1).Result).Value as ActivityDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Id.ShouldBe(-1);
        result.Name.ShouldBe("Activity1");
        result.CourseId.ShouldBe(-1);
        result.Guidance.DetailInfo.ShouldBe("detailInfo1");
        result.Subactivities.ShouldNotBeNull();
        result.Subactivities.Count.ShouldBe(2);
        result.Subactivities[0].Order.ShouldBe(1);
        result.Subactivities[0].ChildId.ShouldBe(-3);
        result.Subactivities[1].Order.ShouldBe(2);
        result.Subactivities[1].ChildId.ShouldBe(-4);
        result.Examples.ShouldNotBeNull();
        result.Examples.Count.ShouldBe(2);
        result.Examples[0].Description.ShouldBe("Description1");
        result.Examples[1].Description.ShouldBe("Description2");
    }

    [Fact]
    public void GetByCourse()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();

        var result = ((OkObjectResult) controller.GetByCourse(-1).Result).Value as List<ActivityDto>;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Count.ShouldBe(6);
    }

    [Fact]
    public void Creates()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();
        var newEntity = new ActivityDto
        {
            Name = "test",
            Guidance = new GuidanceDto { DetailInfo = "detailInfo" },
            Subactivities = new List<SubactivityDto> { new SubactivityDto { ChildId = -6, Order = 1 } },
            Examples = new List<ExampleDto> { new ExampleDto { Description = "test" } }
        };
        dbContext.Database.BeginTransaction();

        var result = ((OkObjectResult) controller.Create(-1, newEntity).Result).Value as ActivityDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Name.ShouldBe(newEntity.Name);
        result.CourseId.ShouldBe(newEntity.CourseId);
        result.Guidance.DetailInfo.ShouldBe(newEntity.Guidance.DetailInfo);
        result.Subactivities.ShouldNotBeNull();
        result.Subactivities.Count.ShouldBe(1);
        result.Subactivities[0].Order.ShouldBe(newEntity.Subactivities[0].Order);
        result.Subactivities[0].ChildId.ShouldBe(newEntity.Subactivities[0].ChildId);
        result.Examples.ShouldNotBeNull();
        result.Examples.Count.ShouldBe(1);
        result.Examples[0].Description.ShouldBe(newEntity.Examples[0].Description);
        var storedEntity = dbContext.Activities.Include(a => a.Examples).FirstOrDefault(i => i.Id == result.Id);
        storedEntity.ShouldNotBeNull();
        storedEntity.Name.ShouldBe(newEntity.Name);
        storedEntity.Examples.ShouldNotBeNull();
        storedEntity.Examples.Count.ShouldBe(1);
        storedEntity.Examples[0].Description.ShouldBe(result.Examples[0].Description);
    }

    [Fact]
    public void Wrong_instructor_creates_activity_returns_forbidden()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();
        var newEntity = new ActivityDto
        {
            Name = "test",
            Guidance = new GuidanceDto { DetailInfo = "detailInfo" },
            Subactivities = new List<SubactivityDto> { new SubactivityDto { ChildId = -6, Order = 1 } },
            Examples = new List<ExampleDto> { new ExampleDto { Description = "test" } }
        };
        dbContext.Database.BeginTransaction();

        ActionResult<ActivityDto> result = controller.Create(-2, newEntity).Result;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        (result.Result as ObjectResult)?.StatusCode.ShouldBe(403);
    }

    [Fact]
    public void Creates_with_unexisting_subactivities()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();
        var newEntity = new ActivityDto
        {
            Name = "test",
            Guidance = new GuidanceDto { DetailInfo = "detailInfo" },
            Subactivities = new List<SubactivityDto> { new SubactivityDto { ChildId = 0, Order = 1 } },
            Examples = new List<ExampleDto> { new ExampleDto { Description = "test" } }
        };
        dbContext.Database.BeginTransaction();

        ActionResult<ActivityDto>? result = controller.Create(-1, newEntity).Result;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        (result.Result as ObjectResult)?.StatusCode.ShouldBe(404);
    }

    [Fact]
    public void Updates()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();
        var newEntity = new ActivityDto
        {
            Id = -1,
            Name = "test2",
            Guidance = new GuidanceDto { DetailInfo = "detailInfo2" },
            Subactivities = new List<SubactivityDto> { new SubactivityDto { ChildId = -6, Order = 1 } },
            Examples = new List<ExampleDto> { new ExampleDto { Id = -1, Description = "NewDescription1" }, 
                new ExampleDto { Description = "NewDescription"} }
        };
        dbContext.Database.BeginTransaction();

        var result = ((OkObjectResult) controller.Update(-1, newEntity).Result).Value as ActivityDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Id.ShouldBe(-1);
        result.Name.ShouldBe(newEntity.Name);
        result.CourseId.ShouldBe(newEntity.CourseId);
        result.Guidance.DetailInfo.ShouldBe(newEntity.Guidance.DetailInfo);
        result.Subactivities.ShouldNotBeNull();
        result.Subactivities.Count.ShouldBe(1);
        result.Examples.ShouldNotBeNull();
        result.Examples.Count.ShouldBe(2);
        result.Examples[0].Description.ShouldBe(newEntity.Examples[0].Description);
        result.Examples[1].Description.ShouldBe(newEntity.Examples[1].Description);
        var storedEntity = dbContext.Activities.Include(a => a.Examples).FirstOrDefault(i => i.Id == result.Id);
        storedEntity.ShouldNotBeNull();
        storedEntity.Name.ShouldBe(result.Name);
        storedEntity.Subactivities.ShouldNotBeNull();
        storedEntity.Subactivities.Count.ShouldBe(1);
        storedEntity.Subactivities[0].ChildId.ShouldBe(result.Subactivities[0].ChildId);
        storedEntity.Subactivities[0].Order.ShouldBe(result.Subactivities[0].Order);
        storedEntity.Examples.ShouldNotBeNull();
        storedEntity.Examples.Count.ShouldBe(2);
        storedEntity.Examples[0].Id.ShouldBe(-1);
        storedEntity.Examples[0].Description.ShouldBe(result.Examples[0].Description);
        storedEntity.Examples[1].Description.ShouldBe(result.Examples[1].Description);
    }

    [Fact]
    public void Wrong_instructor_updates_activity_returns_forbidden()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();
        var newEntity = new ActivityDto
        {
            Id = -7,
            Name = "test",
            Guidance = new GuidanceDto { DetailInfo = "detailInfo" },
            Subactivities = new List<SubactivityDto> { new SubactivityDto { ChildId = -6, Order = 1 } },
            Examples = new List<ExampleDto> { new ExampleDto { Description = "test" } }
        };
        dbContext.Database.BeginTransaction();

        ActionResult<ActivityDto> result = controller.Update(-2, newEntity).Result;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        (result.Result as ObjectResult)?.StatusCode.ShouldBe(403);
        var storedEntity = dbContext.Activities.Include(a => a.Examples).FirstOrDefault(i => i.Id == newEntity.Id);
        storedEntity.ShouldNotBeNull();
        storedEntity.Name.ShouldNotBe("test");
    }

    [Fact]
    public void Updates_with_unexisting_subactivities()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();
        var newEntity = new ActivityDto
        {
            Id = -1,
            Name = "test",
            Guidance = new GuidanceDto { DetailInfo = "detailInfo" },
            Subactivities = new List<SubactivityDto> { new SubactivityDto { ChildId = 0, Order = 1 } },
            Examples = new List<ExampleDto> { new ExampleDto { Description = "test" } }
        };
        dbContext.Database.BeginTransaction();

        ActionResult<ActivityDto> result = controller.Update(-1, newEntity).Result;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        (result.Result as ObjectResult)?.StatusCode.ShouldBe(404);
        var storedEntity = dbContext.Activities.Include(a => a.Examples).FirstOrDefault(i => i.Id == newEntity.Id);
        storedEntity.ShouldNotBeNull();
        storedEntity.Name.ShouldNotBe("test");
    }

    [Fact]
    public void Deletes()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();
        dbContext.Database.BeginTransaction();

        var result = (OkResult) controller.Delete(-1, -2);

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(200);
        var storedEntity = dbContext.Activities.FirstOrDefault(i => i.Id == -2);
        storedEntity.ShouldBeNull();
    }

    [Fact]
    public void Wrong_instructor_deletes_activity_returns_forbidden()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();
        dbContext.Database.BeginTransaction();

        var result = (ObjectResult) controller.Delete(-2, -7);

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(403);
        var storedEntity = dbContext.Activities.FirstOrDefault(i => i.Id == -7);
        storedEntity.ShouldNotBeNull();
    }

    [Fact]
    public void Deletes_subactivity_returns_bad_request()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();
        dbContext.Database.BeginTransaction();

        var result = (ObjectResult) controller.Delete(-1, -3);

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(400);
        var storedEntity = dbContext.Activities.FirstOrDefault(i => i.Id == -3);
        storedEntity.ShouldNotBeNull();
    }

    private static ActivityController CreateController(IServiceScope scope)
    {
        return new ActivityController(scope.ServiceProvider.GetRequiredService<IActivityService>())
        {
            ControllerContext = BuildContext("-51", "instructor")
        };
    }
}
