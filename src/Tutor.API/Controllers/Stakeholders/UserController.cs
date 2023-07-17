using Microsoft.AspNetCore.Mvc;
using Tutor.Stakeholders.API.Dtos;
using Tutor.Stakeholders.API.Interfaces;

namespace Tutor.API.Controllers.Stakeholders;

[Route("api/users")]
public class UserController : BaseApiController
{
    private readonly IAuthenticationService _authenticationService;

    public UserController(IAuthenticationService authenticationService)
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
}