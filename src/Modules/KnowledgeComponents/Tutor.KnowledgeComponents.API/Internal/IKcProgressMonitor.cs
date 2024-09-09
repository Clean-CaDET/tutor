using FluentResults;
using Tutor.KnowledgeComponents.API.Dtos.KnowledgeAnalytics;

namespace Tutor.KnowledgeComponents.API.Internal;

public interface IKcProgressMonitor
{
    Result<List<InternalKcUnitSummaryStatisticsDto>> GetProgress(int learnerId, int[] unitIds);
}