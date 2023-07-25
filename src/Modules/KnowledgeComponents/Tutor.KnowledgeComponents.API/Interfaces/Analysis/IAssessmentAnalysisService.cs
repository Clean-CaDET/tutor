using FluentResults;
using Tutor.KnowledgeComponents.API.Dtos.KnowledgeAnalytics;

namespace Tutor.KnowledgeComponents.API.Interfaces.Analysis;

public interface IAssessmentAnalysisService
{
    Result<List<AiStatisticsDto>> GetStatistics(int kcId, int instructorId);
    Result<List<AiStatisticsDto>> GetStatisticsForGroup(int kcId, int groupId, int instructorId);
}