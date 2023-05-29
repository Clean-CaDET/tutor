using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.BuildingBlocks;
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

    public PagedResult<Course> GetEnrolledCourses(int learnerId, int page, int pageSize)
    {
        var task = _dbContext.LearnerGroups
            .Where(lg => lg.Membership.Any(m => m.Member.Id.Equals(learnerId)))
            .Select(lg => lg.Course).Where(c => !c.IsArchived).Distinct().GetPaged(page, pageSize);
        task.Wait();
        return task.Result;
    }

    public Course GetUnarchivedCourseEnrolledAndActiveUnits(int courseId, int learnerId)
    {
        var course = _dbContext.Courses.FirstOrDefault(c => c.Id.Equals(courseId) && !c.IsArchived);
        if(course == null) return null;

        var enrolledUnits = GetEnrolledAndActiveUnits(courseId, learnerId);
        return new Course(course, enrolledUnits);
    }

    private List<KnowledgeUnit> GetEnrolledAndActiveUnits(int courseId, int learnerId)
    {
        return _dbContext.UnitEnrollments
            .Where(ue => ue.LearnerId.Equals(learnerId)
                         && ue.KnowledgeUnit.CourseId.Equals(courseId)
                         && ue.Status == EnrollmentStatus.Active)
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

        return HasActiveEnrollmentForUnit(unitId, learnerId);
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

    public List<UnitEnrollment> GetActiveEnrollmentsForCourse(int courseId)
    {
        return _dbContext.UnitEnrollments
            .Where(ue => ue.KnowledgeUnit.CourseId.Equals(courseId) && ue.Status == EnrollmentStatus.Active).ToList();
    }
}