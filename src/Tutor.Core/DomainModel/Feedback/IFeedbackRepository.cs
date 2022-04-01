namespace Tutor.Core.DomainModel.Feedback
{
    public interface IFeedbackRepository
    { 
        void SaveEmotionsFeedback (EmotionsFeedback emotionsFeedback);

        void SaveTutorImprovementFeedback (TutorImprovementFeedback tutorImprovementFeedback);
    }
}
