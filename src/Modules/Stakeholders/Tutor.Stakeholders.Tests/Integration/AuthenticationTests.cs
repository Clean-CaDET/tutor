using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Tutor.API.Controllers;
using Tutor.API.Controllers.Administrator.Stakeholders;
using Tutor.Stakeholders.API.Dtos;
using Tutor.Stakeholders.API.Public;
using Tutor.Stakeholders.API.Public.Management;
using Tutor.Stakeholders.Infrastructure.Database;

namespace Tutor.Stakeholders.Tests.Integration;

[Collection("Sequential")]
public class AuthenticationTests : BaseStakeholdersIntegrationTest
{
    public AuthenticationTests(StakeholdersTestFactory factory) : base(factory) { }

    [Fact]
    public void Successfully_login()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var loginSubmission = new CredentialsDto { Username = "SU-1-2021", Password = "123" };

        var authenticationResponse = ((OkObjectResult)controller.Login(loginSubmission).Result).Value as AuthenticationTokensDto;

        authenticationResponse.Id.ShouldBe(-1);

        var tokenHandler = new JwtSecurityTokenHandler();
        var decodedAccessToken = tokenHandler.ReadJwtToken(authenticationResponse.AccessToken);
        var learnerIdClaim = decodedAccessToken.Claims.FirstOrDefault(c => c.Type == "learnerId");
        learnerIdClaim.ShouldNotBeNull();
        learnerIdClaim.Value.ShouldBe("-1");
        var learnerCommercialIdClaim = decodedAccessToken.Claims.FirstOrDefault(c => c.Type == "learnercommercialId");
        learnerCommercialIdClaim.ShouldBeNull();
    }

    [Fact]
    public void Successfully_login_commercial_learner()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var loginSubmission = new CredentialsDto { Username = "email@email.com", Password = "123" };

        var authenticationResponse = ((OkObjectResult)controller.Login(loginSubmission).Result).Value as AuthenticationTokensDto;

        authenticationResponse.Id.ShouldBe(-53);

        var tokenHandler = new JwtSecurityTokenHandler();
        var decodedAccessToken = tokenHandler.ReadJwtToken(authenticationResponse.AccessToken);
        var learnerCommercialIdClaim = decodedAccessToken.Claims.FirstOrDefault(c => c.Type == "learnercommercialId");
        learnerCommercialIdClaim.ShouldNotBeNull();
        learnerCommercialIdClaim.Value.ShouldBe("-53");
        var learnerIdClaim = decodedAccessToken.Claims.FirstOrDefault(c => c.Type == "learnerId");
        learnerIdClaim.ShouldBeNull();
    }

    [Fact]
    public void Nonexisting_user_login()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var loginSubmission = new CredentialsDto { Username = "SA-1-2021", Password = "123" };

        var result = (ObjectResult)controller.Login(loginSubmission).Result;

        result.StatusCode.ShouldBe(404);
    }

    [Fact]
    public void Successfully_refresh_token()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var loginSubmission = new CredentialsDto { Username = "SU-1-2021", Password = "123" };
        var authenticationResponse = ((OkObjectResult)controller.Login(loginSubmission).Result).Value as AuthenticationTokensDto;

        var result = (OkObjectResult)controller.RefreshToken(authenticationResponse).Result;
        result.StatusCode.ShouldBe(200);
        var refreshResponse = result.Value as AuthenticationTokensDto;
        refreshResponse.Id.ShouldBe(-1);

        var tokenHandler = new JwtSecurityTokenHandler();
        var decodedAccessToken = tokenHandler.ReadJwtToken(authenticationResponse.AccessToken);
        var learnerIdClaim = decodedAccessToken.Claims.FirstOrDefault(c => c.Type == "learnerId");
        learnerIdClaim.ShouldNotBeNull();
        learnerIdClaim.Value.ShouldBe("-1");
        var learnerCommercialIdClaim = decodedAccessToken.Claims.FirstOrDefault(c => c.Type == "learnercommercialId");
        learnerCommercialIdClaim.ShouldBeNull();
    }

    [Fact]
    public void Successfully_change_password()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateControllerWithId(scope);
        var changePasswordDto = new ChangePasswordDto { CurrentPassword = "123", NewPassword = "newPassword123" };
        var dbContext = scope.ServiceProvider.GetRequiredService<StakeholdersContext>();

        var result = (OkResult)controller.ChangePassword(changePasswordDto);

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(200);
    }

    [Fact]
    public void Fails_change_password_with_wrong_current_password()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateControllerWithId(scope);
        var changePasswordDto = new ChangePasswordDto { CurrentPassword = "wrongPassword", NewPassword = "newPassword123" };

        var result = (ObjectResult)controller.ChangePassword(changePasswordDto);

        result.StatusCode.ShouldBe(400);
    }

    private static AuthenticationController CreateController(IServiceScope scope)
    {
        return new AuthenticationController(scope.ServiceProvider.GetRequiredService<IAuthenticationService>());
    }

    private static AuthenticationController CreateControllerWithId(IServiceScope scope)
    {
        return new AuthenticationController(scope.ServiceProvider.GetRequiredService<IAuthenticationService>())
        {
            ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext()
                {
                    User = new ClaimsPrincipal(new ClaimsIdentity(new[]
                    {
                        new Claim("id", "-1")
                    }))
                }
            }
        };
    }
}