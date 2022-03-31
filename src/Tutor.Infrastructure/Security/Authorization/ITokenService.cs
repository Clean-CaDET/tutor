using FluentResults;

namespace Tutor.Infrastructure.Security.Authorization
{
    public interface ITokenService
    {
        Result<AuthenticationResponse> GenerateAccessToken(int userId, string role);

        Result<AuthenticationResponse> RefreshToken(AuthenticationTokens authenticationTokens);
    }
}