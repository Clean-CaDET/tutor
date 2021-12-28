using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.Core.DomainModel.KnowledgeComponents;
using Tutor.Core.InstructorModel.Instructors;
using Tutor.Web.Controllers.Domain;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents;
using Xunit;
using Xunit.Abstractions;

namespace Tutor.Web.Tests.Integration.Domain
{
    public class InstructorTests : BaseIntegrationTest
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public InstructorTests(TutorApplicationTestFactory<Startup> factory) : base(factory)
        {
        }

        [Theory]
        [MemberData(nameof(AssessmentEventRequest))]
        public void Get_Suitable_Assessment_Event(AssessmentEventRequestDTO request, int suitableAssessmentEventId)
        {
            using var scope = Factory.Services.CreateScope();
            var controller = new KCController(Factory.Services.GetRequiredService<IMapper>(),
                scope.ServiceProvider.GetRequiredService<IKCService>(),
                scope.ServiceProvider.GetRequiredService<IInstructor>());

            var suitableAssessmentEvent =
                ((OkObjectResult) controller.GetSuitableAssessmentEvent(request).Result)?.Value as AssessmentEventDto;
            suitableAssessmentEvent.ShouldNotBeNull();
            suitableAssessmentEvent.Id.ShouldBe(suitableAssessmentEventId);
        }

        public static IEnumerable<object[]> AssessmentEventRequest()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new AssessmentEventRequestDTO
                    {
                        LearnerId = -1,
                        KnowledgeComponentId = -14
                    },
                    -144
                },
                new object[]
                {
                    new AssessmentEventRequestDTO
                    {
                        LearnerId = -1,
                        KnowledgeComponentId = -15
                    },
                    -153
                },
                new object[]
                {
                    new AssessmentEventRequestDTO
                    {
                        LearnerId = -1,
                        KnowledgeComponentId = -13
                    },
                    -134
                }
            };
        }
    }
}