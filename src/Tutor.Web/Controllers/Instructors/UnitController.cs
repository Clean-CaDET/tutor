using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.DomainModel;
using Tutor.Web.Mappings.Domain.DTOs;

namespace Tutor.Web.Controllers.Instructors
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
        public ActionResult<List<KnowledgeUnitDto>> GetAll()
        {
            var result = _knowledgeUnitRepository.GetAll();
            return Ok(result.Select(u => _mapper.Map<KnowledgeUnitDto>(u)).ToList());
        }
        
        [HttpGet("units/{courseId}")]
        public ActionResult<List<KnowledgeUnitDto>> GetByCourse(int courseId)
        {
            var result = _knowledgeUnitRepository.GetByCourse(courseId);
            return Ok(result.Select(u => _mapper.Map<KnowledgeUnitDto>(u)).ToList());
        }
    }
}
