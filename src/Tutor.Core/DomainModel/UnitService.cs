using System.Collections.Generic;
using FluentResults;
using Tutor.Core.DomainModel.Units;

namespace Tutor.Core.DomainModel
{
    public class UnitService : IUnitService
    {
        private readonly IUnitRepository _unitRepository;

        public UnitService(IUnitRepository unitRepository)
        {
            _unitRepository = unitRepository;
        }
        
        public Result<List<Unit>> GetUnits()
        {
            return Result.Ok(_unitRepository.GetUnits());
        }

        public Result<UnitKnowledgeComponent> GetKnowledgeComponentById(int id)
        {
            var knowledgeComponent = _unitRepository.GetKnowledgeComponent(id);
            if (knowledgeComponent == null) return Result.Fail("No KC with index: " + id);
            return Result.Ok(knowledgeComponent);
        }
    }
}