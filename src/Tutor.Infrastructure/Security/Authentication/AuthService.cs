using FluentResults;
using Tutor.Core.BuildingBlocks;
using Tutor.Infrastructure.Security.Authentication.Users;

namespace Tutor.Infrastructure.Security.Authentication;

public class AuthService : IAuthService
{
    private readonly JwtGenerator _tokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthService(IUserRepository userRepository)
    {
        _tokenGenerator = new JwtGenerator();
        _userRepository = userRepository;
    }

    public Result<AuthenticationTokens> Login(string username, string password)
    {
        var user = _userRepository.GetActiveByName(username);
        if (user == null || user.IsPasswordIncorrect(password))
            return Result.Fail(FailureCode.NotFound);
            
        return _tokenGenerator.GenerateAccessToken(user.Id, username, user.GetPrimaryRoleName(), AppendDomainDataToJwt(user));
    }

    public Result<AuthenticationTokens> RefreshToken(AuthenticationTokens authenticationTokens)
    {
        return _tokenGenerator.RefreshToken(authenticationTokens);
    }

    private int AppendDomainDataToJwt(User user)
    {
        var id = 0;
        if (user.GetPrimaryRoleName().Equals("learner"))
        {
            id = _userRepository.GetLearnerId(user.Id);
        }
        else if (user.GetPrimaryRoleName().Equals("instructor"))
        {
            id = _userRepository.GetInstructorId(user.Id);
        }
        return id;
    }
}