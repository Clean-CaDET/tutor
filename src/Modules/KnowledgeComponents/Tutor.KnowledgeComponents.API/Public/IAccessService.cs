namespace Tutor.KnowledgeComponents.API.Public;

public interface IAccessService
{
    bool IsKcOwner(int kcId, int instructorId);
    bool IsUnitOwner(int unitId, int instructorId);
    bool IsEnrolledInKc(int kcId, int learnerId);
    bool IsEnrolledInUnit(int unitId, int learnerId);
}