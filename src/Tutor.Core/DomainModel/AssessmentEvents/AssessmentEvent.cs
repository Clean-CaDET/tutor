namespace Tutor.Core.DomainModel.AssessmentEvents
{
    public class AssessmentEvent
    {
        public int Id { get; private set; }
        public int KnowledgeComponentId { get; private set; }

        protected AssessmentEvent() {}

        protected AssessmentEvent(int id, int knowledgeComponentId)
        {
            Id = id;
            KnowledgeComponentId = knowledgeComponentId;
        }
    }
}