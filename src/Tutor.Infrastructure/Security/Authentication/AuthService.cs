using FluentResults;
using Tutor.Core.InstructorModel;
using Tutor.Core.LearnerModel;
using Tutor.Infrastructure.Security.Authentication.Users;

namespace Tutor.Infrastructure.Security.Authentication
{
    public class AuthService : IAuthService
    {
        private readonly JwtGenerator _tokenGenerator;
        private readonly IUserRepository _userRepository;
        private readonly ILearnerRepository _learnerRepository;
        private readonly IInstructorRepository _instructorRepository;

        public AuthService(IUserRepository userRepository, ILearnerRepository learnerRepository,
            IInstructorRepository instructorRepository)
        {
            _tokenGenerator = new JwtGenerator();
            _userRepository = userRepository;
            _learnerRepository = learnerRepository;
            _instructorRepository = instructorRepository;
        }

        public Result<AuthenticationTokens> Login(string username, string password)
        {
            var user = _userRepository.GetByName(username);
            if (user == null || user.IsPasswordIncorrect(password))
                return Result.Fail("The username or password is incorrect.");
            
            return _tokenGenerator.GenerateAccessToken(user.Id, user.GetPrimaryRoleName(), AppendDomainDataToJwt(user));
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
                id = _learnerRepository.GetByUserId(user.Id).Id;
            }
            else if (user.GetPrimaryRoleName().Equals("instructor"))
            {
                id = _instructorRepository.GetByUserId(user.Id).Id;
            }
            return id;
        }
    }
}