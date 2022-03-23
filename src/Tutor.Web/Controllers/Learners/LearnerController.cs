using Microsoft.AspNetCore.Mvc;
using Tutor.Infrastructure.Security.Authorization;
using Tutor.Infrastructure.Security.Authorization.JWT;
using Tutor.Web.Controllers.Learners.DTOs;

namespace Tutor.Web.Controllers.Learners
{
    [Route("api/learners/")]
    [ApiController]
    public class LearnerController : ControllerBase
    {
        private readonly IAuthService _authService;

        public LearnerController(IAuthService authService)
        {
            _authService = authService;
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
    }
}