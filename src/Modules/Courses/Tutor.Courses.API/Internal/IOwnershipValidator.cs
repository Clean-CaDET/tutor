namespace Tutor.Courses.API.Internal;

public interface IOwnershipValidator
{
    bool IsCourseOwner(int courseId, int instructorId);
    bool IsUnitOwner(int unitId, int instructorId);
}