namespace Tutor.Courses.API.Dtos.Enrollments;

public class EnrollmentDto
{
    public int KnowledgeUnitId { get; set; }
    public int LearnerId { get; set; }
    public DateTime AvailableFrom { get; set; }
    public DateTime? BestBefore { get; set; }
    public string? Status { get; set; }
}