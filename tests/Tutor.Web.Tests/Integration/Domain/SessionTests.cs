using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;
using Tutor.Core.DomainModel.KnowledgeComponents;
using Tutor.Web.Controllers.Domain;
using Xunit;
using Shouldly;

namespace Tutor.Web.Tests.Integration.Domain
{
    [Collection("Sequential")]
    public class SessionTests : BaseIntegrationTest
    {
        public SessionTests(TutorApplicationTestFactory<Startup> factory) : base(factory) { }

        [Fact]
        public void Launches_and_terminates_session()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            var launchResult = controller.LaunchSession(-15);
            var terminationResult = controller.TerminateSession(-15);

            launchResult.ShouldBeOfType<OkResult>();
            terminationResult.ShouldBeOfType<OkResult>();
        }

        [Fact]
        public void Termination_fails_without_active_session()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            var terminationResult = controller.TerminateSession(-15);

            terminationResult.ShouldBeOfType<BadRequestObjectResult>();
        }

        private KcController SetupController(IServiceScope scope)
        {
            return new KcController(Factory.Services.GetRequiredService<IMapper>(),
                scope.ServiceProvider.GetRequiredService<IKcService>())
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = new DefaultHttpContext()
                    {
                        User = new ClaimsPrincipal(new ClaimsIdentity(new[]
                        {
                            new Claim("id", "-2")
                        }))
                    }
                }
            };
        }
    }
}
