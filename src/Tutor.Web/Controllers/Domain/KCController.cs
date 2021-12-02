using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.DomainModel.KnowledgeComponents;
using Tutor.Web.Controllers.Domain.DTOs;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents;
using Tutor.Web.Controllers.Domain.DTOs.InstructionalEvents;

namespace Tutor.Web.Controllers.Domain
{
    [Route("api/knowledge-components/")]
    [ApiController]
    public class KCController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IKCService _kcService;

        public KCController(IMapper mapper, IKCService kcService)
        {
            _mapper = mapper;
            _kcService = kcService;
        }

        [HttpGet]
        public ActionResult<List<UnitDto>> GetUnits()
        {
            var result = _kcService.GetUnits();
            return Ok(result.Value.Select(u => _mapper.Map<UnitDto>(u)).ToList());
        }

        [HttpGet("{knowledgeComponentId:int}")]
        public ActionResult<KnowledgeComponentDto> GetKnowledgeComponent(int knowledgeComponentId)
        {
            var result = _kcService.GetKnowledgeComponentById(knowledgeComponentId);
            if (result.IsSuccess) return Ok(_mapper.Map<KnowledgeComponentDto>(result.Value));
            return NotFound(result.Errors);
        }

        [HttpGet("{knowledgeComponentId:int}/assessment-events/")]
        public ActionResult<AssessmentEventDto> GetAssessmentEvents(int knowledgeComponentId)
        {
            var result = _kcService.GetAssessmentEventsByKnowledgeComponent(knowledgeComponentId);
            return Ok(result.Value.Select(ae => _mapper.Map<AssessmentEventDto>(ae)).ToList());
        }
        
        [HttpGet("{knowledgeComponentId:int}/instructional-events/")]
        public ActionResult<InstructionalEventDto> GetInstructionalEvents(int knowledgeComponentId)
        {
            var result = _kcService.GetInstructionalEventsByKnowledgeComponent(knowledgeComponentId);
            return Ok(result.Value.Select(ie => _mapper.Map<InstructionalEventDto>(ie)).ToList());
        }
    }
}