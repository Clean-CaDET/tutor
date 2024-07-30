using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Learner.Analytics;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Public.Analysis;
using Tutor.Courses.Infrastructure.Database;

namespace Tutor.Courses.Tests.Integration.Analysis;

[Collection("Sequential")]
public class UnitProgressRatingTests : BaseCoursesIntegrationTest
{
    public UnitProgressRatingTests(CoursesTestFactory factory) : base(factory) {}
    
    [Fact]
    public void Creates_new_rating()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-2");
        var dbContext = scope.ServiceProvider.GetRequiredService<CoursesContext>();
        var kcRating = new UnitProgressRatingDto
        {
            KnowledgeUnitId = -1, CompletedKcIds = Array.Empty<int>(), CompletedTaskIds = Array.Empty<int>(), Feedback = "{\"learnerProgress\":2,\"instructionClarity\":2,\"assessmentClarity\":2,\"taskChallenge\":\"0\",\"comment\":\"Super je.\"}"
        };
        dbContext.Database.BeginTransaction();

        var result = ((OkObjectResult)controller.Rate(kcRating).Result)?.Value as UnitProgressRatingDto;
        var rating = dbContext.UnitProgressRating.FirstOrDefault();

        result.ShouldNotBeNull();
        result.Feedback.ShouldBe("{\"learnerProgress\":2,\"instructionClarity\":2,\"assessmentClarity\":2,\"taskChallenge\":\"0\",\"comment\":\"Super je.\"}");
        rating.ShouldNotBeNull();
        rating.Feedback.ShouldBe("{\"learnerProgress\":2,\"instructionClarity\":2,\"assessmentClarity\":2,\"taskChallenge\":\"0\",\"comment\":\"Super je.\"}");
        rating.LearnerId.ShouldBe(-2);
    }
    
    private static UnitProgressRatingController CreateController(IServiceScope scope, string id)
    {
        return new UnitProgressRatingController(scope.ServiceProvider.GetRequiredService<IUnitProgressRatingService>())
        {
            ControllerContext = BuildContext(id, "learner")
        };
    }
}