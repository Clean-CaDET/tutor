using FluentResults;
using System;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.Stakeholders;
using Tutor.Core.Domain.Stakeholders.RepositoryInterfaces;
using Tutor.Infrastructure.Security.Authentication.Users;

namespace Tutor.Infrastructure.Security.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly JwtGenerator _tokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IUserRepository userRepository)
    {
        _tokenGenerator = new JwtGenerator();
        _userRepository = userRepository;
    }

    public Result<AuthenticationTokens> Login(string username, string password)
    {
        var user = _userRepository.GetActiveByName(username);
        if (user == null || IsPasswordIncorrect(user, password))
            return Result.Fail(FailureCode.NotFound);
            
        return _tokenGenerator.GenerateAccessToken(user.Id, username, user.GetPrimaryRoleName(), AppendDomainDataToJwt(user));
    }

    private static bool IsPasswordIncorrect(User user, string password)
    {
        return !user.Password.Equals(PasswordUtilities.HashPassword(password, Convert.FromBase64String(user.Salt)));
    }

    public Result<AuthenticationTokens> RefreshToken(AuthenticationTokens authenticationTokens)
    {
        return _tokenGenerator.RefreshToken(authenticationTokens);
    }

    private int AppendDomainDataToJwt(User user)
    {
        var id = 0;
        if (user.GetPrimaryRoleName().StartsWith("learner"))
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