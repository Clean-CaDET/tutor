namespace Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events.AssessmentItemEvents
{
    public abstract class SoughtHelp : KnowledgeComponentEvent
    {
        public int AssessmentItemId { get; set; }
    }
}
