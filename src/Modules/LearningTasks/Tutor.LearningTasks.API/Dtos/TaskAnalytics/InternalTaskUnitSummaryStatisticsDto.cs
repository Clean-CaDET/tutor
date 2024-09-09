namespace Tutor.LearningTasks.API.Dtos.TaskAnalytics;

public class InternalTaskUnitSummaryStatisticsDto
{
    public int UnitId { get; set; }
    public int TotalCount { get; set; }
    public int GradedCount { get; set; }
    public double LearnerPoints { get; set; }
    public double AvgScorePerLearner { get; set; }
    public List<InternalTaskProgressStatisticsDto> TaskStatistics { get; set; }
}