namespace Tutor.Core.Domain.Knowledge.InstructionalItems
{
    public class Markdown : InstructionalItem
    {
        public string Content { get; private set; }

        public Markdown(int id, int knowledgeComponentId, string content) : base(id, knowledgeComponentId)
        {
            Content = content;
        }
    }
}