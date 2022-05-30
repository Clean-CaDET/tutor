using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Core.LearnerModel.Feedback;
using Tutor.Infrastructure.Security.Authentication.Users;

namespace Tutor.Web.Controllers.Learners.Feedback
{
    [Authorize(Policy = "learnerPolicy")]
    [Route("api/feedback/")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IMapper mapper, IFeedbackService feedbackService)
        {
            _mapper = mapper;
            _feedbackService = feedbackService;
        }

        [HttpPost("emotions")]
        public ActionResult<EmotionsFeedbackDto> PostEmotionsFeedback([FromBody] EmotionsFeedbackDto emotionsFeedback)
        {
            emotionsFeedback.LearnerId = User.LearnerId();
            var result = _feedbackService.SaveEmotionsFeedback(_mapper.Map<EmotionsFeedback>(emotionsFeedback));
            if (result.IsFailed) return BadRequest(result.Errors);
            return Ok(_mapper.Map<EmotionsFeedbackDto>(emotionsFeedback));
        }

        [HttpPost("improvements")]
        public ActionResult<TutorImprovementFeedbackDto> PostTutorImprovementFeedback([FromBody] TutorImprovementFeedbackDto tutorImprovementFeedback)
        {
            tutorImprovementFeedback.LearnerId = User.LearnerId();
            var result = _feedbackService.SaveTutorImprovementFeedback(_mapper.Map<TutorImprovementFeedback>(tutorImprovementFeedback));
            if (result.IsFailed) return BadRequest(result.Errors);
            return Ok(_mapper.Map<TutorImprovementFeedbackDto>(tutorImprovementFeedback));
        }
    }
}
