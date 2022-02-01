using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Tutor.Core.LearnerModel;
using Tutor.Web.Controllers.JWT.DTOs;
using Tutor.Web.Controllers.Learners.DTOs;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Tutor.Web.Controllers.JWT
{
    public class JwtService : IJwtService
    {
        
        private readonly ILearnerService _learnerService;
        
        public JwtService(ILearnerService learnerService)
        {
            _learnerService = learnerService;
        }
        
        public Result<LoginResponseDto> GenerateToken(LoginDto login)
        {
            var result = _learnerService.Login(login.StudentIndex);
            if(!result.IsSuccess) return Result.Fail("No such learner.");
            
            var loginResponseDto = new LoginResponseDto();
            const string key = "tutor_secret_key"; // We need to store this properly for prod. This is just example.    
            const string issuer = "tutor.com";
            const string audience = "tutor-front.com";

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new("studentIndex", result.Value.StudentIndex),
                new("id", result.Value.Id.ToString())
            };

            var token = new JwtSecurityToken(
                issuer,  
                audience, 
                claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            loginResponseDto.AccessToken = jwt;
            loginResponseDto.StudentIndex = result.Value.StudentIndex;
            
            return Result.Ok(loginResponseDto);
        }
    }
}