namespace Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events.KnowledgeComponentEvents
{
    public class KnowledgeComponentCompleted : KnowledgeComponentEvent
    {
        public double MinutesToCompletion { get; set; }
    }
}
