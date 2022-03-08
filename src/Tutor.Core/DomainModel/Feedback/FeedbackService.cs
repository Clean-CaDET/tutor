using FluentResults;
using System.Collections.Generic;

namespace Tutor.Core.DomainModel.Feedback
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackService(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public Result<EmotionsFeedback> SaveEmotionsFeedback(EmotionsFeedback emotionsFeedback)
        {
            if (emotionsFeedback == null)
                return Result.Fail("Empty Emotions Feedback");
            
            _feedbackRepository.SaveEmotionsFeedback(emotionsFeedback);
            return Result.Ok(emotionsFeedback);
        }
    }
}
