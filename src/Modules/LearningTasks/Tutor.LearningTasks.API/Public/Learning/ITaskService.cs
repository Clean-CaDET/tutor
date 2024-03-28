namespace Tutor.LearningTasks.API.Public.Learning;

using FluentResults;
using Tutor.LearningTasks.API.Dtos.LearningTasks;

public interface ITaskService
{
    Result<LearningTaskDto> Get(int id, int unitId, int learnerId);
}
