
using FluentResults;
using Tutor.Web.Controllers.JWT.DTOs;
using Tutor.Web.Controllers.Learners.DTOs;

namespace Tutor.Web.Controllers.JWT
{
    public interface IJwtService
    {
        Result<LoginResponseDto> GenerateToken(LoginDto login);
    }
}