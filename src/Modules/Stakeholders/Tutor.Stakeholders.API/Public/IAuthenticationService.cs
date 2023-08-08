using FluentResults;
using Tutor.Stakeholders.API.Dtos;

namespace Tutor.Stakeholders.API.Public;

public interface IAuthenticationService
{
    Result<AuthenticationTokensDto> Login(CredentialsDto credentials);
    Result<AuthenticationTokensDto> RefreshToken(AuthenticationTokensDto authenticationTokens);
}