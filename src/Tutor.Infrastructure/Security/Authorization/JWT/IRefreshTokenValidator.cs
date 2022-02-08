namespace Tutor.Infrastructure.Security.Authorization.JWT
{
    public interface IRefreshTokenValidator
    {
        bool Validate(string refreshToken);
    }
}