namespace Tutor.Courses.API.Dtos.Monitoring;

public class UnitProgressStatisticsDto
{
    public int UnitId { get; set; }
    public PublicKcProgressStatisticsDto KcStatistics { get; set; }
    public PublicTaskProgressStatisticsDto TaskStatistics { get; set; }
    public TaskPointsDto[] TaskPoints { get; set; }
}