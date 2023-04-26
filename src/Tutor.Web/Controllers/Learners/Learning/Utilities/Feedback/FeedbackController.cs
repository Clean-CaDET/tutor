using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Core.Domain.LearningUtilities;
using Tutor.Core.UseCases.Learning.Utilities;
using Tutor.Infrastructure.Security.Authentication.Users;

namespace Tutor.Web.Controllers.Learners.Learning.Utilities.Feedback;

[Authorize(Policy = "learnerPolicy")]
[Route("api/learning/unit/{unitId:int}/feedback")]
public class FeedbackController : BaseApiController
{
    private readonly IFeedbackService _feedbackService;

    public FeedbackController(IMapper mapper, IFeedbackService feedbackService) : base(mapper)
    {
        _feedbackService = feedbackService;
    }

    [HttpPost("emotions")]
    public ActionResult<EmotionsFeedbackDto> PostEmotionsFeedback([FromBody] EmotionsFeedbackDto emotionsFeedback)
    {
        emotionsFeedback.LearnerId = User.LearnerId();
        var result = _feedbackService.SaveEmotionsFeedback(_mapper.Map<EmotionsFeedback>(emotionsFeedback));
        return CreateResponse<EmotionsFeedback, EmotionsFeedbackDto>(result);
    }

    [HttpPost("improvements")]
    public ActionResult<TutorImprovementFeedbackDto> PostTutorImprovementFeedback([FromBody] TutorImprovementFeedbackDto tutorImprovementFeedback)
    {
        tutorImprovementFeedback.LearnerId = User.LearnerId();
        var result = _feedbackService.SaveTutorImprovementFeedback(_mapper.Map<TutorImprovementFeedback>(tutorImprovementFeedback));
        return CreateResponse<TutorImprovementFeedback, TutorImprovementFeedbackDto>(result);
    }
}