using Tutor.Courses.API.Internal;
using Tutor.KnowledgeComponents.API.Public;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.RepositoryInterfaces;

namespace Tutor.KnowledgeComponents.Core.UseCases;

public class AccessServices : IAccessService
{
    private readonly IKnowledgeComponentRepository _kcRepository;
    private readonly IOwnershipValidator _ownedCourseService;
    private readonly IEnrollmentValidator _enrollmentValidator;

    public AccessServices(IKnowledgeComponentRepository kcRepository, IOwnershipValidator ownedCourseService,
        IEnrollmentValidator enrollmentValidator)
    {
        _kcRepository = kcRepository;
        _ownedCourseService = ownedCourseService;
        _enrollmentValidator = enrollmentValidator;
    }

    public bool IsKcOwner(int kcId, int instructorId)
    {
        var kc = _kcRepository.Get(kcId);
        return kc != null && _ownedCourseService.IsUnitOwner(kc.KnowledgeUnitId, instructorId);
    }

    public bool IsUnitOwner(int unitId, int instructorId)
    {
        return _ownedCourseService.IsUnitOwner(unitId, instructorId);
    }

    public bool IsEnrolledInKc(int kcId, int learnerId)
    {
        var kc = _kcRepository.Get(kcId);
        return kc != null && _enrollmentValidator.HasAccessibleEnrollment(kc.KnowledgeUnitId, learnerId);
    }

    public bool IsEnrolledInUnit(int unitId, int learnerId)
    {
        return _enrollmentValidator.HasAccessibleEnrollment(unitId, learnerId);
    }
}