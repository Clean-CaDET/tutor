using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;
using Tutor.Infrastructure.Database.EventStore;
using Tutor.Web.Controllers.Instructors;
using Tutor.Web.Controllers.Learners;
using Tutor.Web.Controllers.Learners.DomainOverlay;
using Xunit;
using Tutor.Core.Domain.Knowledge.KnowledgeComponents;
using Tutor.Core.UseCases.Learning;
using Tutor.Core.Domain.Stakeholders;
using Tutor.Core.UseCases.Learning.Assessment;
using Tutor.Core.UseCases.Learning.Statistics;

namespace Tutor.Web.Tests.Integration
{
    public class BaseWebIntegrationTest : IClassFixture<TutorApplicationTestFactory<Startup>>
    {
        protected TutorApplicationTestFactory<Startup> Factory { get; }

        public BaseWebIntegrationTest(TutorApplicationTestFactory<Startup> factory)
        {
            Factory = factory;
        }

        protected KcMasteryController SetupKcmController(IServiceScope scope, string id)
        {
            return new KcMasteryController(Factory.Services.GetRequiredService<IMapper>(),
                scope.ServiceProvider.GetRequiredService<IKcMasteryService>(),
                scope.ServiceProvider.GetRequiredService<IStatisticsService>(),
                scope.ServiceProvider.GetRequiredService<ISelectionService>())
            {
                ControllerContext = BuildContext(id, "learner")
            };
        }

        protected InstructorController SetupInstructorController(IServiceScope scope, string id)
        {
            return new InstructorController(Factory.Services.GetRequiredService<IMapper>(),
                scope.ServiceProvider.GetRequiredService<IEnrollmentService>())
            {
                ControllerContext = BuildContext(id, "instructor")
            };
        }
        
        protected LearnerController SetupLearnerController(IServiceScope scope, string id)
        {
            return new LearnerController(scope.ServiceProvider.GetRequiredService<ILearnerService>(),
                Factory.Services.GetRequiredService<IMapper>(),
                scope.ServiceProvider.GetRequiredService<ICourseRepository>(),
                scope.ServiceProvider.GetRequiredService<IKnowledgeUnitRepository>())
            {
                ControllerContext = BuildContext(id, "learner")
            };
        }

        protected CourseController SetupCourseController(IServiceScope scope, string id)
        {
            return new CourseController(scope.ServiceProvider.GetRequiredService<ICourseRepository>(),
                Factory.Services.GetRequiredService<IMapper>())
            {
                ControllerContext = BuildContext(id, "instructor")
            };
        }
        
        protected UnitController SetupUnitController(IServiceScope scope, string id)
        {
            return new UnitController(scope.ServiceProvider.GetRequiredService<IKnowledgeUnitRepository>(),
                Factory.Services.GetRequiredService<IMapper>())
            {
                ControllerContext = BuildContext(id, "instructor")
            };
        }

        protected AssessmentEvaluationController SetupAssessmentEvaluationController(IServiceScope scope, string id)
        {
            return new AssessmentEvaluationController(Factory.Services.GetRequiredService<IMapper>(),
                scope.ServiceProvider.GetRequiredService<IEvaluationService>(),
                scope.ServiceProvider.GetRequiredService<IHelpService>(),
                scope.ServiceProvider.GetRequiredService<IStatisticsService>())
            {
                ControllerContext = BuildContext(id, "learner")
            };
        }

        protected AnalyticsController CreateAnalyticsController(IServiceScope scope, string id)
        {
            return new AnalyticsController(
                scope.ServiceProvider.GetRequiredService<ILearnerRepository>(),
                scope.ServiceProvider.GetRequiredService<IKnowledgeUnitRepository>(),
                scope.ServiceProvider.GetRequiredService<IEventStore>(),
                Factory.Services.GetRequiredService<IMapper>())
            {
                ControllerContext = BuildContext(id, "instructor")
            };
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
}
