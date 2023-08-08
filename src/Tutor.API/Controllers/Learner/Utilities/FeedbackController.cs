using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.LearningUtils.API.Dtos.Feedback;
using Tutor.LearningUtils.API.Public;
using Tutor.Stakeholders.Infrastructure.Authentication;

namespace Tutor.API.Controllers.Learner.Utilities;

[Authorize(Policy = "learnerPolicy")]
[Route("api/learning/unit/{unitId:int}/feedback")]
public class FeedbackController : BaseApiController
{
    private readonly IFeedbackService _feedbackService;
    public FeedbackController(IFeedbackService feedbackService)
    {
        _feedbackService = feedbackService;
    }

    [HttpPost("emotions")]
    public ActionResult<EmotionsFeedbackDto> PostEmotionsFeedback([FromBody] EmotionsFeedbackDto emotionsFeedback)
    {
        emotionsFeedback.LearnerId = User.LearnerId();
        var result = _feedbackService.SaveEmotionsFeedback(emotionsFeedback);
        return CreateResponse(result);
    }

    [HttpPost("improvements")]
    public ActionResult<ImprovementFeedbackDto> PostImprovementFeedback([FromBody] ImprovementFeedbackDto tutorImprovementFeedback)
    {
        tutorImprovementFeedback.LearnerId = User.LearnerId();
        var result = _feedbackService.SaveTutorImprovementFeedback(tutorImprovementFeedback);
        return CreateResponse(result);
    }
}