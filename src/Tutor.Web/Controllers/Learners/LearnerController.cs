using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Tutor.Core.LearnerModel.Learners;
using Tutor.Infrastructure.Security.Authorization;
using Tutor.Infrastructure.Security.Authorization.JWT;
using Tutor.Web.Controllers.Learners.DTOs;
using Tutor.Web.IAM;

namespace Tutor.Web.Controllers.Learners
{
    [Route("api/learners/")]
    [ApiController]
    public class LearnerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAuthProvider _authProvider;
        private readonly IAuthService _authService;

        public LearnerController(IMapper mapper, IAuthProvider authProvider, IAuthService authService)
        {
            _mapper = mapper;
            _authProvider = authProvider;
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthenticationResponse>> Register([FromBody] LearnerDto learnerDto)
        {
            var learner = _mapper.Map<Learner>(learnerDto); //TODO: Make this more generic.

            if (bool.Parse(Environment.GetEnvironmentVariable("KEYCLOAK_ON") ?? "false"))
            {
                learner = await _authProvider.Register(learner);
            }

            var result = _authService.Register(learner);
            if(result.IsSuccess) return Ok(result);
            return BadRequest(result.Errors);
        }

        [HttpPost("login")]
        public ActionResult<AuthenticationResponse> Login([FromBody] LoginDto login)
        {
            var result = _authService.Login(login.StudentIndex, login.Password); //TODO: Make this more generic.
            if (result.IsSuccess) return Ok(result.Value);
            return NotFound(result.Errors);
        }

        [HttpPost("refresh")]
        public ActionResult<AuthenticationResponse> RefreshToken([FromBody] UserCredentials userCredentials)
        {
            var result = _authService.RefreshToken(userCredentials);
            if (result.IsSuccess) return Ok(result.Value);
            return NotFound(result.Errors);
        }
    }
}