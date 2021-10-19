using Tutor.Core.LearnerModel.Workspaces;

namespace Tutor.Core.LearnerModel.Learners
{
    public class Learner
    {
        public int Id { get; private set; }
        public string StudentIndex { get; private set; }
        public Workspace Workspace { get; set; }
        public string IamId { get; set; }
    }
}