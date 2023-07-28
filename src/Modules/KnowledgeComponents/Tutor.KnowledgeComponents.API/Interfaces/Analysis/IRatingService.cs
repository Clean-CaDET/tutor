using FluentResults;
using Tutor.KnowledgeComponents.API.Dtos.KnowledgeAnalytics;

namespace Tutor.KnowledgeComponents.API.Interfaces.Analysis;

public interface IRatingService
{
    Result<KnowledgeComponentRatingDto> Create(KnowledgeComponentRatingDto kcKnowledgeComponentRating);
}