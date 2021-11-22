namespace Tutor.Core.DomainModel.InstructionalEvents
{
    public class Video : InstructionalEvent
    {
        public string Url { get; private set; }

        public Video(int id, int knowledgeComponentId, string url) : base(id, knowledgeComponentId)
        {
            Url = url;
        }
    }
}