using FluentResults;

namespace Tutor.Core.LearnerModel.Feedback
{
    public interface IFeedbackService
    { 
        Result<EmotionsFeedback> SaveEmotionsFeedback(EmotionsFeedback emotionsFeedback);

        Result<TutorImprovementFeedback> SaveTutorImprovementFeedback(TutorImprovementFeedback tutorImprovementFeedback);
    }
}
