using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutor.Stakeholders.API.Dtos;
using Tutor.Stakeholders.API.Public;
using Tutor.Stakeholders.Infrastructure.Authentication;

namespace Tutor.API.Controllers;

[Route("api/users")]
public class AuthenticationController : BaseApiController
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("login")]
    public ActionResult<AuthenticationTokensDto> Login([FromBody] CredentialsDto credentials)
    {
        var result = _authenticationService.Login(credentials);
        return CreateResponse(result);
    }

    [HttpPost("refresh")]
    public ActionResult<AuthenticationTokensDto> RefreshToken([FromBody] AuthenticationTokensDto authenticationTokens)
    {
        var result = _authenticationService.RefreshToken(authenticationTokens);
        if (result.IsFailed) return BadRequest(result.Errors);
        return Ok(result.Value);
    }

    [Authorize]
    [HttpPost("change-password")]
    public ActionResult ChangePassword([FromBody] ChangePasswordDto changePasswordDto)
    {
        var result = _authenticationService.ChangePassword(User.UserId(), changePasswordDto);
        return CreateResponse(result);
    }
}