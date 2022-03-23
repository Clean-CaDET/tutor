using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Tutor.Core.DomainModel.KnowledgeComponents;
using Tutor.Web.Controllers.Domain;
using Tutor.Web.Controllers.Domain.DTOs;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents;
using Tutor.Web.Controllers.Domain.DTOs.InstructionalEvents;
using Xunit;

namespace Tutor.Web.Tests.Integration.Domain
{
    [Collection("Sequential")]
    public class KnowledgeComponentTests : BaseIntegrationTest
    {
        public KnowledgeComponentTests(TutorApplicationTestFactory<Startup> factory) : base(factory) {}

        [Fact]
        public void Retrieves_units()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = new KCController(Factory.Services.GetRequiredService<IMapper>(),
                scope.ServiceProvider.GetRequiredService<IKCService>());

            var units = ((OkObjectResult) controller.GetUnits().Result).Value as List<UnitDto>;

            units.Count.ShouldBe(2);
        }

        [Theory]
        [MemberData(nameof(InstructionalEvents))]
        public void Retrieves_kc_instructional_events(int knowledgeComponentId, int expectedIEsCount)
        {
            using var scope = Factory.Services.CreateScope();
            var controller = new KCController(Factory.Services.GetRequiredService<IMapper>(),
                scope.ServiceProvider.GetRequiredService<IKCService>());

            var IEs = ((OkObjectResult)controller.GetInstructionalEvents(knowledgeComponentId).Result).Value as List<InstructionalEventDto>;

            IEs.Count.ShouldBe(expectedIEsCount);
        }

        public static IEnumerable<object[]> InstructionalEvents()
        {
            return new List<object[]>
            {
                new object[]
                {
                    -11,
                    2
                },
                new object[]
                {
                    -15,
                    2
                }
            };
        }

        [Theory]
        [MemberData(nameof(AssessmentEvents))]
        public void Retrieves_kc_assessment_events(int knowledgeComponentId, int expectedAEsCount)
        {
            using var scope = Factory.Services.CreateScope();
            var controller = new KCController(Factory.Services.GetRequiredService<IMapper>(),
                scope.ServiceProvider.GetRequiredService<IKCService>());

            var IEs = ((OkObjectResult)controller.GetAssessmentEvents(knowledgeComponentId).Result).Value as List<AssessmentEventDto>;

            IEs.Count.ShouldBe(expectedAEsCount);
        }

        public static IEnumerable<object[]> AssessmentEvents()
        {
            return new List<object[]>
            {
                new object[]
                {
                    -11,
                    0
                },
                new object[]
                {
                    -15,
                    4
                }
            };
        }

        [Fact]
        public void Retrieves_kc_statistics()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            var kcMasteryStatistics = ((OkObjectResult)controller.GetKnowledgeComponentStatistics(-15).Result).Value as KnowledgeComponentStatisticsDto;

            kcMasteryStatistics.IsSatisfied.ShouldBe(false);
            kcMasteryStatistics.Mastery.ShouldBe(0);
            kcMasteryStatistics.NumberOfAssessmentEvents.ShouldBe(4);
            kcMasteryStatistics.NumberOfTriedAssessmentEvents.ShouldBe(4);
            kcMasteryStatistics.NumberOfCompletedAssessmentEvents.ShouldBe(0);
        }

        private KCController SetupController(IServiceScope scope)
        {
            return new KCController(Factory.Services.GetRequiredService<IMapper>(),
                scope.ServiceProvider.GetRequiredService<IKCService>())
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
