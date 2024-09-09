namespace Tutor.LearningTasks.API.Dtos.Tasks;

public class ActivityDto
{
    public int Id { get; set; }
    public int LearningTaskId { get; set; }
    public int ParentId { get; set; }
    public int Order { get; set; }
    public required string Code { get; set; }
    public required string Name { get; set; }
    public required string Guidance { get; set; }
    public List<ExampleDto>? Examples { get; set; }
    public SubmissionFormatDto? SubmissionFormat { get; set; }
    public List<StandardDto>? Standards { get; set; }
    public double MaxPoints { get; set; }
}