using FluentResults;
using System.Collections.Generic;

namespace Tutor.Core.DomainModel.Feedback
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _ifeedbackRepository;

        public FeedbackService(IFeedbackRepository ifeedbackRepository)
        {
            _ifeedbackRepository = ifeedbackRepository;
        }

        public Result<EmotionsFeedback> SaveEmotionsFeedback(EmotionsFeedback emotionsFeedback)
        {
            if (emotionsFeedback == null)
            {
                return Result.Fail("Empty Emotions Feedback");
            }

            _ifeedbackRepository.SaveEmotionsFeedback(emotionsFeedback);
            return Result.Ok(emotionsFeedback);
        }
    }
}
