using FluentResults;
using Tutor.KnowledgeComponents.API.Dtos.KnowledgeAnalytics;

namespace Tutor.KnowledgeComponents.API.Public.Analysis;

public interface IRatingService
{
    Result<KnowledgeComponentRatingDto> Create(KnowledgeComponentRatingDto rating, int learnerId);
    Result<List<KnowledgeComponentRatingDto>> GetByUnit(int unitId, int instructorId);
}