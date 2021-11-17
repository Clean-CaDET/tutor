using FluentResults;
using System.Collections.Generic;
using Tutor.Core.DomainModel.KnowledgeComponents;

namespace Tutor.Core.DomainModel.Course
{
    public interface IUnitService
    {
        Result<List<Unit>> GetUnits();

        Result<KnowledgeComponent> GetKnowledgeComponentById(int id);
    }
}