using FluentResults;
using Tutor.Core.Domain.KnowledgeAnalysis;

namespace Tutor.Core.UseCases.KnowledgeAnalysis;

public interface IKnowledgeAnalysisService
{
    Result<KcStatistics> GetStatistics(int kcId, int instructorId);
    Result<KcStatistics> GetStatisticsForGroup(int kcId, int groupId, int instructorId);
}