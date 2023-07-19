using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.LearningUtils.API.Dtos;
using Tutor.LearningUtils.API.Dtos.Feedback;
using Tutor.LearningUtils.API.Interfaces;
using Tutor.Stakeholders.Infrastructure.Authentication;

namespace Tutor.API.Controllers.Learner.Utilities
{
    [Authorize(Policy = "learnerPolicy")]
    [Route("api/learning/rate/")]
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
            var result = _ratingService.RateKnowledgeComponent(kcKnowledgeComponentRating);
            return CreateResponse(result);
        }
    }
}
