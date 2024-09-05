using FluentResults;
using Tutor.LearningTasks.API.Dtos.LearningTasks;

namespace Tutor.LearningTasks.API.Internal;

public interface ITaskQuerier
{
    Result<List<LearningTaskDto>> GetByUnits(List<int> unitIds);
}