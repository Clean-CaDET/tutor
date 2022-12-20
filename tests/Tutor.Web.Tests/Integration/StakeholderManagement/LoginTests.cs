using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.Infrastructure.Security.Authentication;
using Tutor.Web.Controllers.Users;
using Xunit;

namespace Tutor.Web.Tests.Integration.StakeholderManagement;

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
}