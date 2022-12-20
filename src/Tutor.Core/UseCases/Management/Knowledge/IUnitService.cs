using System.Collections.Generic;
using FluentResults;
using Tutor.Core.Domain.Knowledge.Structure;

namespace Tutor.Core.UseCases.Management.Knowledge;

public interface IUnitService
{
    Result<List<KnowledgeUnit>> GetByCourse(int courseId);
    Result<KnowledgeUnit> Create(KnowledgeUnit unit);
    Result<KnowledgeUnit> Update(KnowledgeUnit unit);
    Result Delete(int id);
}