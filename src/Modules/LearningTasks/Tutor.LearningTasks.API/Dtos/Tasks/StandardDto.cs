namespace Tutor.LearningTasks.API.Dtos.Tasks;

public class StandardDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public double MaxPoints { get; set; }
}