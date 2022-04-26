using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.Web.Controllers.Domain.DTOs;
using Tutor.Web.Controllers.Learners.DomainOverlay.DTOs;
using Xunit;

namespace Tutor.Web.Tests.Integration.Learners
{
    [Collection("Sequential")]
    public class EnrollmentTests : BaseWebIntegrationTest
    {
        public EnrollmentTests(TutorApplicationTestFactory<Startup> factory) : base(factory) {}

        [Theory]
        [InlineData(-2, 2)]
        [InlineData(-1, 0)]
        public void Retrieves_enrolled_units(int learnerId, int expectedUnitCount)
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
                        new() {Id = -10, Mastery = new KnowledgeComponentMasteryDto { Mastery = 0.0 }},
                        new() {Id = -11, Mastery = new KnowledgeComponentMasteryDto { Mastery = 0.1 }},
                        new() {Id = -12, Mastery = new KnowledgeComponentMasteryDto { Mastery = 0.2 }},
                        new() {Id = -13, Mastery = new KnowledgeComponentMasteryDto { Mastery = 0.3 }},
                        new() {Id = -14, Mastery = new KnowledgeComponentMasteryDto { Mastery = 0.4 }},
                        new() {Id = -15, Mastery = new KnowledgeComponentMasteryDto { Mastery = 0.5 }}
                    }
                }
            };
        }
    }
}
