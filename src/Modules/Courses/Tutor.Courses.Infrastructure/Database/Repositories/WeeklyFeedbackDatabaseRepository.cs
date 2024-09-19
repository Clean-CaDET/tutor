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
}