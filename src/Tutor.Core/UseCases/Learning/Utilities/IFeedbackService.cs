using FluentResults;
using Tutor.Core.Domain.LearningUtilities;

namespace Tutor.Core.UseCases.Learning.Utilities;

public interface IFeedbackService
{
    Result<EmotionsFeedback> SaveEmotionsFeedback(EmotionsFeedback emotionsFeedback);

    Result<TutorImprovementFeedback> SaveTutorImprovementFeedback(TutorImprovementFeedback tutorImprovementFeedback);
}