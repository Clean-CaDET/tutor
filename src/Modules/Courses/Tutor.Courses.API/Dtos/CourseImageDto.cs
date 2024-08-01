namespace Tutor.Courses.API.Dtos;

public class CourseImageDto
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public string Name { get; set; }
    public string FilePath { get; set; }
    public string RelativeUrl { get; set; }
}