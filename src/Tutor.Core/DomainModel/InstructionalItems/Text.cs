namespace Tutor.Core.DomainModel.InstructionalItems
{
    public class Text : InstructionalItem
    {
        public string Content { get; private set; }

        public Text(int id, int knowledgeComponentId, string content) : base(id, knowledgeComponentId)
        {
            Content = content;
        }
    }
}