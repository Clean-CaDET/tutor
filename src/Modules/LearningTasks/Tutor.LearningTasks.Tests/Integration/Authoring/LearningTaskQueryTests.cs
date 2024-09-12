using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Instructor.Authoring;
using Tutor.LearningTasks.API.Dtos.Tasks;
using Tutor.LearningTasks.API.Public.Authoring;

namespace Tutor.LearningTasks.Tests.Integration.Authoring;

[Collection("Sequential")]
public class LearningTaskQueryTests : BaseLearningTasksIntegrationTest
{
    public LearningTaskQueryTests(LearningTasksTestFactory factory) : base(factory) { }

    [Fact]
    public void Gets()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);

        var actionResult = controller.Get(-2, -4).Result;
        var okObjectResult = actionResult as OkObjectResult;
        var result = okObjectResult?.Value as LearningTaskDto;

        result.ShouldNotBeNull();
        result.Id.ShouldBe(-4);
        result.UnitId.ShouldBe(-2);
        result.Name.ShouldBe("FourthTask");
        result.IsTemplate.ShouldBeFalse();
        result.MaxPoints.ShouldBe(10);
        result.Steps.ShouldNotBeNull();
        result.Steps.Count.ShouldBe(1);
        result.Steps[0].Id.ShouldBe(-5);
        result.Steps[0].Order.ShouldBe(1);
        result.Steps[0].SubmissionFormat?.Type.ShouldBe("Link");
        result.Steps[0].Standards?.Count.ShouldBe(1);
        result.Steps[0].Standards?[0].Id.ShouldBe(-5);
        result.Steps[0].Standards?[0].Name.ShouldBe("Standard");
    }

    [Fact]
    public void Non_owner_fails_to_get_task()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);

        var actionResult = controller.Get(-3, -5).Result;
        var objectResult = actionResult as ObjectResult;

        objectResult.ShouldNotBeNull();
        objectResult.StatusCode.ShouldBe(403);
    }

    [Fact]
    public void Gets_by_unit()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);

        var actionResult = controller.GetByUnit(-1).Result;
        var okObjectResult = actionResult as OkObjectResult;
        var result = okObjectResult?.Value as List<LearningTaskDto>;

        result.ShouldNotBeNull();
        result.Count.ShouldBe(2);
        result[0].Id.ShouldBe(-2);
        result[0].UnitId.ShouldBe(-1);
        result[0].Name.ShouldBe("SecondTask");
        result[0].Steps?.Count.ShouldBe(2);
        result[0].Steps?[0].Standards?.Count.ShouldBe(1);
        result[1].Id.ShouldBe(-1);
        result[1].UnitId.ShouldBe(-1);
        result[1].Name.ShouldBe("FirstTask");
        result[1].Steps?.Count.ShouldBe(0);
    }

    [Fact]
    public void Non_owner_fails_to_get_tasks()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);

        var actionResult = controller.GetByUnit(-3).Result;
        var objectResult = actionResult as ObjectResult;

        objectResult.ShouldNotBeNull();
        objectResult.StatusCode.ShouldBe(403);
    }

    private static LearningTaskController CreateController(IServiceScope scope)
    {
        return new LearningTaskController(scope.ServiceProvider.GetRequiredService<ILearningTaskService>())
        {
            ControllerContext = BuildContext("-51", "instructor")
        };
    }
}