using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tutor.Core.DomainModel;
using Tutor.Core.DomainModel.Units;
using Tutor.Web.Controllers.Units.DTOs;

namespace Tutor.Web.Controllers.Units
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
        public ActionResult<UnitKnowledgeComponentDTO> GetKnowledgeComponent(int knowledgeComponentId)
        {
            var result = _unitService.GetKnowledgeComponentById(knowledgeComponentId);
            if (result.IsSuccess) return Ok(_mapper.Map<UnitKnowledgeComponent>(result.Value));
            return NotFound(result.Errors);
        }
    }
}