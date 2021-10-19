using Tutor.Core.ProgressModel.Feedback;

namespace Tutor.Core.ProgressModel
{
    public interface IFeedbackService
    {
        void SubmitFeedback(LearningObjectFeedback feedback);
    }
}