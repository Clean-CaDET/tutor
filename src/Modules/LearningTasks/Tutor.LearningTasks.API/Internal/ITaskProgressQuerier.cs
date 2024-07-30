using FluentResults;

namespace Tutor.LearningTasks.API.Internal;

public interface ITaskProgressQuerier
{
    Result<Tuple<int, int>> CountTotalAndCompleted(int unitId, int learnerId);
}