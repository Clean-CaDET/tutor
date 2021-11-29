using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.DomainModel.KnowledgeComponents;
using Tutor.Web.Controllers.Domain;
using Tutor.Web.Controllers.Domain.DTOs;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents;
using Tutor.Web.Controllers.Domain.DTOs.InstructionalEvents;
using Xunit;

namespace Tutor.Web.Tests.Integration.Domain
{
    public class KnowledgeComponentTests : BaseIntegrationTest
    {
        public KnowledgeComponentTests(TutorApplicationTestFactory<Startup> factory) : base(factory) {}

        [Fact]
        public void Retrieves_units()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = new KCController(Factory.Services.GetRequiredService<IMapper>(),
                scope.ServiceProvider.GetRequiredService<IKCService>());

            var units = ((OkObjectResult) controller.GetUnits().Result).Value as List<UnitDTO>;

            units.Count.ShouldBe(2);
            units.SelectMany(u => u.KnowledgeComponents).Count().ShouldBe(16);
        }

        [Theory]
        [MemberData(nameof(InstructionalEvents))]
        public void Retrieves_kc_instructional_events(int knowledgeComponentId, int expectedIEsCount)
        {
            using var scope = Factory.Services.CreateScope();
            var controller = new KCController(Factory.Services.GetRequiredService<IMapper>(),
                scope.ServiceProvider.GetRequiredService<IKCService>());

            var IEs = ((OkObjectResult)controller.GetInstructionalEvents(knowledgeComponentId).Result).Value as List<InstructionalEventDTO>;

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

            var IEs = ((OkObjectResult)controller.GetAssessmentEvents(knowledgeComponentId).Result).Value as List<AssessmentEventDTO>;

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
                    2
                }
            };
        }
    }
}
