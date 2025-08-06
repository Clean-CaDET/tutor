﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FluentResults;
using Microsoft.IdentityModel.Tokens;
using Tutor.BuildingBlocks.Infrastructure.Security;
using Tutor.Stakeholders.API.Dtos;

namespace Tutor.Stakeholders.Infrastructure.Authentication;

public class JwtGenerator
{
    private readonly string _key = EnvironmentConnection.GetSecret("JWT_KEY") ?? "tutor_secret_key_32_chars_minimum_for_hmac_sha256_security";   
    private readonly string _issuer = EnvironmentConnection.GetSecret("JWT_ISSUER") ?? "tutor";
    private readonly string _audience = EnvironmentConnection.GetSecret("JWT_AUDIENCE") ?? "tutor-front.com";

    public Result<AuthenticationTokensDto> GenerateAccessToken(int userId, string username, string role, int id)
    {
        var authenticationResponse = new AuthenticationTokensDto();

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new("id", userId.ToString()),
            new("username", username),
            new(role + "Id", id.ToString()),
            new(ClaimTypes.Role, role)
        };
            
        var jwt = CreateToken(claims, 120);
        authenticationResponse.Id = userId;
        authenticationResponse.AccessToken = jwt;
        authenticationResponse.RefreshToken = GenerateRefreshToken();
            
        return authenticationResponse;
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
        return CreateToken(new List<Claim>(), 4320);
    }

    public Result<AuthenticationTokensDto> RefreshToken(AuthenticationTokensDto authenticationTokens)
    {
        var token = new JwtSecurityTokenHandler().ReadJwtToken(authenticationTokens.AccessToken);
        var userId = int.Parse(token.Claims.First(c => c.Type == "id").Value);
        var username = token.Claims.First(c => c.Type == "username").Value;

        var id = int.Parse(token.Claims.FirstOrDefault(c => c.Type.StartsWith("learner"))?.Value ?? 
                           token.Claims.FirstOrDefault(c => c.Type == "instructorId")?.Value ?? token.Claims.First(c => c.Type == "administratorId").Value );
        
        var role = token.Claims.First(c => c.Type.Equals(ClaimTypes.Role)).Value;
        return ValidateRefreshToken(authenticationTokens.RefreshToken) ? GenerateAccessToken(userId, username, role, id) : Result.Fail("Refresh token is not valid.");
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