using FluentResults;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge;

namespace Tutor.KnowledgeComponents.API.Internal;

public interface IKnowledgeComponentQuerier
{
    Result<List<KnowledgeComponentDto>> GetByUnits(int[] unitIds);
}