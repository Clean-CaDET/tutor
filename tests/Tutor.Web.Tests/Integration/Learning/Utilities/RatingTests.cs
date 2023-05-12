
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.Core.UseCases.Learning.Utilities;
using Tutor.Infrastructure.Database;
using Tutor.Web.Controllers.Learners.Learning.Utilities.KnowledgeComponentRate;
using Xunit;

namespace Tutor.Web.Tests.Integration.Learning.Utilities;

public class RatingTests : BaseWebIntegrationTest
{
    public RatingTests(TutorApplicationTestFactory<Startup> factory) : base(factory) {}
    
    [Fact]
    public void Creates_new_rating()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupRatingController(scope, "-2");
        var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();
        var tags = new[] {"test", "test"};
        var kcRating = new KnowledgeComponentRatingDto { KnowledgeComponentId = -10, Rating = 5, Tags = tags};
        dbContext.Database.BeginTransaction();

        var result = ((OkObjectResult)controller.RateKnowledgeComponent(kcRating).Result)?.Value as KnowledgeComponentRatingDto;
        
        result.Rating.ShouldBe(5);
    }
    
    private static RatingController SetupRatingController(IServiceScope scope, string id)
    {
        return new RatingController(scope.ServiceProvider.GetRequiredService<IMapper>(),
            scope.ServiceProvider.GetRequiredService<IRatingService>())
        {
            ControllerContext = BuildContext(id, "learner")
        };
    }
}