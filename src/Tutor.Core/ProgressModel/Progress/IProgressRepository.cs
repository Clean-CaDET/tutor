using Tutor.Core.LearnerModel.Learners;

namespace Tutor.Core.ProgressModel.Progress
{
    public interface IProgressRepository
    {
        void SaveNodeProgress(NodeProgress nodeProgress);
        NodeProgress GetNodeProgressForLearner(int learnerId, int nodeId);
    }
}