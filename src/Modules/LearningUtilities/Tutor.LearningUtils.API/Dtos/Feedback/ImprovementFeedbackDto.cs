namespace Tutor.LearningUtils.API.Dtos.Feedback;

public class ImprovementFeedbackDto
{
    public int LearnerId { get; set; }
    public int UnitId { get; set; }
    public string SoftwareComment { get; set; }
    public string ContentComment { get; set; }
}