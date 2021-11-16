using System.Collections.Generic;
using Tutor.Core.DomainModel.Units;

namespace Tutor.Core.DomainModel
{
    public interface IUnitRepository
    {
        Unit GetUnit(int id);
        List<Unit> GetUnits();

        UnitKnowledgeComponent GetKnowledgeComponent(int id);
    }
}