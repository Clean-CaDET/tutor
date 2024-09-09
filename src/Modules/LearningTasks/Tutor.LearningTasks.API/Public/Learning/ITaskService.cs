namespace Tutor.LearningTasks.API.Public.Learning;

using FluentResults;
using Dtos.Tasks;

public interface ITaskService
{
    Result<LearningTaskDto> Get(int id, int unitId, int learnerId);
    Result<List<LearningTaskDto>> GetByUnit(int unitId, int learnerId);
}
