using FluentResults;

namespace Tutor.LearningTasks.API.Internal;

public interface ILearningTaskCloner
{
    Result CloneMany(List<Tuple<int, int>> unitIdPairs);
}