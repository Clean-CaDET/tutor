using FluentResults;

namespace Tutor.Core.Domain.LearningUtilities.Feedback
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
            if (emotionsFeedback.Comment == null)
                return Result.Fail("Empty Emotions Feedback");

            _feedbackRepository.SaveEmotionsFeedback(emotionsFeedback);
            return Result.Ok(emotionsFeedback);
        }

        public Result<TutorImprovementFeedback> SaveTutorImprovementFeedback(TutorImprovementFeedback tutorImprovementFeedback)
        {
            if (tutorImprovementFeedback.SoftwareComment == null)
                return Result.Fail("Empty Software Feedback");

            if (tutorImprovementFeedback.ContentComment == null)
                return Result.Fail("Empty Content Feedback");

            _feedbackRepository.SaveTutorImprovementFeedback(tutorImprovementFeedback);
            return Result.Ok(tutorImprovementFeedback);
        }
    }
}
