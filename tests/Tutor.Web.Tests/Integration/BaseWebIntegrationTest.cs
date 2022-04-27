using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;
using Tutor.Core.LearnerModel.DomainOverlay;
using Tutor.Web.Controllers.Learners.DomainOverlay;
using Xunit;

namespace Tutor.Web.Tests.Integration
{
    public class BaseWebIntegrationTest : IClassFixture<TutorApplicationTestFactory<Startup>>
    {
        protected TutorApplicationTestFactory<Startup> Factory { get; }

        public BaseWebIntegrationTest(TutorApplicationTestFactory<Startup> factory)
        {
            Factory = factory;
        }

        protected KcMasteryController SetupKcmController(IServiceScope scope, string userAndLearnerId)
        {
            return new KcMasteryController(Factory.Services.GetRequiredService<IMapper>(),
                scope.ServiceProvider.GetRequiredService<IKcMasteryService>())
            {
                ControllerContext = BuildContext(userAndLearnerId)
            };
        }

        protected static ControllerContext BuildContext(string userAndLearnerId)
        {
            return new ControllerContext()
            {
                HttpContext = new DefaultHttpContext()
                {
                    User = new ClaimsPrincipal(new ClaimsIdentity(new[]
                    {
                        new Claim("id", userAndLearnerId),
                        new Claim("learnerId", userAndLearnerId),
                    }))
                }
            };
        }
    }
}
