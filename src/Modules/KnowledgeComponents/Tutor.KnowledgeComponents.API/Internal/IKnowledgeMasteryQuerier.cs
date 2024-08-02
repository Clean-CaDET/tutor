using FluentResults;

namespace Tutor.KnowledgeComponents.API.Internal;

public interface IKnowledgeMasteryQuerier
{
    Result<Tuple<int, int>> CountTotalAndSatisfied(int unitId, int learnerId);
}