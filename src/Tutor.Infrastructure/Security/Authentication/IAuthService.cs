using FluentResults;

namespace Tutor.Infrastructure.Security.Authentication;

public interface IAuthService
{
    Result<AuthenticationTokens> Login(string username, string password);
    Result<AuthenticationTokens> RefreshToken(AuthenticationTokens authenticationTokens);
}