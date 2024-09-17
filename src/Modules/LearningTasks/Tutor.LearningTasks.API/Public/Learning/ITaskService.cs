namespace Tutor.LearningTasks.API.Public.Learning;

using FluentResults;
using Dtos.Tasks;

public interface ITaskService
{
    Result<LearningTaskDto> Get(int id, int unitId, int learnerId);
    Result<List<ProgressDto>> GetByUnit(int unitId, int learnerId);
}
