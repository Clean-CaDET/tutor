using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Tutor.Core.DomainModel.KnowledgeComponents;
using Tutor.Web.Controllers.Domain.DTOs;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents;
using Tutor.Web.Controllers.Domain.DTOs.InstructionalEvents;
using Tutor.Infrastructure.Security.Authorization.JWT;

namespace Tutor.Web.Controllers.Domain
{
    [Authorize(Policy = "learnerPolicy")]
    [Route("api/units/")]
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

        [HttpGet("{unitId:int}")]
        public ActionResult<List<UnitDto>> GetUnit(int unitId, [FromQuery] int learnerId)
        {
            var result = _kcService.GetUnit(unitId, learnerId);
            if (result.IsSuccess) return Ok(_mapper.Map<UnitDto>(result.Value));
            return NotFound(result.Errors);
        }

        [HttpGet("knowledge-components/{knowledgeComponentId:int}")]
        public ActionResult<KnowledgeComponentDto> GetKnowledgeComponent(int knowledgeComponentId)
        {
            var result = _kcService.GetKnowledgeComponentById(knowledgeComponentId);
            if (result.IsSuccess) return Ok(_mapper.Map<KnowledgeComponentDto>(result.Value));
            return NotFound(result.Errors);
        }

        [HttpGet("knowledge-components/{knowledgeComponentId:int}/assessment-events/")]
        public ActionResult<List<AssessmentEventDto>> GetAssessmentEvents(int knowledgeComponentId)
        {
            var result = _kcService.GetAssessmentEventsByKnowledgeComponent(knowledgeComponentId);
            return Ok(result.Value.Select(ae => _mapper.Map<AssessmentEventDto>(ae)).ToList());
        }

        [HttpGet("knowledge-components/{knowledgeComponentId:int}/instructional-events/")]
        public ActionResult<List<InstructionalEventDto>> GetInstructionalEvents(int knowledgeComponentId)
        {
            var result = _kcService.GetInstructionalEventsByKnowledgeComponent(knowledgeComponentId);
            return Ok(result.Value.Select(ie => _mapper.Map<InstructionalEventDto>(ie)).ToList());
        }

        [HttpPost("knowledge-component")]
        public ActionResult<AssessmentEventDto> GetSuitableAssessmentEvent([FromBody] AssessmentEventRequestDto assessmentEventRequest)
        {
            var result = _kcService.SelectSuitableAssessmentEvent(assessmentEventRequest.KnowledgeComponentId, assessmentEventRequest.LearnerId);
            if (result.IsSuccess) return Ok(_mapper.Map<AssessmentEventDto>(result.Value));
            return NotFound(result.Errors);
        }

        [HttpGet("knowledge-components/statistics/{knowledgeComponentId:int}")]
        public ActionResult<KnowledgeComponentStatisticsDto> GetKnowledgeComponentStatistics(int knowledgeComponentId)
        {
            var result = _kcService.GetKnowledgeComponentStatistics(User.Id(), knowledgeComponentId);
            if (result.IsSuccess) return Ok(_mapper.Map<KnowledgeComponentStatisticsDto>(result.Value));
            return NotFound(result.Errors);
        }

        [HttpPost("knowledge-components/{knowledgeComponentId:int}/session/launch")]
        public ActionResult LaunchSession(int knowledgeComponentId)
        {
            var result = _kcService.LaunchSession(User.Id(), knowledgeComponentId);
            if (result.IsSuccess) return Ok();
            return BadRequest(result.Errors);
        }

        [HttpPost("knowledge-components/{knowledgeComponentId:int}/session/terminate")]
        public ActionResult TerminateSession(int knowledgeComponentId)
        {
            var result = _kcService.TerminateSession(User.Id(), knowledgeComponentId);
            if (result.IsSuccess) return Ok();
            return BadRequest(result.Errors);
        }
    }
}