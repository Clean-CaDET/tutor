using Tutor.BuildingBlocks.Core.UseCases;

namespace Tutor.Courses.Core.Domain.RepositoryInterfaces;

public interface IWeeklyFeedbackRepository : ICrudRepository<WeeklyFeedback>
{
    List<WeeklyFeedback> GetByCourseAndLearner(int courseId, int learnerId);
    List<WeeklyFeedback> GetByCourseAndLearners(int courseId, int[] learnerIds, DateTime start, DateTime end);
    List<WeeklyFeedback> GetByCourse(int courseId);
}