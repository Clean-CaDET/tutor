namespace Tutor.Core.DomainModel.InstructionalItems
{
    public class Video : InstructionalItem
    {
        public string Url { get; private set; }

        public Video(int id, int knowledgeComponentId, string url) : base(id, knowledgeComponentId)
        {
            Url = url;
        }
    }
}