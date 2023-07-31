using FluentResults;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge;

namespace Tutor.KnowledgeComponents.API.Public.Authoring;

public interface IKnowledgeComponentService
{
    Result<KnowledgeComponentDto> Get(int id, int instructorId);
    Result<KnowledgeComponentDto> Create(KnowledgeComponentDto kc, int instructorId);
    Result<KnowledgeComponentDto> Update(KnowledgeComponentDto kc, int instructorId);
    Result Delete(int id, int instructorId);
}