namespace Tutor.Courses.API.Dtos.Monitoring;

public class PublicKcProgressStatisticsDto
{
    public int KcId { get; set; }
    public DateTime SatisfactionTime { get; set; }
    public List<string> NegativePatterns { get; set; }
}