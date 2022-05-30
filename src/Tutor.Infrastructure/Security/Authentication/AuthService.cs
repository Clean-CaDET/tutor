using FluentResults;
using Tutor.Core.LearnerModel;

namespace Tutor.Infrastructure.Security.Authentication
{
    public class AuthService : IAuthService
    {
        private readonly JwtGenerator _tokenGenerator;
        private readonly IUserRepository _userRepository;
        private readonly ILearnerRepository _learnerRepository;

        public AuthService(IUserRepository userRepository, ILearnerRepository learnerRepository)
        {
            _tokenGenerator = new JwtGenerator();
            _userRepository = userRepository;
            _learnerRepository = learnerRepository;
        }

        public Result<AuthenticationTokens> Login(string username, string password)
        {
            var user = _userRepository.GetByName(username);
            if (user == null || user.IsPasswordIncorrect(password)) return Result.Fail("The username or password is incorrect.");

            var learnerId = user.GetPrimaryRoleName() == "learner" ? _learnerRepository.GetByUserId(user.Id).Id : 0;
            return _tokenGenerator.GenerateAccessToken(user.Id, user.GetPrimaryRoleName(), learnerId);
        }

        public Result<AuthenticationTokens> RefreshToken(AuthenticationTokens authenticationTokens)
        {
            return _tokenGenerator.RefreshToken(authenticationTokens);
        }
    }
}