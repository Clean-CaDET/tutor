using FluentResults;
using System;
using Tutor.Core.LearnerModel;
using Tutor.Core.LearnerModel.Learners;
using Tutor.Infrastructure.Security.Authorization.JWT;

namespace Tutor.Infrastructure.Security.Authorization
{
    public class AuthService : IAuthService
    {
        private readonly ILearnerService _learnerService;
        private readonly IJwtService _jwtService;
        private readonly ILearnerRepository _learnerRepository;

        public AuthService(ILearnerService learnerService, IJwtService jwtService, ILearnerRepository learnerRepository)
        {
            _learnerService = learnerService;
            _jwtService = jwtService;
            _learnerRepository = learnerRepository;
        }

        public Result<AuthenticationResponse> Login(string studentIndex, string password)
        {
            var learner = _learnerRepository.GetByIndex(studentIndex);
            if (learner == null) return Result.Fail("User does not exist!");
            return learner.Password.Equals(PasswordUtilities.HashPassword(password, Convert.FromBase64String(learner.Salt)))
                ? _jwtService.GenerateAccessToken(learner.Id, "learner")
                : Result.Fail("The username or password is incorrect!");
        }

        public Result<AuthenticationResponse> Register(Learner learner)
        {
            var salt = PasswordUtilities.GenerateSalt();
            var hashedPassword = PasswordUtilities.HashPassword(learner.Password, salt);
            learner.Salt = Convert.ToBase64String(salt);
            learner.Password = hashedPassword;
            var result = _learnerService.Register(learner);
            return _jwtService.GenerateAccessToken(result.Value.Id, "learner");
        }

        public Result<AuthenticationResponse> RefreshToken(AuthenticationTokens authenticationTokens)
        {
            return _jwtService.RefreshToken(authenticationTokens);
        }
    }
}