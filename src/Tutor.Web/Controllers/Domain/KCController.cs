using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.LearnerModel.DomainOverlay;
using Tutor.Infrastructure.Security.Authorization.JWT;
using Tutor.Web.Controllers.Domain.DTOs;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentItems;
using Tutor.Web.Controllers.Domain.DTOs.InstructionalItems;

namespace Tutor.Web.Controllers.Domain
{
    [Authorize(Policy = "learnerPolicy")]
    [Route("api/units/")]
    [ApiController]
    public class KcController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILearnerKcMasteryService _learnerKcMasteryService;

        public KcController(IMapper mapper, ILearnerKcMasteryService learnerKcMasteryService)
        {
            _mapper = mapper;
            _learnerKcMasteryService = learnerKcMasteryService;
        }

        [HttpGet]
        public ActionResult<List<UnitDto>> GetUnits()
        {
            var result = _learnerKcMasteryService.GetUnits();
            return Ok(result.Value.Select(u => _mapper.Map<UnitDto>(u)).ToList());
        }

        [HttpGet("{unitId:int}")]
        public ActionResult<List<UnitDto>> GetUnit(int unitId, [FromQuery] int learnerId)
        {
            var result = _learnerKcMasteryService.GetUnit(unitId, learnerId);
            if (result.IsSuccess) return Ok(_mapper.Map<UnitDto>(result.Value));
            return NotFound(result.Errors);
        }

        [HttpGet("knowledge-components/{knowledgeComponentId:int}")]
        public ActionResult<KnowledgeComponentDto> GetKnowledgeComponent(int knowledgeComponentId)
        {
            var result = _learnerKcMasteryService.GetKnowledgeComponentById(knowledgeComponentId);
            if (result.IsSuccess) return Ok(_mapper.Map<KnowledgeComponentDto>(result.Value));
            return NotFound(result.Errors);
        }

        [HttpGet("knowledge-components/{knowledgeComponentId:int}/instructional-items/")]
        public ActionResult<List<InstructionalItemDto>> GetInstructionalItems(int knowledgeComponentId)
        {
            var result = _learnerKcMasteryService.GetInstructionalItems(knowledgeComponentId, User.Id());
            return Ok(result.Value.Select(ie => _mapper.Map<InstructionalItemDto>(ie)).ToList());
        }

        [HttpPost("knowledge-component")]
        public ActionResult<AssessmentItemDto> GetSuitableAssessmentItem([FromBody] AssessmentItemRequestDto assessmentItemRequest)
        {
            var result = _learnerKcMasteryService.SelectSuitableAssessmentItem(assessmentItemRequest.KnowledgeComponentId, assessmentItemRequest.LearnerId);
            if (result.IsSuccess) return Ok(_mapper.Map<AssessmentItemDto>(result.Value));
            return NotFound(result.Errors);
        }

        [HttpGet("knowledge-components/statistics/{knowledgeComponentId:int}")]
        public ActionResult<KnowledgeComponentStatisticsDto> GetKnowledgeComponentStatistics(int knowledgeComponentId)
        {
            var result = _learnerKcMasteryService.GetKnowledgeComponentStatistics(User.Id(), knowledgeComponentId);
            if (result.IsSuccess) return Ok(_mapper.Map<KnowledgeComponentStatisticsDto>(result.Value));
            return NotFound(result.Errors);
        }

        [HttpPost("knowledge-components/{knowledgeComponentId:int}/session/launch")]
        public ActionResult LaunchSession(int knowledgeComponentId)
        {
            var result = _learnerKcMasteryService.LaunchSession(User.Id(), knowledgeComponentId);
            if (result.IsSuccess) return Ok();
            return BadRequest(result.Errors);
        }

        [HttpPost("knowledge-components/{knowledgeComponentId:int}/session/terminate")]
        public ActionResult TerminateSession(int knowledgeComponentId)
        {
            var result = _learnerKcMasteryService.TerminateSession(User.Id(), knowledgeComponentId);
            if (result.IsSuccess) return Ok();
            return BadRequest(result.Errors);
        }
    }
}