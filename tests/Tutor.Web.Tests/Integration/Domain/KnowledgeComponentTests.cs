using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Tutor.Core.LearnerModel.DomainOverlay;
using Tutor.Web.Controllers.Domain;
using Tutor.Web.Controllers.Domain.DTOs;
using Tutor.Web.Controllers.Domain.DTOs.InstructionalItems;
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
            var controller = new KcController(Factory.Services.GetRequiredService<IMapper>(),
                scope.ServiceProvider.GetRequiredService<ILearnerKcMasteryService>());

            var units = ((OkObjectResult) controller.GetUnits().Result).Value as List<UnitDto>;

            units.Count.ShouldBe(2);
        }

        [Theory]
        [MemberData(nameof(KnowledgeComponentMasteries))]
        public void Retrieves_kc_mastery_for_unit(int unitId, List<KnowledgeComponentDto> expectedKCs)
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            var unit = ((OkObjectResult)controller.GetUnit(unitId).Result).Value as UnitDto;

            expectedKCs.All(expectedKc => unit.KnowledgeComponents.Any(
                    kc => expectedKc.Id == kc.Id && expectedKc.Mastery.Mastery == kc.Mastery.Mastery))
                .ShouldBe(true);
        }

        public static IEnumerable<object[]> KnowledgeComponentMasteries()
        {
            return new List<object[]>
            {
                new object[]
                {
                    -1,
                    new List<KnowledgeComponentDto>
                    {
                        new() {Id = -11, Mastery = new KnowledgeComponentMasteryDto { Mastery = 0.1 }},
                        new() {Id = -12, Mastery = new KnowledgeComponentMasteryDto { Mastery = 0.2 }},
                        new() {Id = -13, Mastery = new KnowledgeComponentMasteryDto { Mastery = 0.3 }},
                        new() {Id = -14, Mastery = new KnowledgeComponentMasteryDto { Mastery = 0.4 }},
                        new() {Id = -15, Mastery = new KnowledgeComponentMasteryDto { Mastery = 0.5 }}
                    }
                }
            };
        }

        [Theory]
        [MemberData(nameof(InstructionalItems))]
        public void Retrieves_kc_instructional_events(int knowledgeComponentId, int expectedIEsCount)
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            var IEs = ((OkObjectResult)controller.GetInstructionalItems(knowledgeComponentId).Result).Value as List<InstructionalItemDto>;

            IEs.Count.ShouldBe(expectedIEsCount);
        }

        public static IEnumerable<object[]> InstructionalItems()
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

        [Fact]
        public void Retrieves_kc_statistics()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            var kcMasteryStatistics = ((OkObjectResult)controller.GetKnowledgeComponentStatistics(-15).Result).Value as KnowledgeComponentStatisticsDto;

            kcMasteryStatistics.IsSatisfied.ShouldBe(false);
            kcMasteryStatistics.Mastery.ShouldBe(0.5);
            kcMasteryStatistics.TotalCount.ShouldBe(4);
            kcMasteryStatistics.AttemptedCount.ShouldBe(4);
            kcMasteryStatistics.CompletedCount.ShouldBe(0);
        }

        private KcController SetupController(IServiceScope scope)
        {
            return new KcController(Factory.Services.GetRequiredService<IMapper>(),
                scope.ServiceProvider.GetRequiredService<ILearnerKcMasteryService>())
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
