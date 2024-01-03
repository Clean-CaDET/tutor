namespace Tutor.LearningTasks.API.Dtos.Activities;

public class ActivityDto
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public required string Name { get; set; } 
    public required GuidanceDto Guidance { get; set; }
    public List<ExampleDto>? Examples { get; set; }
    public List<SubactivityDto>? Subactivities { get; set; }
}