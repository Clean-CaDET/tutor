using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.DomainModel;
using Tutor.Web.Controllers.Domain.DTOs;

namespace Tutor.Web.Controllers.Domain
{
    [Route("api/domain")]
    [Authorize(Policy = "instructorPolicy")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IKnowledgeUnitRepository _knowledgeUnitRepository;

        public UnitController(IKnowledgeUnitRepository knowledgeUnitRepository, IMapper mapper)
        {
            _knowledgeUnitRepository = knowledgeUnitRepository;
            _mapper = mapper;
        }

        [HttpGet("units")]
        public ActionResult<List<UnitDto>> GetAll()
        {
            var result = _knowledgeUnitRepository.GetAll();
            return Ok(result.Select(u => _mapper.Map<UnitDto>(u)).ToList());
        }
    }
}
