namespace Tutor.LearningTasks.API.Public;

public interface IAccessServices
{
    bool IsCourseOwner(int courseId, int instructorId);
    bool IsUnitOwner(int unitId, int instructorId);
}
