using Microsoft.EntityFrameworkCore;
using Tutor.Courses.Core.Domain;
using Tutor.Courses.Core.Domain.RepositoryInterfaces;

namespace Tutor.Courses.Infrastructure.Database.Repositories;

public class UnitEnrollmentDatabaseRepository : IUnitEnrollmentRepository
{
    private readonly CoursesContext _dbContext;

    public UnitEnrollmentDatabaseRepository(CoursesContext dbContext)
    {
        _dbContext = dbContext;
    }

    public UnitEnrollment? Get(int unitId, int learnerId)
    {
        return _dbContext.UnitEnrollments
            .Include(ue => ue.KnowledgeUnit)
            .FirstOrDefault(e => e.KnowledgeUnit.Id == unitId && e.LearnerId == learnerId);
    }

    public List<UnitEnrollment> GetMany(int unitId, int[] learnerIds)
    {
        return _dbContext.UnitEnrollments
            .Where(e => e.KnowledgeUnit.Id == unitId && learnerIds.Contains(e.LearnerId))
            .ToList();
    }

    public List<UnitEnrollment> GetMany(int[] unitIds, int[] learnerIds)
    {
        return _dbContext.UnitEnrollments
            .Where(e => unitIds.Contains(e.KnowledgeUnitId) && learnerIds.Contains(e.LearnerId))
            .ToList();
    }

    public UnitEnrollment Create(UnitEnrollment newEnrollment)
    {
        _dbContext.UnitEnrollments.Add(newEnrollment);
        return newEnrollment;
    }

    public UnitEnrollment Update(UnitEnrollment enrollment)
    {
        _dbContext.UnitEnrollments.Update(enrollment);
        return enrollment;
    }

    public List<UnitEnrollment> GetActiveEnrollmentsForCourse(int courseId)
    {
        return _dbContext.UnitEnrollments
            .Where(ue => ue.KnowledgeUnit.CourseId.Equals(courseId)
                         && (ue.Status == EnrollmentStatus.Active || ue.Status == EnrollmentStatus.Completed)).ToList();
    }

    public List<UnitEnrollment> GetEnrolledUnits(int courseId, int learnerId)
    {
        return _dbContext.UnitEnrollments
            .Where(ue => ue.LearnerId.Equals(learnerId)
                         && ue.KnowledgeUnit.CourseId.Equals(courseId))
            .Include(ue => ue.KnowledgeUnit).ToList();
    }
}