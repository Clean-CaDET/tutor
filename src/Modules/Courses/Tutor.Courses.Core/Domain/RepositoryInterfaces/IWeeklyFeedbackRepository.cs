using Tutor.BuildingBlocks.Core.UseCases;

namespace Tutor.Courses.Core.Domain.RepositoryInterfaces;

public interface IWeeklyFeedbackRepository : ICrudRepository<WeeklyFeedback>
{
    List<WeeklyFeedback> GetByCourseAndLearner(int courseId, int learnerId);
}