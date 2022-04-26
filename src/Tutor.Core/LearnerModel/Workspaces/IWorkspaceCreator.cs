namespace Tutor.Core.LearnerModel.Workspaces
{
    public interface IWorkspaceCreator
    {
        public Workspace Create(string learnerId);
    }
}
