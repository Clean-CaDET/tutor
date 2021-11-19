using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.DomainModel.AssessmentEvents;
using Tutor.Core.DomainModel.Course;
using Tutor.Core.DomainModel.InstructionalEvents;
using Tutor.Core.DomainModel.KnowledgeComponents;
using Tutor.Web.Controllers.Domain.DTOs;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents;
using Tutor.Web.Controllers.Domain.DTOs.InstructionalEvents;

namespace Tutor.Web.Controllers.Domain
{
    [Route("api/units/")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitService _unitService;

        public UnitController(IMapper mapper, IUnitService unitService)
        {
            _mapper = mapper;
            _unitService = unitService;
        }

        [HttpGet]
        public ActionResult<List<UnitDTO>> GetUnits()
        {
            var result = _unitService.GetUnits();
            return Ok(result.Value.Select(u => _mapper.Map<UnitDTO>(u)).ToList());
        }

        [HttpGet("knowledgeComponents/{knowledgeComponentId:int}")]
        public ActionResult<KnowledgeComponentDTO> GetKnowledgeComponent(int knowledgeComponentId)
        {
            var result = _unitService.GetKnowledgeComponentById(knowledgeComponentId);
            if (result.IsSuccess) return Ok(_mapper.Map<KnowledgeComponentDTO>(result.Value));
            return NotFound(result.Errors);
        }

        [HttpGet("knowledgeComponents/assessmentEvents/{knowledgeComponentId:int}")]
        public ActionResult<AssessmentEventDTO> GetAssessmentEvents(int knowledgeComponentId)
        {
            var result = _unitService.GetAssessmentEventsByKnowledgeComponent(knowledgeComponentId);
            return Ok(result.Value.Select(ae => _mapper.Map<AssessmentEventDTO>(ae)).ToList());
        }
        
        [HttpGet("knowledgeComponents/instructionalEvents/{knowledgeComponentId:int}")]
        public ActionResult<InstructionalEventDTO> GetInstructionalEvents(int knowledgeComponentId)
        {
            var result = _unitService.GetInstructionalEventsByKnowledgeComponent(knowledgeComponentId);
            return Ok(result.Value.Select(ie => _mapper.Map<InstructionalEventDTO>(ie)).ToList());
        }
        
    }
}