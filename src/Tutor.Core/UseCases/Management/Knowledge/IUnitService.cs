using FluentResults;
using Tutor.Core.Domain.Knowledge.Structure;

namespace Tutor.Core.UseCases.Management.Knowledge;

public interface IUnitService
{
    Result<KnowledgeUnit> Create(KnowledgeUnit unit, int instructorId);
    Result<KnowledgeUnit> Update(KnowledgeUnit unit, int instructorId);
    Result Delete(int id, int instructorId);
}