namespace Tutor.LearningTasks.API.Dtos.TaskAnalytics;

public class InternalTaskUnitSummaryStatisticsDto
{
    public int UnitId { get; set; }
    public int TotalCount { get; set; }
    public int CompletedCount { get; set; }
    public int LearnerPoints { get; set; }
    public int AvgGroupPoints { get; set; }
    public List<InternalTaskProgressStatisticsDto> TaskStatistics { get; set; }
}