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
        return CreateResponse(result, Ok, CreateErrorResponse);
    }

    [HttpPost("refresh")]
    public ActionResult<AuthenticationTokens> RefreshToken([FromBody] AuthenticationTokens authenticationTokens)
    {
        var result = _authenticationService.RefreshToken(authenticationTokens);
        return CreateResponse(result, Ok, BadRequest);
    }
}