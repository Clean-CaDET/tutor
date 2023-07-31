using FluentResults;
using Tutor.KnowledgeComponents.API.Dtos.KnowledgeAnalytics;

namespace Tutor.KnowledgeComponents.API.Public.Analysis;

public interface IKnowledgeAnalysisService
{
    Result<KcStatisticsDto> GetStatistics(int kcId, int instructorId);
}