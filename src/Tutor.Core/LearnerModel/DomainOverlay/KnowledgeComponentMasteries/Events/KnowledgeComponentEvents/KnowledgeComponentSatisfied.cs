namespace Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events.KnowledgeComponentEvents
{
    public class KnowledgeComponentSatisfied : KnowledgeComponentEvent
    {
        public double MinutesToSatisfaction { get; set; }
    }
}
