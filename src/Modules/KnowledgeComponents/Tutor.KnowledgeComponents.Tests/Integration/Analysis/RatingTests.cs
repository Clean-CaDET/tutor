using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Learner;
using Tutor.KnowledgeComponents.API.Dtos.KnowledgeAnalytics;
using Tutor.KnowledgeComponents.API.Public.Analysis;
using Tutor.KnowledgeComponents.Infrastructure.Database;

namespace Tutor.KnowledgeComponents.Tests.Integration.Analysis;

[Collection("Sequential")]
public class RatingTests : BaseKnowledgeComponentsIntegrationTest
{
    public RatingTests(KnowledgeComponentsTestFactory factory) : base(factory) {}
    
    [Fact]
    public void Creates_new_rating()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-2");
        var dbContext = scope.ServiceProvider.GetRequiredService<KnowledgeComponentsContext>();
        var tags = new[] {"Težina zadataka", "Jasnoća zadataka"};
        var kcRating = new KnowledgeComponentRatingDto { KnowledgeComponentId = -10, Rating = 5, Tags = tags};
        dbContext.Database.BeginTransaction();

        var result = ((OkObjectResult)controller.RateKnowledgeComponent(kcRating).Result)?.Value as KnowledgeComponentRatingDto;
        var rating = dbContext.KnowledgeComponentRatings.FirstOrDefault();
        
        result.Tags[0].ShouldBe("Težina zadataka");
        result.Tags[1].ShouldBe("Jasnoća zadataka");
        rating.Rating.ShouldBe(5);
    }
    
    private static RatingController CreateController(IServiceScope scope, string id)
    {
        return new RatingController(scope.ServiceProvider.GetRequiredService<IRatingService>())
        {
            ControllerContext = BuildContext(id, "learner")
        };
    }
}