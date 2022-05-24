using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;
using Tutor.Core.DomainModel;
using Tutor.Core.LearnerModel;
using Tutor.Core.LearnerModel.DomainOverlay;
using Tutor.Infrastructure.Database.EventStore;
using Tutor.Web.Controllers.Analytics;
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

        protected LearnerAssessmentController SetupAssessmentsController(IServiceScope scope, string userAndLearnerId)
        {
            return new LearnerAssessmentController(Factory.Services.GetRequiredService<IMapper>(),
                scope.ServiceProvider.GetRequiredService<ILearnerAssessmentService>())
            {
                ControllerContext = BuildContext(userAndLearnerId)
            };
        }

        protected AnalyticsController CreateAnalyticsController(IServiceScope scope, string userId)
        {
            return new AnalyticsController(
                scope.ServiceProvider.GetRequiredService<ILearnerRepository>(),
                scope.ServiceProvider.GetRequiredService<IDomainRepository>(),
                scope.ServiceProvider.GetRequiredService<IEventStore>(),
                Factory.Services.GetRequiredService<IMapper>())
            {
                ControllerContext = BuildContext(userId)
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
