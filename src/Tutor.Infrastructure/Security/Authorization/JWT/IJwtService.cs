using FluentResults;

namespace Tutor.Infrastructure.Security.Authorization.JWT
{
    public interface IJwtService
    {
        Result<AuthenticationResponse> GenerateAccessToken(int userId, string role);

        Result<AuthenticationResponse> RefreshToken(UserCredentials userCredentials);
    }
}