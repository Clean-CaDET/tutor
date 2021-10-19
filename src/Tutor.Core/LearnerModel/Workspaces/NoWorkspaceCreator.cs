namespace Tutor.Core.LearnerModel.Workspaces
{
    public class NoWorkspaceCreator : IWorkspaceCreator
    {
        public Workspace Create(int learnerId)
        {
            return null;
        }
    }
}
