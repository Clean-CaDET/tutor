namespace Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events.AssessmentItemEvents
{
    public abstract class AssessmentItemEvent : KnowledgeComponentEvent
    {
        public int AssessmentItemId { get; set; }
    }
}
