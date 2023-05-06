using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Tutor.Infrastructure.Security.Authentication;
using Tutor.Web.Controllers.Users;
using Xunit;

namespace Tutor.Web.Tests.Integration.Management.Stakeholders;

[Collection("Sequential")]
public class LoginTests : BaseWebIntegrationTest
{
    public LoginTests(TutorApplicationTestFactory<Startup> factory) : base(factory) { }

    [Fact]
    public void Successfully_login()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = new UserController(scope.ServiceProvider.GetRequiredService<IAuthenticationService>());
        var loginSubmission = new CredentialsDto { Username = "SU-1-2021", Password = "123" };

        var authenticationResponse = ((OkObjectResult)controller.Login(loginSubmission).Result)?.Value as AuthenticationTokens;

        authenticationResponse.Id.ShouldBe(-1);

        var tokenHandler = new JwtSecurityTokenHandler();
        var decodedAccessToken = tokenHandler.ReadJwtToken(authenticationResponse.AccessToken);
        var learnerIdClaim = decodedAccessToken.Claims.FirstOrDefault(c => c.Type == "learnerId");
        learnerIdClaim.ShouldNotBeNull();
        learnerIdClaim.Value.ShouldBe("-1");
        var learnerCommercialIdClaim = decodedAccessToken.Claims.FirstOrDefault(c => c.Type == "learnerftninfId");
        learnerCommercialIdClaim.ShouldBeNull();
    }

    [Fact]
    public void Successfully_login_commercial_learner()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = new UserController(scope.ServiceProvider.GetRequiredService<IAuthenticationService>());
        var loginSubmission = new CredentialsDto { Username = "email@email.com", Password = "123" };

        var authenticationResponse = ((OkObjectResult)controller.Login(loginSubmission).Result)?.Value as AuthenticationTokens;

        authenticationResponse.Id.ShouldBe(-53);

        var tokenHandler = new JwtSecurityTokenHandler();
        var decodedAccessToken = tokenHandler.ReadJwtToken(authenticationResponse.AccessToken);
        var learnerCommercialIdClaim = decodedAccessToken.Claims.FirstOrDefault(c => c.Type == "learnerftninfId");
        learnerCommercialIdClaim.ShouldNotBeNull();
        learnerCommercialIdClaim.Value.ShouldBe("-53");
        var learnerIdClaim = decodedAccessToken.Claims.FirstOrDefault(c => c.Type == "learnerId");
        learnerIdClaim.ShouldBeNull();
    }

    [Fact]
    public void Nonexisting_user_login()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = new UserController(scope.ServiceProvider.GetRequiredService<IAuthenticationService>());
        var loginSubmission = new CredentialsDto { Username = "SA-1-2021", Password = "123" };

        var result = (ObjectResult)controller.Login(loginSubmission).Result;

        result.StatusCode.ShouldBe(404);
    }

    [Fact]
    public void Successfully_refresh_token()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = new UserController(scope.ServiceProvider.GetRequiredService<IAuthenticationService>());
        var loginSubmission = new CredentialsDto { Username = "SU-1-2021", Password = "123" };
        var authenticationResponse = ((OkObjectResult)controller.Login(loginSubmission).Result)?.Value as AuthenticationTokens;
        
        var result = (OkObjectResult)controller.RefreshToken(authenticationResponse).Result;
        result.StatusCode.ShouldBe(200);
        var refreshResponse = result.Value as AuthenticationTokens;
        refreshResponse.Id.ShouldBe(-1);

        var tokenHandler = new JwtSecurityTokenHandler();
        var decodedAccessToken = tokenHandler.ReadJwtToken(authenticationResponse.AccessToken);
        var learnerIdClaim = decodedAccessToken.Claims.FirstOrDefault(c => c.Type == "learnerId");
        learnerIdClaim.ShouldNotBeNull();
        learnerIdClaim.Value.ShouldBe("-1");
        var learnerCommercialIdClaim = decodedAccessToken.Claims.FirstOrDefault(c => c.Type == "learnerftninfId");
        learnerCommercialIdClaim.ShouldBeNull();
    }

}