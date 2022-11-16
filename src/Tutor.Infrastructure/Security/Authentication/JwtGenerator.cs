using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using FluentResults;
using Microsoft.IdentityModel.Tokens;

namespace Tutor.Infrastructure.Security.Authentication
{
    public class JwtGenerator
    {
        private readonly string _key = EnvironmentConnection.GetSecret("JWT_KEY") ?? "tutor_secret_key";   
        private readonly string _issuer = EnvironmentConnection.GetSecret("JWT_ISSUER") ?? "tutor";
        private readonly string _audience = EnvironmentConnection.GetSecret("JWT_AUDIENCE") ?? "tutor-front.com";

        public Result<AuthenticationTokens> GenerateAccessToken(int userId, string role, int id)
        {
            var authenticationResponse = new AuthenticationTokens();

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new("id", userId.ToString()),
                new(role + "Id", id.ToString()),
                new(ClaimTypes.Role, role)
            };
            
            var jwt = CreateToken(claims, 60);
            authenticationResponse.Id = userId;
            authenticationResponse.AccessToken = jwt;
            authenticationResponse.RefreshToken = GenerateRefreshToken();
            
            return Result.Ok(authenticationResponse);
        }
        
        private string CreateToken(IEnumerable<Claim> claims, double expirationTime)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _issuer,
                _audience,
                claims,
                expires: DateTime.Now.AddMinutes(expirationTime),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private string GenerateRefreshToken()
        {
            return CreateToken(new List<Claim>(), 1440);
        }

        public Result<AuthenticationTokens> RefreshToken(AuthenticationTokens authenticationTokens)
        {
            var token = new JwtSecurityTokenHandler().ReadJwtToken(authenticationTokens.AccessToken);
            var userId = int.Parse(token.Claims.First(c => c.Type == "id").Value);
            
            var id = int.Parse(token.Claims.FirstOrDefault(c => c.Type == "learnerId")?.Value ?? 
                               token.Claims.First(c => c.Type == "instructorId").Value);
            
            var role = token.Claims.First(c => c.Type.Equals(ClaimTypes.Role)).Value;
            return ValidateRefreshToken(authenticationTokens.RefreshToken) ? GenerateAccessToken(userId, role, id) : Result.Fail("Refresh token is not valid!");
        }

        private bool ValidateRefreshToken(string refreshToken)
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