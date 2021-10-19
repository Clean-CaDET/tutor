namespace Tutor.Core.ProgressModel.Feedback
{
    public interface IFeedbackRepository
    {
        void SaveOrUpdate(LearningObjectFeedback feedback);
        LearningObjectFeedback Get(int learningObjectId, int learnerId);
    }
}