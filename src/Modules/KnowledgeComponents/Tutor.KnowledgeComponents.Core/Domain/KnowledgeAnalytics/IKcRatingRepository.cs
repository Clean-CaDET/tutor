namespace Tutor.KnowledgeComponents.Core.Domain.KnowledgeAnalytics;

public interface IKcRatingRepository
{
    KnowledgeComponentRating Create(KnowledgeComponentRating rating);
    List<KnowledgeComponentRating> GetByKcs(List<int> kcIds);
}