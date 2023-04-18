using FluentResults;
using Tutor.Core.Domain.KnowledgeAnalysis;

namespace Tutor.Core.UseCases.KnowledgeAnalysis;

public interface IUnitAnalysisService
{
    Result<KcStatistics> GetKcStatistics(int kcId, int instructorId);
    Result<KcStatistics> GetKcStatisticsForGroup(int kcId, int groupId, int instructorId);
}