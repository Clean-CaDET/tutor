using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Tutor.Infrastructure.Security.Authorization.JWT
{
    public class RefreshTokenValidator : IRefreshTokenValidator
    {
        private readonly string _key = EnvironmentConnection.GetSecret("JWT_KEY") ?? "tutor_secret_key";   
        private readonly string _issuer = EnvironmentConnection.GetSecret("JWT_ISSUER") ?? "tutor";
        private readonly string _audience = EnvironmentConnection.GetSecret("JWT_AUDIENCE") ?? "tutor-front.com";
        
        public bool Validate(string refreshToken)
        {
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                ValidIssuer = _issuer,
                ValidAudience = _audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key))
            };

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new();
            try
            {
                jwtSecurityTokenHandler.ValidateToken(refreshToken, validationParameters, out _);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}