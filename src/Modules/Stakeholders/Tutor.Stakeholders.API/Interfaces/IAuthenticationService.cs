using FluentResults;
using Tutor.Stakeholders.API.Dtos;

namespace Tutor.Stakeholders.API.Interfaces;

public interface IAuthenticationService
{
    Result<AuthenticationTokensDto> Login(CredentialsDto credentials);
    Result<AuthenticationTokensDto> RefreshToken(AuthenticationTokensDto authenticationTokensDto);
}