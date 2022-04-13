using FluentResults;
using System;
using Tutor.Core.LearnerModel;

namespace Tutor.Infrastructure.Security.Authorization
{
    public class AuthService : IAuthService
    {
        private readonly ITokenService _tokenService;
        private readonly ILearnerRepository _learnerRepository;

        public AuthService(ITokenService tokenService, ILearnerRepository learnerRepository)
        {
            _tokenService = tokenService;
            _learnerRepository = learnerRepository;
        }

        public Result<AuthenticationResponse> Login(string studentIndex, string password)
        {
            var learner = _learnerRepository.GetByIndex(studentIndex);
            if (learner == null) return Result.Fail("User does not exist!");
            return learner.Password.Equals(PasswordUtilities.HashPassword(password, Convert.FromBase64String(learner.Salt)))
                ? _tokenService.GenerateAccessToken(learner.Id, "learner")
                : Result.Fail("The username or password is incorrect!");
        }

        public Result<AuthenticationResponse> RefreshToken(AuthenticationTokens authenticationTokens)
        {
            return _tokenService.RefreshToken(authenticationTokens);
        }
    }
}