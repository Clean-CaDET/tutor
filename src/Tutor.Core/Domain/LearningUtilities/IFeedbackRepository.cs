namespace Tutor.Core.Domain.LearningUtilities;

public interface IFeedbackRepository
{
    void SaveEmotionsFeedback(EmotionsFeedback emotionsFeedback);

    void SaveTutorImprovementFeedback(TutorImprovementFeedback tutorImprovementFeedback);
}