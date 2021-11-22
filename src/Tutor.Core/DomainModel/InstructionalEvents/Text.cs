namespace Tutor.Core.DomainModel.InstructionalEvents
{
    public class Text : InstructionalEvent
    {
        public string Content { get; private set; }

        public Text(int id, int knowledgeComponentId, string content) : base(id, knowledgeComponentId)
        {
            Content = content;
        }
    }
}