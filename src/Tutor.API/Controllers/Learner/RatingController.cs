using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.KnowledgeComponents.API.Dtos.KnowledgeAnalytics;
using Tutor.KnowledgeComponents.API.Public.Analysis;
using Tutor.LearningUtils.API.Dtos.Feedback;
using Tutor.Stakeholders.Infrastructure.Authentication;

namespace Tutor.API.Controllers.Learner;

[Authorize(Policy = "learnerPolicy")]
[Route("api/analysis/knowledge-components/rating/")]
public class RatingController : BaseApiController
{
    private readonly IRatingService _ratingService;
    public RatingController(IRatingService ratingService)
    {
        _ratingService = ratingService;
    }

    [HttpPost]
    public ActionResult<EmotionsFeedbackDto> RateKnowledgeComponent([FromBody] KnowledgeComponentRatingDto kcKnowledgeComponentRating)
    {
        kcKnowledgeComponentRating.LearnerId = User.LearnerId();
        var result = _ratingService.Create(kcKnowledgeComponentRating, kcKnowledgeComponentRating.LearnerId);
        return CreateResponse(result);
    }
}