using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Tutor.Core.LearnerModel;
using Tutor.Core.LearnerModel.Learners;
using Tutor.Web.Controllers.JWT;
using Tutor.Web.Controllers.JWT.DTOs;
using Tutor.Web.Controllers.Learners.DTOs;
using Tutor.Web.IAM;

namespace Tutor.Web.Controllers.Learners
{
    [Route("api/learners/")]
    [ApiController]
    public class LearnerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILearnerService _learnerService;
        private readonly IAuthProvider _authProvider;
        private readonly IJwtService _jwtService;

        public LearnerController(IMapper mapper, ILearnerService learnerService, IAuthProvider authProvider,
            IJwtService jwtService)
        {
            _mapper = mapper;
            _learnerService = learnerService;
            _authProvider = authProvider;
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<LearnerDto>> Register([FromBody] LearnerDto learnerDto)
        {
            var learner = _mapper.Map<Learner>(learnerDto);

            if (bool.Parse(Environment.GetEnvironmentVariable("KEYCLOAK_ON") ?? "false"))
            {
                learner = await _authProvider.Register(learner);
            }

            var result = _learnerService.Register(learner);
            if(result.IsSuccess) return Ok(_mapper.Map<LearnerDto>(result.Value));
            return BadRequest(result.Errors);
        }

        [HttpPost("login")]
        public ActionResult<LoginResponseDto> Login([FromBody] LoginDto login)
        {
            var result = _jwtService.GenerateToken(login);
            if (result.IsSuccess) return Ok(result.Value);
            return NotFound(result.Errors);
        }
    }
}