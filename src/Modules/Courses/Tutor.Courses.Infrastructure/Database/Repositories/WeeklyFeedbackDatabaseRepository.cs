using Tutor.BuildingBlocks.Infrastructure.Database;
using Tutor.Courses.Core.Domain;
using Tutor.Courses.Core.Domain.RepositoryInterfaces;

namespace Tutor.Courses.Infrastructure.Database.Repositories;

public class WeeklyFeedbackDatabaseRepository : CrudDatabaseRepository<WeeklyFeedback, CoursesContext>, IWeeklyFeedbackRepository
{
    public WeeklyFeedbackDatabaseRepository(CoursesContext dbContext) : base(dbContext) {}

    public List<WeeklyFeedback> GetByCourseAndLearner(int courseId, int learnerId)
    {
        return DbContext.WeeklyProgress
            .Where(p => p.CourseId == courseId && p.LearnerId == learnerId)
            .ToList();
    }

    public List<WeeklyFeedback> GetByCourseAndLearners(int courseId, int[] learnerIds, DateTime start, DateTime end)
    {
        return DbContext.WeeklyProgress
            .Where(p => p.CourseId == courseId && learnerIds.Contains(p.LearnerId) && p.WeekEnd > start && p.WeekEnd < end)
            .ToList();
    }
}