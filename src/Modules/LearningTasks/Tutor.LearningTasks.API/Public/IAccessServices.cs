namespace Tutor.LearningTasks.API.Public;

public interface IAccessServices
{
    bool IsUnitOwner(int unitId, int instructorId);
    bool IsEnrolledInUnit(int unitId, int learnerId);
}
