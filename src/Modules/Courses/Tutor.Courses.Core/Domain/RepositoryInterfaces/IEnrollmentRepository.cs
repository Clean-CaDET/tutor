using Tutor.BuildingBlocks.Core.UseCases;

namespace Tutor.Courses.Core.Domain.RepositoryInterfaces;

public interface IEnrollmentRepository
{
    PagedResult<Course> GetEnrolledCourses(int learnerId, int page, int pageSize);
    Course? GetEnrolledCourse(int courseId, int learnerId);
    List<UnitEnrollment> GetEnrolledUnits(int courseId, int learnerId);


    UnitEnrollment GetEnrollment(int unitId, int learnerId);
    List<UnitEnrollment> GetEnrollments(int unitId, int[] learnerIds);
    UnitEnrollment Create(UnitEnrollment newEnrollment);
    UnitEnrollment Update(UnitEnrollment enrollment);
    List<UnitEnrollment> GetActiveEnrollmentsForCourse(int courseId);
}