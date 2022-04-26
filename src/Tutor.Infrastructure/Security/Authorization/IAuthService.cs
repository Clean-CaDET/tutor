using FluentResults;

namespace Tutor.Infrastructure.Security.Authorization
{
    public interface IAuthService
    {
        Result<AuthenticationResponse> Login(string studentIndex, string password);
        Result<AuthenticationResponse> RefreshToken(AuthenticationTokens authenticationTokens);
    }
}