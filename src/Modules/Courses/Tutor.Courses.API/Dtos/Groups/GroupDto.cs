namespace Tutor.Courses.API.Dtos.Groups;

public class GroupDto
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public string Name { get; set; }
    public List<LearnerDto>? Learners { get; set; }
}