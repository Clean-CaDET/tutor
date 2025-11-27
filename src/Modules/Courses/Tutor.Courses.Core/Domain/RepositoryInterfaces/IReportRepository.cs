using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Courses.Core.Domain.Report;

namespace Tutor.Courses.Core.Domain.RepositoryInterfaces;

public interface IReportRepository : ICrudRepository<CourseReport>
{
    CourseReport? Get(int courseId, int learnerId);
    List<CourseReport> GetByLearners(int[] learnerIds);
}