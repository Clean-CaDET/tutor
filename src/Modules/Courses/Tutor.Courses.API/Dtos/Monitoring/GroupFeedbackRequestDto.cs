namespace Tutor.Courses.API.Dtos.Monitoring;

public class GroupFeedbackRequestDto
{
    public int[] LearnerIds { get; set; }
    public DateTime WeekEnd { get; set; }
}