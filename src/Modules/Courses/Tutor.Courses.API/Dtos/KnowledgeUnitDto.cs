namespace Tutor.Courses.API.Dtos;

public class KnowledgeUnitDto
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }
}