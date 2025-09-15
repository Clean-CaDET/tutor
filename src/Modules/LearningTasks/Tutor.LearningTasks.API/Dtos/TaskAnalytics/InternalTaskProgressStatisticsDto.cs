namespace Tutor.LearningTasks.API.Dtos.TaskAnalytics;

public class InternalTaskProgressStatisticsDto
{
    public int TaskId { get; set; }
    public DateTime CompletionTime { get; set; }
    public bool IsGraded { get; set; }
    public double WonPoints { get; set; }
    public List<string> NegativePatterns { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType()) return false;
        return Equals((InternalTaskProgressStatisticsDto)obj);
    }

    private bool Equals(InternalTaskProgressStatisticsDto other)
    {
        if (TaskId != other.TaskId || Math.Abs(WonPoints - other.WonPoints) > 0.1 || IsGraded != other.IsGraded) return false;
        if (NegativePatterns.Count != other.NegativePatterns.Count) return false;
        if (!other.NegativePatterns.All(NegativePatterns.Contains)) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return TaskId.GetHashCode();
    }
}