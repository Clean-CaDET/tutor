namespace Tutor.Core.LearnerModel.Workspaces
{
    public class Workspace
    {
        public string Path { get; private set; }

        public Workspace(string path)
        {
            Path = path;
        }
    }
}
