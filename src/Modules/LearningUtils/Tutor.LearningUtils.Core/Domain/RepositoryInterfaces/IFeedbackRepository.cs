namespace Tutor.LearningUtils.Core.Domain.RepositoryInterfaces;

public interface IFeedbackRepository
{
    void SaveEmotionsFeedback(EmotionsFeedback emotionsFeedback);

    void SaveTutorImprovementFeedback(ImprovementFeedback tutorImprovementFeedback);
}