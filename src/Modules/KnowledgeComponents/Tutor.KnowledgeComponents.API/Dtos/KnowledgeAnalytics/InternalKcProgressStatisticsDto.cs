namespace Tutor.KnowledgeComponents.API.Dtos.KnowledgeAnalytics;

public class InternalKcProgressStatisticsDto
{
    public int KcId { get; set; }
    public DateTime SatisfactionTime { get; set; }
    public List<string> NegativePatterns { get; set; }
}