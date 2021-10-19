using FluentResults;

namespace Tutor.Core.ProgressModel.Feedback
{
    public interface IFeedbackService
    {
        Result SubmitFeedback(LearningObjectFeedback feedback);
    }
}