using FluentResults;
using Tutor.Core.Domain.LearningUtilities;

namespace Tutor.Core.UseCases.Learning.Utilities;

public interface IRatingService
{
    Result<KnowledgeComponentRating> RateKnowledgeComponent(KnowledgeComponentRating kcRating);
}