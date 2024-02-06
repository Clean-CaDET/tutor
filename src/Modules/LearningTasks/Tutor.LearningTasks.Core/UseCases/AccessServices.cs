using Tutor.Courses.API.Internal;
using Tutor.LearningTasks.API.Public;

namespace Tutor.LearningTasks.Core.UseCases;

public class AccessServices : IAccessServices
{
    private readonly IOwnershipValidator _ownedCourseService;

    public AccessServices(IOwnershipValidator ownedCourseService)
    {
        _ownedCourseService = ownedCourseService;
    }

    public bool IsCourseOwner(int courseId, int instructorId)
    {
        return _ownedCourseService.IsCourseOwner(courseId, instructorId);
    }

    public bool IsUnitOwner(int unitId, int instructorId)
    {
        return _ownedCourseService.IsUnitOwner(unitId, instructorId);
    }
}
