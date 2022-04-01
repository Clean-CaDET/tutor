using FluentResults;

namespace Tutor.Core.DomainModel.Feedback
{
    public interface IFeedbackService
    { 
        Result<EmotionsFeedback> SaveEmotionsFeedback(EmotionsFeedback emotionsFeedback);

        Result<TutorImprovementFeedback> SaveTutorImprovementFeedback(TutorImprovementFeedback tutorImprovementFeedback);
    }
}
