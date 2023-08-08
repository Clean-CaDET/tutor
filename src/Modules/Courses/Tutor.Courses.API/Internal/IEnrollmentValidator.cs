namespace Tutor.Courses.API.Internal;

public interface IEnrollmentValidator
{
    bool HasActiveEnrollment(int unitId, int learnerId);
}