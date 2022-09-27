namespace Tutor.Core.DomainModel.InstructionalItems
{
    public class Video : InstructionalItem
    {
        public string Url { get; private set; }
        public string Caption { get; private set; }

        public Video(int id, int knowledgeComponentId, string url, string caption) : base(id, knowledgeComponentId)
        {
            Url = url;
            Caption = caption;
        }
    }
}