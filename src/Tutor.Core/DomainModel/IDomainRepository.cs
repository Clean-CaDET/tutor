using System.Collections.Generic;
using Tutor.Core.DomainModel.KnowledgeComponents;

namespace Tutor.Core.DomainModel
{
    public interface IDomainRepository
    {
        KnowledgeUnit GetUnit(int id);
        List<KnowledgeUnit> GetUnits();
    }
}
