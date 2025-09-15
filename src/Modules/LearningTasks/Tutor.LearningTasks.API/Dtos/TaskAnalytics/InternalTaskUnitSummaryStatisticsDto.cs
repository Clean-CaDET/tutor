namespace Tutor.LearningTasks.API.Dtos.TaskAnalytics;

public class InternalTaskUnitSummaryStatisticsDto
{
    public int UnitId { get; set; }
    public int TotalCount { get; set; }
    public int GradedCount { get; set; }
    public int CompletedCount { get; set; }
    public double LearnerPoints { get; set; }
    public double AvgGroupPoints { get; set; }
    public double TotalMaxPoints { get; set; }
    public List<InternalTaskProgressStatisticsDto> TaskStatistics { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType()) return false;
        return Equals((InternalTaskUnitSummaryStatisticsDto)obj);
    }

    private bool Equals(InternalTaskUnitSummaryStatisticsDto other)
    {
        if (UnitId != other.UnitId || TotalCount != other.TotalCount || GradedCount != other.GradedCount) return false;
        if (Math.Abs(AvgGroupPoints - other.AvgGroupPoints) > 0.1
            || Math.Abs(LearnerPoints - other.LearnerPoints) > 0.1
            || Math.Abs(TotalMaxPoints - other.TotalMaxPoints) > 0.1) return false;
        if (TaskStatistics.Count != other.TaskStatistics.Count) return false;
        if (!other.TaskStatistics.All(TaskStatistics.Contains)) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return UnitId.GetHashCode();
    }
}