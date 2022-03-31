using FluentResults;
using System;
using Tutor.Core.LearnerModel;
using Tutor.Core.LearnerModel.Learners;

namespace Tutor.Infrastructure.Security.Authorization
{
    public class AuthService : IAuthService
    {
        private readonly ILearnerService _learnerService;
        private readonly ITokenService _tokenService;
        private readonly ILearnerRepository _learnerRepository;

        public AuthService(ILearnerService learnerService, ITokenService tokenService, ILearnerRepository learnerRepository)
        {
            _learnerService = learnerService;
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

        public Result<AuthenticationResponse> Register(Learner learner)
        {
            var salt = PasswordUtilities.GenerateSalt();
            var hashedPassword = PasswordUtilities.HashPassword(learner.Password, salt);
            learner.Salt = Convert.ToBase64String(salt);
            learner.Password = hashedPassword;
            var result = _learnerService.Register(learner);
            return _tokenService.GenerateAccessToken(result.Value.Id, "learner");
        }

        public Result<AuthenticationResponse> RefreshToken(AuthenticationTokens authenticationTokens)
        {
            return _tokenService.RefreshToken(authenticationTokens);
        }
    }
}