namespace Tutor.Courses.API.Internal;

public interface IEnrollmentValidator
{
    bool HasAccessibleEnrollment(int unitId, int learnerId);
}