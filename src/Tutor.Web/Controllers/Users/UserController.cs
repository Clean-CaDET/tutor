using Microsoft.AspNetCore.Mvc;
using Tutor.Infrastructure.Security.Authentication;

namespace Tutor.Web.Controllers.Users;

[Route("api/users")]
public class UserController : BaseApiController
{
    private readonly IAuthenticationService _authenticationService;

    public UserController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("login")]
    public ActionResult<AuthenticationTokens> Login([FromBody] CredentialsDto credentials)
    {
        var result = _authenticationService.Login(credentials.Username, credentials.Password);
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        return Ok(result.Value);
    }

    [HttpPost("refresh")]
    public ActionResult<AuthenticationTokens> RefreshToken([FromBody] AuthenticationTokens authenticationTokens)
    {
        var result = _authenticationService.RefreshToken(authenticationTokens);
        if (result.IsFailed) return BadRequest(result.Errors);
        return Ok(result.Value);
    }
}