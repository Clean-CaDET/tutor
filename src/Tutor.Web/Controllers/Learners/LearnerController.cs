using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tutor.Core.LearnerModel;
using Tutor.Infrastructure.Security.Authorization;
using Tutor.Infrastructure.Security.Authorization.JWT;

namespace Tutor.Web.Controllers.Learners
{
    [Route("api/learners/")]
    [ApiController]
    public class LearnerController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        private readonly ILearnerService _learnerService;

        public LearnerController(IAuthService authService, ILearnerService learnerService, IMapper mapper)
        {
            _authService = authService;
            _learnerService = learnerService;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public ActionResult<AuthenticationResponse> Login([FromBody] LoginDto login)
        {
            var result = _authService.Login(login.StudentIndex, login.Password);
            if (result.IsSuccess) return Ok(result.Value);
            return NotFound(result.Errors);
        }

        [HttpPost("refresh")]
        public ActionResult<AuthenticationResponse> RefreshToken([FromBody] AuthenticationTokens authenticationTokens)
        {
            var result = _authService.RefreshToken(authenticationTokens);
            if (result.IsSuccess) return Ok(result.Value);
            return BadRequest(result.Errors);
        }

        [HttpGet("profile")]
        public ActionResult<LearnerDto> GetLearnerProfile()
        {
            var result = _learnerService.GetLearnerProfile(User.Id());
            if (result.IsFailed) return BadRequest(result.Errors);
            return Ok(_mapper.Map<LearnerDto>(result.Value));
        }
    }
}