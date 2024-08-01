namespace Tutor.Courses.API.Dtos;

public class UnitProgressRatingDto
{
    public int? LearnerId { get; set; }
    public int KnowledgeUnitId { get; set; }
    public int[] CompletedKcIds { get; set; } = Array.Empty<int>();
    public int[] CompletedTaskIds { get; set; } = Array.Empty<int>();
    public DateTime Created { get; set; }
    public string Feedback { get; set; } = "";
    public bool IsLearnerInitiated { get; set; }
}