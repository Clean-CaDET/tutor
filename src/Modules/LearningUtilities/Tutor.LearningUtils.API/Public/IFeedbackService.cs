using FluentResults;
using Tutor.LearningUtils.API.Dtos.Feedback;

namespace Tutor.LearningUtils.API.Public;

public interface IFeedbackService
{
    Result<EmotionsFeedbackDto> SaveEmotionsFeedback(EmotionsFeedbackDto emotionsFeedback);

    Result<ImprovementFeedbackDto> SaveTutorImprovementFeedback(ImprovementFeedbackDto tutorImprovementFeedback);
}