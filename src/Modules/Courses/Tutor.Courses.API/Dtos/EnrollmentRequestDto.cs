namespace Tutor.Courses.API.Dtos;

public class EnrollmentRequestDto
{
    public int[] LearnerIds { get; set; }
    public EnrollmentDto NewEnrollment { get; set; }
}