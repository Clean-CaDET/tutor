using Microsoft.EntityFrameworkCore;
using Tutor.BuildingBlocks.Infrastructure.Database;
using Tutor.Courses.Core.Domain.Reflections;

namespace Tutor.Courses.Infrastructure.Database.Repositories;

public class ReflectionDatabaseRepository : CrudDatabaseRepository<Reflection, CoursesContext>, IReflectionRepository
{
    public ReflectionDatabaseRepository(CoursesContext dbContext) : base(dbContext) {}

    public List<Reflection> GetByUnit(int unitId)
    {
        return DbContext.Reflections
            .Where(r => r.UnitId == unitId)
            .OrderBy(r => r.Order)
            .Include(r => r.Questions.OrderBy(q => q.Order))
            .AsNoTracking()
            .ToList();
    }

    public List<Reflection> GetByUnitsWithQuestions(int[] unitIds)
    {
        return DbContext.Reflections
            .Where(r => unitIds.Contains(r.UnitId))
            .Include(r => r.Questions)
            .AsNoTracking()
            .ToList();
    }

    public List<Reflection> GetByUnitsWithSubmissions(int[] unitIds)
    {
        return DbContext.Reflections
            .Where(r => unitIds.Contains(r.UnitId))
            .OrderBy(r => r.Order)
            .Include(r => r.Questions.OrderBy(q => q.Order))
            .Include(r => r.Submissions)
            .AsNoTracking()
            .ToList();
    }

    public List<Reflection> GetByUnitWithSubmission(int unitId, int learnerId)
    {
        return DbContext.Reflections
            .Where(r => r.UnitId == unitId)
            .Include(r => r.Submissions.Where(s => s.LearnerId == learnerId))
            .AsNoTracking()
            .ToList();
    }

    public Reflection? GetWithSubmission(int reflectionId, int learnerId)
    {
        return DbContext.Reflections
            .Include(r => r.Questions)
            .Include(r => r.Submissions.Where(s => s.LearnerId == learnerId))
            .FirstOrDefault(r => r.Id == reflectionId);
    }

    public Reflection? GetWithQuestions(int reflectionId)
    {
        return DbContext.Reflections
            .Include(r => r.Questions)
            .FirstOrDefault(r => r.Id == reflectionId);
    }

    public List<Reflection> GetManyWithSubmission(List<int> reflectionIds, int learnerId)
    {
        return DbContext.Reflections
            .Where(r => reflectionIds.Contains(r.Id))
            .Include(r => r.Questions.OrderBy(q => q.Order))
            .Include(r => r.Submissions.Where(s => s.LearnerId == learnerId))
            .AsNoTracking()
            .ToList();
    }

    public void CreateAnswer(ReflectionAnswer answer)
    {
        DbContext.ReflectionAnswers.Attach(answer);
    }
}