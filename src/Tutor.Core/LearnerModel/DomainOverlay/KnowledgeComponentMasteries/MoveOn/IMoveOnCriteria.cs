namespace Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.MoveOn
{
    public interface IMoveOnCriteria
    {
        bool IsSatisfied(bool isCompleted, bool isPassed);
    }
}
