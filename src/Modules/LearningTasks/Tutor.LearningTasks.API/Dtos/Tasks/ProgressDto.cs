namespace Tutor.LearningTasks.API.Dtos.Tasks;

public class ProgressDto
{
    public int Id { get; set; }
    public int Order { get; set; }
    public required string Name {  get; set; }
    public required string Status { get; set; }
    public int CompletedSteps { get; set; }
    public int TotalSteps { get; set; }
}
