using FluentResults;
using Tutor.Core.LearnerModel.Learners;

namespace Tutor.Infrastructure.Security.Authorization
{
    public interface IAuthService
    {
        Result<AuthenticationResponse> Login(string studentIndex, string password);

        Result<AuthenticationResponse> Register(Learner learner);

        Result<AuthenticationResponse> RefreshToken(AuthenticationTokens authenticationTokens);
    }
}