namespace Tutor.Infrastructure.Security.Authorization.JWT
{
    public class UserCredentials
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}