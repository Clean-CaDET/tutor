namespace Tutor.LearningTasks.API.Dtos.TaskAnalytics;

public class InternalTaskUnitSummaryStatisticsDto
{
    public int UnitId { get; set; }
    public int TotalCount { get; set; }
    public int GradedCount { get; set; }
    public double LearnerPoints { get; set; }
    public double AvgScorePerLearner { get; set; }
    public double TotalMaxPoints { get; set; }
    public List<InternalTaskProgressStatisticsDto> GradedTaskStatistics { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType()) return false;
        return Equals((InternalTaskUnitSummaryStatisticsDto)obj);
    }

    private bool Equals(InternalTaskUnitSummaryStatisticsDto other)
    {
        if (UnitId != other.UnitId || TotalCount != other.TotalCount || GradedCount != other.GradedCount) return false;
        if (Math.Abs(AvgScorePerLearner - other.AvgScorePerLearner) > 0.1 || Math.Abs(LearnerPoints - other.LearnerPoints) > 0.1) return false;
        if (GradedTaskStatistics.Count != other.GradedTaskStatistics.Count) return false;
        if (!other.GradedTaskStatistics.All(GradedTaskStatistics.Contains)) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return UnitId.GetHashCode();
    }
}