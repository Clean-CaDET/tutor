namespace Tutor.LearningTasks.API.Public.Learning;

using FluentResults;
using Dtos.Tasks;
using Tutor.LearningTasks.API.Dtos.TaskProgress;

public interface ITaskService
{
    Result<LearningTaskDto> Get(int id, int unitId, int learnerId);
    Result<List<TaskProgressSummaryDto>> GetByUnit(int unitId, int learnerId);
}
