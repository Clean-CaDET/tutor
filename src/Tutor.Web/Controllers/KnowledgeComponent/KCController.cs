using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tutor.Core.KnowledgeComponentModel;
using Tutor.Web.Controllers.KnowledgeComponent.DTOs;

namespace Tutor.Web.Controllers.KnowledgeComponent
{
    [Route("api/knowledge-components")]
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
        public ActionResult<List<KnowledgeComponentDTO>> GetKnowledgeComponents()
        {
            var kcs = _kcService.GetKnowledgeComponents();
            return Ok(kcs.Select(kc => _mapper.Map<KnowledgeComponentDTO>(kc)).ToList());
        }
    }
}