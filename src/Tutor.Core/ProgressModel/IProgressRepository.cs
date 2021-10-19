using Tutor.Core.ProgressModel.Progress;

namespace Tutor.Core.ProgressModel
{
    public interface IProgressRepository
    {
        void SaveNodeProgress(NodeProgress nodeProgress);
        NodeProgress GetNodeProgressForLearner(int learnerId, int nodeId);
    }
}