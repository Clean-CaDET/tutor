using FluentResults;
using Tutor.Core.LearnerModel.Learners;
using Tutor.Infrastructure.Security.Authorization.JWT;

namespace Tutor.Infrastructure.Security.Authorization
{
    public interface IAuthService
    {
        Result<AuthenticationResponse> Login(string studentIndex, string password);

        Result<AuthenticationResponse> Register(Learner learner);

        Result<AuthenticationResponse> RefreshToken(AuthenticationTokens authenticationTokens);
    }
}