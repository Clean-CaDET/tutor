namespace Tutor.Courses.API.Dtos;

public class EnrollmentRequestDto
{
    public int[] LearnerIds { get; set; }
    public DateTime Start { get; set; }
}