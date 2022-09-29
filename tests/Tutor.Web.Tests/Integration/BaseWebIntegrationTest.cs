using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;
using Tutor.Core.DomainModel;
using Tutor.Core.InstructorModel;
using Tutor.Core.LearnerModel;
using Tutor.Core.LearnerModel.DomainOverlay;
using Tutor.Infrastructure.Database.EventStore;
using Tutor.Web.Controllers.Analytics;
using Tutor.Web.Controllers.Domain;
using Tutor.Web.Controllers.Instructors;
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

        protected KcMasteryController SetupKcmController(IServiceScope scope, string id)
        {
            return new KcMasteryController(Factory.Services.GetRequiredService<IMapper>(),
                scope.ServiceProvider.GetRequiredService<IKcMasteryService>())
            {
                ControllerContext = BuildContext(id, "learner")
            };
        }

        protected InstructorController SetupInstructorController(IServiceScope scope, string id)
        {
            return new InstructorController(Factory.Services.GetRequiredService<IMapper>(),
                scope.ServiceProvider.GetRequiredService<IInstructorService>())
            {
                ControllerContext = BuildContext(id, "instructor")
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

        protected LearnerAssessmentController SetupAssessmentsController(IServiceScope scope, string id)
        {
            return new LearnerAssessmentController(Factory.Services.GetRequiredService<IMapper>(),
                scope.ServiceProvider.GetRequiredService<ILearnerAssessmentService>())
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
