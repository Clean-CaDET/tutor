using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Stakeholders.API.Dtos;
using Tutor.Stakeholders.API.Interfaces;
using Tutor.Stakeholders.Core.Domain;
using Tutor.Stakeholders.Core.Domain.RepositoryInterfaces;

namespace Tutor.Stakeholders.Infrastructure.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly JwtGenerator _tokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IUserRepository userRepository)
    {
        _tokenGenerator = new JwtGenerator();
        _userRepository = userRepository;
    }

    public Result<AuthenticationTokensDto> Login(CredentialsDto credentials)
    {
        var user = _userRepository.GetActiveByName(credentials.Username);
        if (user == null || IsPasswordIncorrect(user, credentials.Password))
            return Result.Fail(FailureCode.NotFound);
            
        return _tokenGenerator.GenerateAccessToken(user.Id, user.Username, user.GetPrimaryRoleName(), AppendDomainDataToJwt(user));
    }

    private static bool IsPasswordIncorrect(User user, string password)
    {
        return !user.Password.Equals(PasswordUtilities.HashPassword(password, Convert.FromBase64String(user.Salt)));
    }

    public Result<AuthenticationTokensDto> RefreshToken(AuthenticationTokensDto authenticationTokens)
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