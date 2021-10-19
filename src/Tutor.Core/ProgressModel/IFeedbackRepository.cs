using Tutor.Core.ProgressModel.Feedback;

namespace Tutor.Core.ProgressModel
{
    public interface IFeedbackRepository
    {
        void SaveOrUpdate(LearningObjectFeedback feedback);
        LearningObjectFeedback Get(int learningObjectId, int learnerId);
    }
}