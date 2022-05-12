using System.Collections.Generic;
using Tutor.Core.DomainModel.KnowledgeComponents;

namespace Tutor.Core.DomainModel
{
    public interface IDomainRepository
    {
        List<KnowledgeUnit> GetUnits();
    }
}
