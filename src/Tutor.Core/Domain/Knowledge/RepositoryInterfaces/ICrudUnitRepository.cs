using System.Collections.Generic;
using FluentResults;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.Knowledge.Structure;

namespace Tutor.Core.Domain.Knowledge.RepositoryInterfaces;

public interface ICrudUnitRepository : ICrudRepository<KnowledgeUnit>
{
    Result<List<KnowledgeUnit>> GetByCourseId(int courseId);
}