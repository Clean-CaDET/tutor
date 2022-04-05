using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using Tutor.Web.Controllers.Domain.DTOs;
using Tutor.Web.Controllers.Domain.DTOs.InstructionalItems;
using Xunit;

namespace Tutor.Web.Tests.Integration.Domain
{
    [Collection("Sequential")]
    public class KnowledgeComponentTests : BaseWebIntegrationTest
    {
        public KnowledgeComponentTests(TutorApplicationTestFactory<Startup> factory) : base(factory) {}

        [Theory]
        [InlineData(-2, 2)]
        [InlineData(-1, 0)]
        public void Retrieves_units(int learnerId, int expectedUnitCount)
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupKcmController(scope, learnerId.ToString());

            var units = ((OkObjectResult) controller.GetUnits().Result).Value as List<UnitDto>;

            units.Count.ShouldBe(expectedUnitCount);
        }

        [Theory]
        [MemberData(nameof(KnowledgeComponentMasteries))]
        public void Retrieves_kc_mastery_for_unit(int unitId, List<KnowledgeComponentDto> expectedKCs)
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupKcmController(scope, "-2");

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
            var controller = SetupKcmController(scope, "-2");

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
            var controller = SetupKcmController(scope, "-2");

            var kcMasteryStatistics = ((OkObjectResult)controller.GetKnowledgeComponentStatistics(-15).Result).Value as KnowledgeComponentStatisticsDto;

            kcMasteryStatistics.IsSatisfied.ShouldBe(false);
            kcMasteryStatistics.Mastery.ShouldBe(0.5);
            kcMasteryStatistics.TotalCount.ShouldBe(4);
            kcMasteryStatistics.AttemptedCount.ShouldBe(4);
            kcMasteryStatistics.CompletedCount.ShouldBe(0);
        }
    }
}
