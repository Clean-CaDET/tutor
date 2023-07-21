using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Learner.Utilities;
using Tutor.LearningUtils.API.Dtos;
using Tutor.LearningUtils.API.Interfaces;
using Tutor.LearningUtils.Infrastructure.Database;
using Xunit;

namespace Tutor.LearningUtils.Tests.Integration;

public class RatingTests : BaseLearningUtilsIntegrationTest
{
    public RatingTests(LearningUtilsTestFactory factory) : base(factory) {}
    
    [Fact]
    public void Creates_new_rating()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupRatingController(scope, "-2");
        var dbContext = scope.ServiceProvider.GetRequiredService<LearningUtilitiesContext>();
        var tags = new[] {"Težina zadataka", "Jasnoća zadataka"};
        var kcRating = new KnowledgeComponentRatingDto { KnowledgeComponentId = -10, Rating = 5, Tags = tags};
        dbContext.Database.BeginTransaction();

        var result = ((OkObjectResult)controller.RateKnowledgeComponent(kcRating).Result)?.Value as KnowledgeComponentRatingDto;
        var rating = dbContext.KnowledgeComponentRatings.FirstOrDefault();
        
        result.Tags[0].ShouldBe("Težina zadataka");
        result.Tags[1].ShouldBe("Jasnoća zadataka");
        rating.Rating.ShouldBe(5);
    }
    
    private static RatingController SetupRatingController(IServiceScope scope, string id)
    {
        return new RatingController(scope.ServiceProvider.GetRequiredService<IRatingService>())
        {
            ControllerContext = BuildContext(id, "learner")
        };
    }
}