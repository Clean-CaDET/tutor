using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.LearningTasks.Core.Domain.Activities;

namespace Tutor.LearningTasks.Core.Domain.RepositoryInterfaces;

public interface IExampleRepository : ICrudRepository<Example> 
{
    List<Example> GetActivityExamples(int activityId);
}
