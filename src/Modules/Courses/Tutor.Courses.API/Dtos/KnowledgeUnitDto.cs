namespace Tutor.Courses.API.Dtos;

public class KnowledgeUnitDto
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string? Introduction { get; set; }
    public string? Goals { get; set; }
    public string? Guidelines { get; set; }
    public int Order { get; set; }
    
    public DateTime? BestBefore { get; set; }
    public string? EnrollmentStatus { get; set; }
}