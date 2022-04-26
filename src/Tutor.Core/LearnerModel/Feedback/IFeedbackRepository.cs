namespace Tutor.Core.LearnerModel.Feedback
{
    public interface IFeedbackRepository
    { 
        void SaveEmotionsFeedback (EmotionsFeedback emotionsFeedback);

        void SaveTutorImprovementFeedback (TutorImprovementFeedback tutorImprovementFeedback);
    }
}
