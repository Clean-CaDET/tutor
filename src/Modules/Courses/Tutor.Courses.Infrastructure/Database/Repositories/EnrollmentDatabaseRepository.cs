using Microsoft.EntityFrameworkCore;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.BuildingBlocks.Infrastructure.Database;
using Tutor.Courses.Core.Domain;
using Tutor.Courses.Core.Domain.RepositoryInterfaces;

namespace Tutor.Courses.Infrastructure.Database.Repositories;

public class EnrollmentDatabaseRepository : IEnrollmentRepository
{
    private readonly CoursesContext _dbContext;

    public EnrollmentDatabaseRepository(CoursesContext dbContext)
    {
        _dbContext = dbContext;
    }

    public PagedResult<Course> GetEnrolledCourses(int learnerId, int page, int pageSize)
    {
        var task = _dbContext.LearnerGroups
            .Where(lg => EF.Functions.JsonContains(lg.LearnerIds, $"{learnerId}"))
            .Select(lg => lg.Course).Where(c => !c.IsArchived)
            .Distinct().GetPaged(page, pageSize);
        task.Wait();
        return task.Result;
    }

    public Course? GetEnrolledCourse(int courseId, int learnerId)
    {
        return _dbContext.LearnerGroups
            .Where(lg => EF.Functions.JsonContains(lg.LearnerIds, $"{learnerId}"))
            .Select(lg => lg.Course)
            .FirstOrDefault(c => c.Id == courseId && !c.IsArchived);
    }

    public List<UnitEnrollment> GetEnrolledUnits(int courseId, int learnerId)
    {
        return _dbContext.UnitEnrollments
            .Where(ue => ue.LearnerId.Equals(learnerId)
                         && ue.KnowledgeUnit.CourseId.Equals(courseId))
            .Include(ue => ue.KnowledgeUnit).ToList();
    }

    public UnitEnrollment GetEnrollment(int unitId, int learnerId)
    {
        return _dbContext.UnitEnrollments
            .First(e => e.KnowledgeUnit.Id == unitId && e.LearnerId == learnerId);
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