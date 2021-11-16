using System.Collections.Generic;
using FluentResults;
using Tutor.Core.DomainModel.Units;

namespace Tutor.Core.DomainModel
{
    public interface IUnitService
    {
        Result<List<Unit>> GetUnits();

        Result<UnitKnowledgeComponent> GetKnowledgeComponentById(int id);
    }
}