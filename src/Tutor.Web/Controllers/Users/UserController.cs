using Microsoft.AspNetCore.Mvc;
using Tutor.Infrastructure.Security.Authentication;

namespace Tutor.Web.Controllers.Users;

[Route("api/users")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IAuthService _authService;

    public UserController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public ActionResult<AuthenticationTokens> Login([FromBody] CredentialsDto credentials)
    {
        var result = _authService.Login(credentials.Username, credentials.Password);
        if (result.IsSuccess) return Ok(result.Value);
        return NotFound(result.Errors);
    }

    [HttpPost("refresh")]
    public ActionResult<AuthenticationTokens> RefreshToken([FromBody] AuthenticationTokens authenticationTokens)
    {
        var result = _authService.RefreshToken(authenticationTokens);
        if (result.IsSuccess) return Ok(result.Value);
        return BadRequest(result.Errors);
    }
}