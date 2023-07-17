using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tutor.API;

namespace Tutor.Stakeholders.Tests;

public class BaseWebIntegrationTest : IClassFixture<StakeholdersTestFactory<Program>>
{
    protected StakeholdersTestFactory<Program> Factory { get; }

    public BaseWebIntegrationTest(StakeholdersTestFactory<Program> factory)
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
                    new Claim(role + "Id", id)
                }))
            }
        };
    }
}