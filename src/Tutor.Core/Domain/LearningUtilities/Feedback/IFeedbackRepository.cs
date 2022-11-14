namespace Tutor.Core.Domain.LearningUtilities.Feedback
{
    public interface IFeedbackRepository
    {
        void SaveEmotionsFeedback(EmotionsFeedback emotionsFeedback);

        void SaveTutorImprovementFeedback(TutorImprovementFeedback tutorImprovementFeedback);
    }
}
