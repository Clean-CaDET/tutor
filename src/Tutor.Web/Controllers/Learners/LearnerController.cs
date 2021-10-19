using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Tutor.Core.LearnerModel;
using Tutor.Core.LearnerModel.Learners;
using Tutor.Web.Controllers.Learners.DTOs;
using Tutor.Web.Security.IAM;

namespace Tutor.Web.Controllers.Learners
{
    [Route("api/learners/")]
    [ApiController]
    public class LearnerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILearnerService _learnerService;
        private readonly IAuthProvider _authProvider;

        public LearnerController(IMapper mapper, ILearnerService learnerService, IAuthProvider authProvider)
        {
            _mapper = mapper;
            _learnerService = learnerService;
            _authProvider = authProvider;
        }

        [HttpPost("register")]
        public async Task<ActionResult<LearnerDTO>> Register([FromBody] LearnerDTO learnerDto)
        {
            var learner = _mapper.Map<Learner>(learnerDto);

            if (bool.Parse(Environment.GetEnvironmentVariable("KEYCLOAK_ON") ?? "false"))
            {
                learner = await _authProvider.Register(learner);
            }

            var result = _learnerService.Register(learner);
            if(result.IsSuccess) return Ok(_mapper.Map<LearnerDTO>(result.Value));
            return BadRequest(result.Errors);
        }

        [HttpPost("login")]
        public ActionResult<LearnerDTO> Login([FromBody] LoginDTO login)
        {
            var result = _learnerService.Login(login.StudentIndex);
            if(result.IsSuccess) return Ok(_mapper.Map<LearnerDTO>(result.Value));
            return NotFound(result.Errors);
        }
    }
}