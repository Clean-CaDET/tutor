using Tutor.Courses.API.Internal;
using Tutor.Elaborations.API.Public;

namespace Tutor.Elaborations.Core.UseCases;

public class AccessServices : IAccessServices
{
    private readonly IOwnershipValidator _ownershipValidator;
    private readonly IEnrollmentValidator _enrollmentValidator;

    public AccessServices(IOwnershipValidator ownershipValidator,
        IEnrollmentValidator enrollmentValidator)
    {
        _ownershipValidator = ownershipValidator;
        _enrollmentValidator = enrollmentValidator;
    }

    public bool IsCourseOwner(int courseId, int instructorId)
    {
        return _ownershipValidator.IsCourseOwner(courseId, instructorId);
    }

    public bool IsUnitOwner(int unitId, int instructorId)
    {
        return _ownershipValidator.IsUnitOwner(unitId, instructorId);
    }

    public bool IsEnrolledInUnit(int unitId, int learnerId)
    {
        return _enrollmentValidator.HasAccessibleEnrollment(unitId, learnerId);
    }
}
