using FluentResults;
using System.Collections.Generic;

namespace Tutor.Core.DomainModel.Feedback
{
    public interface IFeedbackService
    { 
        Result<EmotionsFeedback> SaveEmotionsFeedback(EmotionsFeedback emotionsFeedback);
    }
}
