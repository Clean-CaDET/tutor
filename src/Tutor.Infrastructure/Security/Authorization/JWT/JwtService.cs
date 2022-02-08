using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using FluentResults;
using Microsoft.IdentityModel.Tokens;

namespace Tutor.Infrastructure.Security.Authorization.JWT
{
    public class JwtService : IJwtService
    {
        private readonly IRefreshTokenValidator _refreshTokenValidator;
        private readonly string _key = EnvironmentConnection.GetSecret("JWT_KEY") ?? "tutor_secret_key";   
        private readonly string _issuer = EnvironmentConnection.GetSecret("JWT_ISSUER") ?? "tutor_secret_key";
        private readonly string _audience = EnvironmentConnection.GetSecret("JWT_AUDIENCE") ?? "tutor-front.com";

        public JwtService(IRefreshTokenValidator refreshTokenValidator)
        {
            _refreshTokenValidator = refreshTokenValidator;
        }

        public Result<AuthenticationResponse> GenerateAccessToken(int userId, string role)
        {
            var loginResponseDto = new AuthenticationResponse();

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new("id", userId.ToString()),
                new(ClaimTypes.Role, role)
            };
            
            var jwt = CreateToken(claims, 1);
            loginResponseDto.Id = userId;
            loginResponseDto.AccessToken = jwt;
            loginResponseDto.RefreshToken = GenerateRefreshToken();
            
            return Result.Ok(loginResponseDto);
        }
        
        private string GenerateRefreshToken()
        {
            return CreateToken(new List<Claim>(), 1440);
        }

        public Result<AuthenticationResponse> RefreshToken(UserCredentials userCredentials)
        {
            var token = new JwtSecurityTokenHandler().ReadJwtToken(userCredentials.AccessToken);
            var userId = int.Parse(token.Claims.First(c => c.Type == "id").Value);
            var role = token.Claims.First(c => c.Type.Equals(ClaimTypes.Role)).Value;
            return _refreshTokenValidator.Validate(userCredentials.RefreshToken) ? GenerateAccessToken(userId, role) : Result.Fail("Refresh token is not valid!");
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
    }
}