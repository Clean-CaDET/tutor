using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Core.UseCases.Learning.Utilities;
using Tutor.Infrastructure.Security.Authentication.Users;
using Tutor.Web.Controllers.Learners.Learning.Utilities.Feedback;
using Tutor.Core.Domain.LearningUtilities;

namespace Tutor.Web.Controllers.Learners.Learning.Utilities.KnowledgeComponentRate;

[Authorize(Policy = "learnerPolicy")]
[Route("api/learning/rate/")]
public class RatingController : BaseApiController
{
    private readonly IRatingService _ratingService;

    public RatingController(IMapper mapper, IRatingService ratingService) : base(mapper)
    {
        _ratingService = ratingService;
    }
    
    [HttpPost]
    public ActionResult<EmotionsFeedbackDto> RateKnowledgeComponent([FromBody] KnowledgeComponentRatingDto kcRating)
    {
        kcRating.LearnerId = User.LearnerId();
        var result = _ratingService.RateKnowledgeComponent(_mapper.Map<KnowledgeComponentRating>(kcRating));
        return CreateResponse<KnowledgeComponentRating, KnowledgeComponentRatingDto>(result);
    }
}