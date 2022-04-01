namespace Tutor.Core.DomainModel.InstructionalEvents
{
    public class InstructionalEvent
    {
        public int Id { get; private set; }
        public int KnowledgeComponentId { get; private set; }
        public int Order { get; private set; }
        protected InstructionalEvent() {}

        protected InstructionalEvent(int id, int knowledgeComponentId)
        {
            Id = id;
            KnowledgeComponentId = knowledgeComponentId;
        }
    }
}