using FluentResults;
using Tutor.KnowledgeComponents.API.Dtos.KnowledgeAnalytics;

namespace Tutor.KnowledgeComponents.API.Interfaces.Analysis;

public interface IKnowledgeAnalysisService
{
    Result<KcStatisticsDto> GetStatistics(int kcId, int instructorId);
    Result<KcStatisticsDto> GetStatisticsForGroup(int kcId, int groupId, int instructorId);
}