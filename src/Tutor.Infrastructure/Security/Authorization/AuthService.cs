using System;
using FluentResults;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
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
            return learner.Password.Equals(HashPassword(password, Convert.FromBase64String(learner.Salt)))
                ? _jwtService.GenerateAccessToken(learner.Id, "learner") // TODO: Make this more generic.
                : Result.Fail("The username or password is incorrect!");
        }

        public Result<AuthenticationResponse> Register(Learner learner)
        {
            var salt = new byte[128 / 8];
            var hashedPassword = HashPassword(learner.Password, salt);
            learner.Salt = Convert.ToBase64String(salt);
            learner.Password = hashedPassword;
            var result = _learnerService.Register(learner);
            return _jwtService.GenerateAccessToken(result.Value.Id, "learner"); // TODO: Make this more generic.
        }

        public Result<AuthenticationResponse> RefreshToken(UserCredentials userCredentials)
        {
            return _jwtService.RefreshToken(userCredentials);
        }

        private static string HashPassword(string password, byte[] salt)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password,
                salt,
                KeyDerivationPrf.HMACSHA256,
                100000,
                256 / 8));
        }
    }
}