namespace Tutor.Infrastructure.Security.Authentication
{
    public class AuthenticationTokens
    {
        public int Id { get; set; }

        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }
    }
}