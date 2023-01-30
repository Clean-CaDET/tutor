using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.Domain.CourseIteration;
using Tutor.Core.Domain.Knowledge.Structure;

namespace Tutor.Infrastructure.Database.Repositories.CourseIteration;

public class EnrollmentDatabaseRepository : IEnrollmentRepository
{
    private readonly TutorContext _dbContext;

    public EnrollmentDatabaseRepository(TutorContext dbContext)
    {
        _dbContext = dbContext;
    }

    public int CountEnrollmentsForUnit(int unitId)
    {
        return _dbContext.UnitEnrollments.Count(enrollment => enrollment.KnowledgeUnit.Id == unitId);
    }

    public List<Course> GetEnrolledCourses(int learnerId)
    {
        return _dbContext.LearnerGroups
            .Where(lg => lg.Membership.Any(m => m.Member.Id.Equals(learnerId)))
            .Select(lg => lg.Course).Distinct().ToList();
    }

    public Course GetCourseEnrolledAndActiveUnits(int courseId, int learnerId)
    {
        var course = _dbContext.Courses.FirstOrDefault(c => c.Id.Equals(courseId));
        var enrolledUnits = GetEnrolledAndActiveUnits(courseId, learnerId);
        return new Course(course, enrolledUnits);
    }

    private List<KnowledgeUnit> GetEnrolledAndActiveUnits(int courseId, int learnerId)
    {
        return _dbContext.UnitEnrollments
            .Where(ue => ue.LearnerId.Equals(learnerId)
                         && ue.KnowledgeUnit.CourseId.Equals(courseId)
                         && ue.Status.Equals(EnrollmentStatus.Active))
            .Include(ue => ue.KnowledgeUnit)
            .Select(ue => ue.KnowledgeUnit).ToList();
    }

    public bool HasActiveEnrollmentForUnit(int unitId, int learnerId)
    {
        return _dbContext.UnitEnrollments.Any(u => u.Status == EnrollmentStatus.Active &&
                                                   u.KnowledgeUnit.Id == unitId && u.LearnerId == learnerId);
    }

    public bool HasActiveEnrollmentForKc(int knowledgeComponentId, int learnerId)
    {
        var unitId = _dbContext.KnowledgeComponents
            .Where(kc => kc.Id == knowledgeComponentId)
            .Select(kc => kc.KnowledgeUnitId)
            .FirstOrDefault();

        return _dbContext.UnitEnrollments
            .Any(u => u.Status == EnrollmentStatus.Active &&
                      u.KnowledgeUnit.Id == unitId && u.LearnerId == learnerId);
    }

    public UnitEnrollment GetEnrollment(int unitId, int learnerId)
    {
        return _dbContext.UnitEnrollments
            .FirstOrDefault(e => e.KnowledgeUnit.Id == unitId && e.LearnerId == learnerId);
    }

    public List<UnitEnrollment> GetEnrollments(int unitId, int[] learnerIds)
    {
        return _dbContext.UnitEnrollments
            .Where(e => e.KnowledgeUnit.Id == unitId && learnerIds.Contains(e.LearnerId))
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
}