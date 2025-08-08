namespace Tutor.Courses.API.Internal;

public interface IInternalMembershipService
{
    List<int> GetMemberIdsByCourse(int courseId);
}