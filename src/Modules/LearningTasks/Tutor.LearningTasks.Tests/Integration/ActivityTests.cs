using Microsoft.AspNetCore.Mvc;
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

        var actionResult = controller.Get(-1).Result;
        var okObjectResult = actionResult as OkObjectResult;
        var result = okObjectResult?.Value as ActivityDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Id.ShouldBe(-1);
        result.Code.ShouldBe("C1-A1");
        result.Name.ShouldBe("Activity1");
        result.CourseId.ShouldBe(-1);
        result.Guidance.Description.ShouldBe("description1");
        result.Examples.ShouldNotBeNull();
        result.Examples.Count.ShouldBe(2);
        result.Examples[0].Code.ShouldBe("C1A1E1");
        result.Examples[0].Description.ShouldBe("Description1");
        result.Examples[1].Code.ShouldBe("C1A1E2");
        result.Examples[1].Description.ShouldBe("Description2");
        result.Standards.ShouldNotBeNull();
        result.Standards.Count.ShouldBe(2);
        result.Standards[0].Name.ShouldBe("Standard1");
        result.Standards[0].Description.ShouldBe("Standard description 1");
        result.Standards[1].Name.ShouldBe("Standard2");
        result.Standards[1].Description.ShouldBe("Standard description 2");
        result.Subactivities.ShouldNotBeNull();
        result.Subactivities.Count.ShouldBe(2);
        result.Subactivities[0].Order.ShouldBe(1);
        result.Subactivities[0].ChildId.ShouldBe(-3);
        result.Subactivities[1].Order.ShouldBe(2);
        result.Subactivities[1].ChildId.ShouldBe(-4);
    }

    [Fact]
    public void GetByCourse()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();

        var actionResult = controller.GetByCourse(-1).Result;
        var okObjectResult = actionResult as OkObjectResult;
        var result = okObjectResult?.Value as List<ActivityDto>;

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
            Code = "C1-A8",
            Name = "test",
            Guidance = new GuidanceDto { Description = "description" },
            Examples = new List<ExampleDto> { new ExampleDto { Code = "C1A8E1", Description = "test" } },
            Standards = new List<ActivityStandardDto> { new ActivityStandardDto { Name = "Standard1", Description = "Standard description 1"} },
            Subactivities = new List<SubactivityDto> { new SubactivityDto { ChildId = -6, Order = 1 } }
        };
        dbContext.Database.BeginTransaction();

        var actionResult = controller.Create(-1, newEntity).Result;
        var okObjectResult = actionResult as OkObjectResult;
        var result = okObjectResult?.Value as ActivityDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Code.ShouldBe(newEntity.Code);
        result.Name.ShouldBe(newEntity.Name);
        result.CourseId.ShouldBe(newEntity.CourseId);
        result.Guidance.Description.ShouldBe(newEntity.Guidance.Description);
        result.Examples.ShouldNotBeNull();
        result.Examples.Count.ShouldBe(1);
        result.Examples[0].Code.ShouldBe(newEntity.Examples[0].Code);
        result.Examples[0].Description.ShouldBe(newEntity.Examples[0].Description);
        result.Standards.ShouldNotBeNull();
        result.Standards.Count.ShouldBe(1);
        result.Standards[0].Name.ShouldBe(newEntity.Standards[0].Name);
        result.Standards[0].Description.ShouldBe(newEntity.Standards[0].Description);
        result.Subactivities.ShouldNotBeNull();
        result.Subactivities.Count.ShouldBe(1);
        result.Subactivities[0].Order.ShouldBe(newEntity.Subactivities[0].Order);
        result.Subactivities[0].ChildId.ShouldBe(newEntity.Subactivities[0].ChildId);
        var storedEntity = dbContext.Activities.FirstOrDefault(i => i.Id == result.Id);
        storedEntity.ShouldNotBeNull();
        storedEntity.Name.ShouldBe(newEntity.Name);
        storedEntity.Examples.ShouldNotBeNull();
        storedEntity.Examples.Count.ShouldBe(1);
        storedEntity.Examples[0].Code.ShouldBe(result.Examples[0].Code);
        storedEntity.Examples[0].Description.ShouldBe(result.Examples[0].Description);
        storedEntity.Standards.ShouldNotBeNull();
        storedEntity.Standards.Count.ShouldBe(1);
        storedEntity.Standards[0].Name.ShouldBe(result.Standards[0].Name);
        storedEntity.Standards[0].Description.ShouldBe(result.Standards[0].Description);
        storedEntity.Subactivities.ShouldNotBeNull();
        storedEntity.Subactivities[0].Order.ShouldBe(result.Subactivities[0].Order);
        storedEntity.Subactivities[0].ChildId.ShouldBe(result.Subactivities[0].ChildId);
    }

    [Fact]
    public void Creates_with_existing_value_for_code()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();
        var newEntity = new ActivityDto
        {
            Code = "C1-A1",
            Name = "test",
            Guidance = new GuidanceDto { Description = "description" },
            Examples = new List<ExampleDto> { new ExampleDto { Code = "C1A8E1", Description = "test" } },
            Subactivities = new List<SubactivityDto> { new SubactivityDto { ChildId = -6, Order = 1 } }
        };
        dbContext.Database.BeginTransaction();

        var actionResult = controller.Create(-1, newEntity).Result;
        var objectResult = actionResult as ObjectResult;

        dbContext.ChangeTracker.Clear();
        objectResult.ShouldNotBeNull();
        objectResult.StatusCode.ShouldBe(409);
    }

    [Fact]
    public void Wrong_instructor_creates_activity_returns_forbidden()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningTasksContext>();
        var newEntity = new ActivityDto
        {
            Code = "C1-A9",
            Name = "test",
            Guidance = new GuidanceDto { Description = "detailInfo" },
            Examples = new List<ExampleDto> { new ExampleDto { Code = "C1A9E2", Description = "test" } },
            Subactivities = new List<SubactivityDto> { new SubactivityDto { ChildId = -6, Order = 1 } }
        };
        dbContext.Database.BeginTransaction();

        var actionResult = controller.Create(-2, newEntity).Result;
        var objectResult = actionResult as ObjectResult;

        dbContext.ChangeTracker.Clear();
        objectResult.ShouldNotBeNull();
        objectResult.StatusCode.ShouldBe(403);
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
            Code = "C1-A1",
            Name = "test2",
            Guidance = new GuidanceDto { Description = "detailInfo2" },
            Examples = new List<ExampleDto> { new ExampleDto { Code = "C1A1E2", Description = "NewDescription1" }, 
                new ExampleDto { Code = "C1A1E3", Description = "NewDescription"} },
            Standards = new List<ActivityStandardDto> { new ActivityStandardDto { Name = "NewStandard", Description = "new description"} },
            Subactivities = new List<SubactivityDto> { new SubactivityDto { ChildId = -6, Order = 1 } }
        };
        dbContext.Database.BeginTransaction();

        var actionResult = controller.Update(-1, newEntity).Result;
        var okObjectResult = actionResult as OkObjectResult;
        var result = okObjectResult?.Value as ActivityDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Id.ShouldBe(-1);
        result.Code.ShouldBe(newEntity.Code);
        result.Name.ShouldBe(newEntity.Name);
        result.CourseId.ShouldBe(newEntity.CourseId);
        result.Guidance.Description.ShouldBe(newEntity.Guidance.Description);
        result.Examples.ShouldNotBeNull();
        result.Examples.Count.ShouldBe(2);
        result.Examples[0].Description.ShouldBe(newEntity.Examples[0].Description);
        result.Examples[1].Description.ShouldBe(newEntity.Examples[1].Description);
        result.Standards.ShouldNotBeNull();
        result.Standards.Count.ShouldBe(1);
        result.Standards[0].Name.ShouldBe(newEntity.Standards[0].Name);
        result.Standards[0].Description.ShouldBe(newEntity.Standards[0].Description);
        result.Subactivities.ShouldNotBeNull();
        result.Subactivities.Count.ShouldBe(1);
        result.Subactivities[0].ChildId.ShouldBe(newEntity.Subactivities[0].ChildId);
        result.Subactivities[0].Order.ShouldBe(newEntity.Subactivities[0].Order);
        var storedEntity = dbContext.Activities.FirstOrDefault(i => i.Id == result.Id);
        storedEntity.ShouldNotBeNull();
        storedEntity.Name.ShouldBe(result.Name);
        storedEntity.Examples.ShouldNotBeNull();
        storedEntity.Examples.Count.ShouldBe(2);
        storedEntity.Examples[0].Code.ShouldBe("C1A1E2");
        storedEntity.Examples[0].Description.ShouldBe(result.Examples[0].Description);
        storedEntity.Examples[1].Code.ShouldBe("C1A1E3");
        storedEntity.Examples[1].Description.ShouldBe(result.Examples[1].Description);
        storedEntity.Standards.ShouldNotBeNull();
        storedEntity.Standards.Count.ShouldBe(1);
        storedEntity.Standards[0].Name.ShouldBe(result.Standards[0].Name);
        storedEntity.Standards[0].Description.ShouldBe(result.Standards[0].Description);
        storedEntity.Subactivities.ShouldNotBeNull();
        storedEntity.Subactivities.Count.ShouldBe(1);
        storedEntity.Subactivities[0].ChildId.ShouldBe(result.Subactivities[0].ChildId);
        storedEntity.Subactivities[0].Order.ShouldBe(result.Subactivities[0].Order);
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
            Code = "C2-A7",
            Name = "test",
            Guidance = new GuidanceDto { Description = "detailInfo" },
            Examples = new List<ExampleDto> { new ExampleDto { Code = "C2A7E1", Description = "test" } },
            Subactivities = new List<SubactivityDto> { new SubactivityDto { ChildId = -6, Order = 1 } }
        };
        dbContext.Database.BeginTransaction();

        var actionResult = controller.Update(-2, newEntity).Result;
        var objectResult = actionResult as ObjectResult;

        dbContext.ChangeTracker.Clear();
        objectResult.ShouldNotBeNull();
        objectResult.StatusCode.ShouldBe(403);
        var storedEntity = dbContext.Activities.FirstOrDefault(i => i.Id == newEntity.Id);
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
