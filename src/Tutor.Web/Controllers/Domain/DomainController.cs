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
    public class DomainController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDomainRepository _domainRepository;

        public DomainController(IDomainRepository domainRepository, IMapper mapper)
        {
            _domainRepository = domainRepository;
            _mapper = mapper;
        }

        [HttpGet("units")]
        public ActionResult<List<UnitDto>> GetUnits()
        {
            var result = _domainRepository.GetUnits();
            return Ok(result.Select(u => _mapper.Map<UnitDto>(u)).ToList());
        }
    }
}
