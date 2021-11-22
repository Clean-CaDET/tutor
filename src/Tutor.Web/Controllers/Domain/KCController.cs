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
    [Route("api/knowledgeComponents/")]
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
        public ActionResult<List<UnitDTO>> GetUnits()
        {
            var result = _kcService.GetUnits();
            return Ok(result.Value.Select(u => _mapper.Map<UnitDTO>(u)).ToList());
        }

        [HttpGet("{knowledgeComponentId:int}")]
        public ActionResult<KnowledgeComponentDTO> GetKnowledgeComponent(int knowledgeComponentId)
        {
            var result = _kcService.GetKnowledgeComponentById(knowledgeComponentId);
            if (result.IsSuccess) return Ok(_mapper.Map<KnowledgeComponentDTO>(result.Value));
            return NotFound(result.Errors);
        }

        [HttpGet("assessmentEvents/{knowledgeComponentId:int}")]
        public ActionResult<AssessmentEventDTO> GetAssessmentEvents(int knowledgeComponentId)
        {
            var result = _kcService.GetAssessmentEventsByKnowledgeComponent(knowledgeComponentId);
            return Ok(result.Value.Select(ae => _mapper.Map<AssessmentEventDTO>(ae)).ToList());
        }
        
        [HttpGet("instructionalEvents/{knowledgeComponentId:int}")]
        public ActionResult<InstructionalEventDTO> GetInstructionalEvents(int knowledgeComponentId)
        {
            var result = _kcService.GetInstructionalEventsByKnowledgeComponent(knowledgeComponentId);
            return Ok(result.Value.Select(ie => _mapper.Map<InstructionalEventDTO>(ie)).ToList());
        }
    }
}