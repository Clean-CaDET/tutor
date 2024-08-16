using FluentResults;
using Tutor.KnowledgeComponents.API.Dtos;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge;

namespace Tutor.KnowledgeComponents.API.Public.Learning;

public interface IStructureService
{
    Result<List<KcWithMasteryDto>> GetKcsWithMasteries(int unitId, int learnerId);
    Result<KnowledgeComponentDto> GetKnowledgeComponent(int kcId, int learnerId);
}