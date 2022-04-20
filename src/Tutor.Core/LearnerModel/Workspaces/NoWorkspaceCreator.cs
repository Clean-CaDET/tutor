namespace Tutor.Core.LearnerModel.Workspaces
{
    public class NoWorkspaceCreator : IWorkspaceCreator
    {
        public Workspace Create(string learnerId)
        {
            return null;
        }
    }
}
