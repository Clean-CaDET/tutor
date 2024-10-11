namespace Tutor.Courses.Core.Domain.RepositoryInterfaces;

public interface IUnitEnrollmentRepository
{
    UnitEnrollment? Get(int unitId, int learnerId);
    List<UnitEnrollment> GetMany(int unitId, int[] learnerIds);
    List<UnitEnrollment> GetMany(int[] unitIds, int[] learnerIds);
    UnitEnrollment Create(UnitEnrollment newEnrollment);
    UnitEnrollment Update(UnitEnrollment enrollment);
    List<UnitEnrollment> GetActiveEnrollmentsForCourse(int courseId);
    List<UnitEnrollment> GetBestBeforeInDateRange(int learnerId, DateTime start, DateTime end);

    List<UnitEnrollment> GetEnrolledUnits(int courseId, int learnerId);
}