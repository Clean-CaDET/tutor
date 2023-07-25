namespace Tutor.KnowledgeComponents.API.Interfaces;

public interface IAccessService
{
    bool IsKcOwner(int kcId, int instructorId);
    bool IsUnitOwner(int unitId, int instructorId);
    bool IsEnrolledInKc(int kcId, int instructorId);
    bool IsEnrolledInUnit(int unitId, int instructorId);
}