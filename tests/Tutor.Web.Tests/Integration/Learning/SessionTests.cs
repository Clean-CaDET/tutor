using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.Core.UseCases.Learning;
using Tutor.Web.Controllers.Learners.Learning;
using Xunit;

namespace Tutor.Web.Tests.Integration.Learning
{
    [Collection("Sequential")]
    public class SessionTests : BaseWebIntegrationTest
    {
        public SessionTests(TutorApplicationTestFactory<Startup> factory) : base(factory) { }

        [Fact]
        public void Launches_and_terminates_session()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupSessionController(scope, "-2");

            var launchResult = controller.LaunchSession(-15);
            var terminationResult = controller.TerminateSession(-15);

            launchResult.ShouldBeOfType<OkResult>();
            terminationResult.ShouldBeOfType<OkResult>();
        }

        [Fact]
        public void Termination_fails_without_active_session()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupSessionController(scope, "-2");

            var terminationResult = (ObjectResult)controller.TerminateSession(-15);

            terminationResult.ShouldNotBeNull();
            terminationResult.StatusCode.ShouldBe(500);
        }

        private static SessionController SetupSessionController(IServiceScope scope, string id)
        {
            return new SessionController(scope.ServiceProvider.GetRequiredService<ISessionService>())
            {
                ControllerContext = BuildContext(id, "learner")
            };
        }
    }
}
