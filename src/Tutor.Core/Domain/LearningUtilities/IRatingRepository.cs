
namespace Tutor.Core.Domain.LearningUtilities;

public interface IRatingRepository
{
    public void RateKnowledgeComponent(KnowledgeComponentRating knowledgeComponentRating);
}