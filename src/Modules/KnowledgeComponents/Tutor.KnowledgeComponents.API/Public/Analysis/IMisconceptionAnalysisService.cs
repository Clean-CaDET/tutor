using FluentResults;
using Tutor.KnowledgeComponents.API.Dtos.KnowledgeAnalytics;

namespace Tutor.KnowledgeComponents.API.Public.Analysis;

public interface IMisconceptionAnalysisService
{
    Result<List<AiStatisticsDto>> GetTop10MisconceivedAssessments(int unitId, int instructorId);
}