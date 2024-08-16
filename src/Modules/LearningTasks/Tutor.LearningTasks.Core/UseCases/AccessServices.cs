using Tutor.Courses.API.Internal;
using Tutor.LearningTasks.API.Public;

namespace Tutor.LearningTasks.Core.UseCases;

public class AccessServices : IAccessServices
{
    private readonly IOwnershipValidator _ownedCourseService;
    private readonly IEnrollmentValidator _enrollmentService;

    public AccessServices(IOwnershipValidator ownedCourseService, IEnrollmentValidator enrollmentService)
    {
        _ownedCourseService = ownedCourseService;
        _enrollmentService = enrollmentService;
    }

    public bool IsUnitOwner(int unitId, int instructorId)
    {
        return _ownedCourseService.IsUnitOwner(unitId, instructorId);
    }

    public bool IsEnrolledInUnit(int unitId, int learnerId)
    {
        return _enrollmentService.HasAccessibleEnrollment(unitId, learnerId);
    }
}
