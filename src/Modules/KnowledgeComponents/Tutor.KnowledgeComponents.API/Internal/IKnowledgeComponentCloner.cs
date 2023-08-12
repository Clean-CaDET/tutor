using FluentResults;

namespace Tutor.KnowledgeComponents.API.Internal;

public interface IKnowledgeComponentCloner
{
    Result CloneMany(List<Tuple<int, int>> unitIdPairs);
}