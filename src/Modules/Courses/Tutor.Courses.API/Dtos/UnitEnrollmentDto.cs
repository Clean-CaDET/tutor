namespace Tutor.Courses.API.Dtos;

public class UnitEnrollmentDto
{
    public int LearnerId { get; private set; }
    public DateTime Start { get; private set; }
    public string Status { get; private set; }
}