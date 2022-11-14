using FluentResults;

namespace Tutor.Core.Domain.LearningUtilities.Feedback
{
    public interface IFeedbackService
    {
        Result<EmotionsFeedback> SaveEmotionsFeedback(EmotionsFeedback emotionsFeedback);

        Result<TutorImprovementFeedback> SaveTutorImprovementFeedback(TutorImprovementFeedback tutorImprovementFeedback);
    }
}
