using FluentResults;
using Tutor.LearningTasks.API.Dtos.Tasks;

namespace Tutor.LearningTasks.API.Public.Authoring;

public interface ILearningTaskService
{
    Result<LearningTaskDto> Get(int id, int unitId, int instructorId);
    Result<List<LearningTaskDto>> GetByUnit(int unitId, int instructorId);
    Result<LearningTaskDto> Create(LearningTaskDto learningTask, int instructorId);
    Result<LearningTaskDto> Clone(LearningTaskDto taskHeader, int instructorId);
    Result Move(int taskId, int destinationUnitId, int instructorId);
    Result<LearningTaskDto> Update(LearningTaskDto learningTask, int instructorId);
    Result Delete(int id, int unitId, int instructorId);
}
