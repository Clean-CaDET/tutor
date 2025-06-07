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

    public List<Reflection> GetByUnits(int[] unitIds)
    {
        return DbContext.Reflections
            .Where(r => unitIds.Contains(r.UnitId))
            .OrderBy(r => r.Order)
            .Include(r => r.Questions.OrderBy(q => q.Order))
            .AsNoTracking()
            .ToList();
    }

    public List<ReflectionAnswer> GetAnswersByUnits(int learnerId, int[] unitIds)
    {
        return DbContext.ReflectionAnswers
            .Join(DbContext.Reflections,
                answer => answer.ReflectionId,
                reflection => reflection.Id,
                (answer, reflection) => new { answer, reflection })
            .Where(x => unitIds.Contains(x.reflection.UnitId))
            .Select(x => x.answer).ToList();
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

    public void CreateAnswer(ReflectionAnswer answer)
    {
        DbContext.ReflectionAnswers.Attach(answer);
    }
}