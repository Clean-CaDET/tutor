namespace Tutor.Courses.Core.Domain.RepositoryInterfaces;

public interface IUnitEnrollmentRepository
{
    List<UnitEnrollment> GetEnrolledUnits(int courseId, int learnerId);
    UnitEnrollment? GetEnrollment(int unitId, int learnerId);
    List<UnitEnrollment> GetEnrollments(int unitId, int[] learnerIds);
    UnitEnrollment Create(UnitEnrollment newEnrollment);
    UnitEnrollment Update(UnitEnrollment enrollment);
    List<UnitEnrollment> GetActiveEnrollmentsForCourse(int courseId);
}