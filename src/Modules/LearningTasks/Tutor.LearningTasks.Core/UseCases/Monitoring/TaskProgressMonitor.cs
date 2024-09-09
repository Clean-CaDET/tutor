using FluentResults;
using Tutor.LearningTasks.API.Dtos.TaskAnalytics;
using Tutor.LearningTasks.API.Internal;

namespace Tutor.LearningTasks.Core.UseCases.Monitoring;

public class TaskProgressMonitor : ITaskProgressMonitor
{
    public Result<List<InternalTaskUnitSummaryStatisticsDto>> GetProgress(int learnerId, int[] unitIds, int[] groupMemberIds)
    {
        throw new NotImplementedException();
    }
}