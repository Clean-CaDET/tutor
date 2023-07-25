using Tutor.Courses.API.Interfaces.Authoring;
using Tutor.Courses.API.Interfaces.Learning;
using Tutor.KnowledgeComponents.API.Interfaces;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.RepositoryInterfaces;

namespace Tutor.KnowledgeComponents.Core.UseCases;

public class AccessServices : IAccessService
{
    private readonly IKnowledgeComponentRepository _kcRepository;
    private readonly IOwnedCourseService _ownedCourseService;
    private readonly IEnrolledCourseService _enrolledCourseService;

    public AccessServices(IKnowledgeComponentRepository kcRepository, IOwnedCourseService ownedCourseService,
        IEnrolledCourseService enrolledCourseService)
    {
        _kcRepository = kcRepository;
        _ownedCourseService = ownedCourseService;
        _enrolledCourseService = enrolledCourseService;
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

    public bool IsEnrolledInKc(int kcId, int instructorId)
    {
        var kc = _kcRepository.Get(kcId);
        return kc != null && _enrolledCourseService.HasActiveEnrollment(kc.KnowledgeUnitId, instructorId);
    }

    public bool IsEnrolledInUnit(int unitId, int instructorId)
    {
        return _enrolledCourseService.HasActiveEnrollment(unitId, instructorId);
    }
}