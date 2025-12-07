namespace Tutor.Courses.API.Dtos.Reports;

public class FeedbackItemAggregateDto
{
    public string Code { get; set; } = string.Empty;
    public int[] Weeks { get; set; } = Array.Empty<int>();
    public bool HasData { get; set; }
    public double Average { get; set; }
    public int[] ValueCounts { get; set; } = Array.Empty<int>();
}
