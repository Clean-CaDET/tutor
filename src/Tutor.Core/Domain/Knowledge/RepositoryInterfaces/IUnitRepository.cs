using System.Collections.Generic;
using Tutor.Core.BuildingBlocks.Generics;
using Tutor.Core.Domain.Knowledge.Structure;

namespace Tutor.Core.Domain.Knowledge.RepositoryInterfaces;

public interface IUnitRepository : ICrudRepository<KnowledgeUnit>
{
    List<KnowledgeUnit> GetByCourseId(int courseId);
    KnowledgeUnit GetUnitWithKcs(int unitId);
}