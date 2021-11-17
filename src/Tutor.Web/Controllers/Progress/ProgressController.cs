using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tutor.Core.ProgressModel.Progress;
using Tutor.Web.Controllers.Learners.DTOs;

namespace Tutor.Web.Controllers.Progress
{
    [Route("api/nodes/")]
    [ApiController]
    public class ProgressController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProgressService _progressService;

        public ProgressController(IMapper mapper, IProgressService progressService)
        {
            _mapper = mapper;
            _progressService = progressService;
        }

        [HttpGet("{lectureId}")]
        public ActionResult<List<NodeProgressDTO>> GetLectureNodes(int lectureId)
        {
            //TODO: Extract learner ID so that we can see the Status of each KN.
            var result = _progressService.GetKnowledgeNodes(lectureId, null);
            if(result.IsSuccess) return Ok(_mapper.Map<List<NodeProgressDTO>>(result.Value));
            return NotFound(result.Errors);
        }
        //TODO: The URLs don't follow best practices because the tension between KN and KNProgress. Will need to study this more.
        [HttpGet("content/{nodeId}")]
        public ActionResult<NodeProgressDTO> GetNodeContent(int nodeId)
        {
            //TODO: Extract learner ID so that we can form personalized content.
            var result = _progressService.GetNodeContent(nodeId, null);
            if (result.IsSuccess) return Ok(_mapper.Map<NodeProgressDTO>(result.Value));
            return NotFound(result.Errors);
        }
    }
}
