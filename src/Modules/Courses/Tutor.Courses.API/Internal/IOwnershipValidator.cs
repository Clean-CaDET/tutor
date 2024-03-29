namespace Tutor.Courses.API.Internal;

public interface IOwnershipValidator
{
    bool IsUnitOwner(int unitId, int instructorId);
}