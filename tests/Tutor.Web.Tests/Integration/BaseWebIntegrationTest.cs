using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Xunit;

namespace Tutor.Web.Tests.Integration;

public class BaseWebIntegrationTest : IClassFixture<TutorApplicationTestFactory<Startup>>
{
    protected TutorApplicationTestFactory<Startup> Factory { get; }

    public BaseWebIntegrationTest(TutorApplicationTestFactory<Startup> factory)
    {
        Factory = factory;
    }

    protected static ControllerContext BuildContext(string id, string role)
    {
        return new ControllerContext()
        {
            HttpContext = new DefaultHttpContext()
            {
                User = new ClaimsPrincipal(new ClaimsIdentity(new[]
                {
                    new Claim("id", id),
                    new Claim(role + "Id", id),
                }))
            }
        };
    }
}