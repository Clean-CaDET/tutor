namespace Tutor.LearningTasks.API.Dtos.LearningTasks;

public class LearningTaskDto
{
    public int Id { get; set; }
    public int UnitId { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public int Order { get; set; }
    public bool IsTemplate { get; set; }
    public List<ActivityDto>? Steps { get; set; }
    public double MaxPoints { get; set; }
}