using System.Collections.Generic;
using Tutor.Core.DomainModel.KnowledgeComponents;

namespace Tutor.Core.DomainModel
{
    public interface IKnowledgeUnitRepository
    {
        KnowledgeUnit Get(int id);
        List<KnowledgeUnit> GetAll();
    }
}
