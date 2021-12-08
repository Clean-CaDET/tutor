using FluentResults;
using System.Collections.Generic;
using Tutor.Core.DomainModel.AssessmentEvents;
using Tutor.Core.DomainModel.InstructionalEvents;

namespace Tutor.Core.DomainModel.KnowledgeComponents
{
    public class KCService : IKCService
    {
        private readonly IKCRepository _ikcRepository;

        public KCService(IKCRepository ikcRepository)
        {
            _ikcRepository = ikcRepository;
        }
        
        public Result<List<Unit>> GetUnits()
        {
            return Result.Ok(_ikcRepository.GetUnits());
        }
        
        public Result<Unit> GetUnit(int id)
        {
            return Result.Ok(_ikcRepository.GetUnit(id));
        }

        public Result<KnowledgeComponent> GetKnowledgeComponentById(int id)
        {
            var knowledgeComponent = _ikcRepository.GetKnowledgeComponent(id);
            if (knowledgeComponent == null) return Result.Fail("No KC with index: " + id);
            return Result.Ok(knowledgeComponent);
        }

        public Result<List<AssessmentEvent>> GetAssessmentEventsByKnowledgeComponent(int id)
        {
            return Result.Ok(_ikcRepository.GetAssessmentEventsByKnowledgeComponent(id));
        }

        public Result<List<InstructionalEvent>> GetInstructionalEventsByKnowledgeComponent(int id)
        {
            return Result.Ok(_ikcRepository.GetInstructionalEventsByKnowledgeComponent(id));
        }
    }
}