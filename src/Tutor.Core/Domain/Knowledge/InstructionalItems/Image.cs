namespace Tutor.Core.Domain.Knowledge.InstructionalItems
{
    public class Image : InstructionalItem
    {
        public string Url { get; private set; }
        public string Caption { get; private set; }

        public Image(int id, int knowledgeComponentId, string url, string caption) : base(id, knowledgeComponentId)
        {
            Url = url;
            Caption = caption;
        }
    }
}