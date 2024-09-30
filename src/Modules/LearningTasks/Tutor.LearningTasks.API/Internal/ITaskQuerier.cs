using FluentResults;
using Tutor.LearningTasks.API.Dtos.Tasks;

namespace Tutor.LearningTasks.API.Internal;

public interface ITaskQuerier
{
    Result<List<LearningTaskDto>> GetByUnits(int[] unitIds);
}