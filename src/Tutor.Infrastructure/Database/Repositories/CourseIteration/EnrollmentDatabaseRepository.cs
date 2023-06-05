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

    public Course GetEnrolledCourse(int courseId, int learnerId)
    {
        return _dbContext.LearnerGroups
            .Where(lg => lg.Membership.Any(m => m.Member.Id.Equals(learnerId)))
            .Select(lg => lg.Course).FirstOrDefault(c => c.Id == courseId && !c.IsArchived);
    }

    public List<UnitEnrollment> GetEnrollmentsWithUnitsByCourse(int courseId, int learnerId)
    {
        return _dbContext.UnitEnrollments
            .Where(ue => ue.LearnerId.Equals(learnerId)
                         && ue.KnowledgeUnit.CourseId.Equals(courseId))
            .Include(ue => ue.KnowledgeUnit).ToList();
    }

    public UnitEnrollment GetEnrollment(int unitId, int learnerId)
    {
        return _dbContext.UnitEnrollments
            .FirstOrDefault(e => e.KnowledgeUnit.Id == unitId && e.LearnerId == learnerId);
    }

    public UnitEnrollment GetEnrollmentForKc(int knowledgeComponentId, int learnerId)
    {
        var unitId = _dbContext.KnowledgeComponents
            .Where(kc => kc.Id == knowledgeComponentId)
            .Select(kc => kc.KnowledgeUnitId)
            .FirstOrDefault();

        return GetEnrollment(unitId, learnerId);
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