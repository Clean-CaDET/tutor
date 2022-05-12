using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tutor.Core.LearnerModel;
using Tutor.Infrastructure.Security.Authentication.Users;

namespace Tutor.Web.Controllers.Learners
{
    [Route("api/learners/")]
    [ApiController]
    public class LearnerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILearnerService _learnerService;

        public LearnerController(ILearnerService learnerService, IMapper mapper)
        {
            _learnerService = learnerService;
            _mapper = mapper;
        }

        [HttpGet("profile")]
        public ActionResult<LearnerDto> GetLearnerProfile()
        {
            var result = _learnerService.GetLearnerProfile(User.Id());
            if (result.IsFailed) return BadRequest(result.Errors);
            return Ok(_mapper.Map<LearnerDto>(result.Value));
        }

        [HttpGet("groups")]
        public ActionResult<LearnerGroup> GetGroups()
        {
            var result = _learnerService.GetGroups(User.Id());
            if (result.IsFailed) return BadRequest(result.Errors);
            return Ok(result.Value);
        }
    }
}