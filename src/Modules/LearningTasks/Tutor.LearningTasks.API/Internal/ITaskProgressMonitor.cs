using FluentResults;
using Tutor.LearningTasks.API.Dtos.TaskAnalytics;

namespace Tutor.LearningTasks.API.Internal;

public interface ITaskProgressMonitor
{
    Result<List<InternalTaskUnitSummaryStatisticsDto>> GetProgress(int learnerId, int[] unitIds, int[] groupMemberIds);
}