using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.DomainModel.Feedback;
using Tutor.Web.Controllers.Domain.DTOs.Feedback;

namespace Tutor.Web.Controllers.Domain
{
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
        public ActionResult<EmotionsFeedbackDTO> PostEmotionsFeedback([FromBody] EmotionsFeedbackDTO emotionsFeedback)
        {
            var result = _feedbackService.SaveEmotionsFeedback(_mapper.Map<EmotionsFeedback>(emotionsFeedback));
            if (result.IsFailed) return BadRequest(result.Errors);
            return Ok(_mapper.Map<EmotionsFeedbackDTO>(emotionsFeedback));
        }

    }
}
