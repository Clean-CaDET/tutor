using FluentResults;

namespace Tutor.KnowledgeComponents.API.Internal;

public interface IMasteryFactory
{
    Result InitializeMasteries(int unitId, int[] learnerIds);
}