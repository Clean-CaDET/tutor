using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.DomainModel.Course;
using Tutor.Core.DomainModel.KnowledgeComponents;
using Tutor.Web.Controllers.Domain.DTOs;

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

        [HttpGet("kc/{knowledgeComponentId:int}")]
        public ActionResult<KnowledgeComponentDTO> GetKnowledgeComponent(int knowledgeComponentId)
        {
            var result = _unitService.GetKnowledgeComponentById(knowledgeComponentId);
            if (result.IsSuccess) return Ok(_mapper.Map<KnowledgeComponent>(result.Value));
            return NotFound(result.Errors);
        }
    }
}