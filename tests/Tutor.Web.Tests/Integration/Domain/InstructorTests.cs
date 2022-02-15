using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.Core.DomainModel.AssessmentEvents;
using Tutor.Core.DomainModel.KnowledgeComponents;
using Tutor.Core.InstructorModel.Instructors;
using Tutor.Infrastructure.Database;
using Tutor.Web.Controllers.Domain;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents.MultiResponseQuestion;
using Xunit;

namespace Tutor.Web.Tests.Integration.Domain
{
    [Collection("Sequential")]
    public class InstructorTests : BaseIntegrationTest
    {
        public InstructorTests(TutorApplicationTestFactory<Startup> factory) : base(factory)
        {
        }

        [Theory]
        [MemberData(nameof(AssessmentEventRequest))]
        public void Get_Suitable_Assessment_Event(AssessmentEventRequestDto request, int expectedSuitableAssessmentEventId)
        {
            using var scope = Factory.Services.CreateScope();
            var controller = new KCController(Factory.Services.GetRequiredService<IMapper>(),
                scope.ServiceProvider.GetRequiredService<IKCService>(),
                scope.ServiceProvider.GetRequiredService<IAssessmentEventSelector>());

            var actualSuitableAssessmentEvent =
                ((OkObjectResult) controller.GetSuitableAssessmentEvent(request).Result)?.Value as AssessmentEventDto;
            actualSuitableAssessmentEvent.ShouldNotBeNull();
            
            actualSuitableAssessmentEvent.Id.ShouldBe(expectedSuitableAssessmentEventId);
        }
        
        [Theory]
        [MemberData(nameof(MRQSubmission))]
        public void Update_Kc_Mastery(MrqSubmissionDto submission, double expectedKcMastery)
        {
            using var scope = Factory.Services.CreateScope();
            var controller = new SubmissionController(Factory.Services.GetRequiredService<IMapper>(), 
                scope.ServiceProvider.GetRequiredService<ISubmissionService>());
            var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();
            var assessmentEvent = dbContext.AssessmentEvents.FirstOrDefault(ae => ae.Id == submission.AssessmentEventId);
            var knowledgeComponent =
                dbContext.KnowledgeComponents.FirstOrDefault(kc => kc.Id == assessmentEvent.KnowledgeComponentId);
            
            controller.SubmitMultipleResponseQuestion(submission);
            
            var actualKcMastery = dbContext.KcMastery.FirstOrDefault(kcm => kcm.LearnerId == submission.LearnerId
            && kcm.KnowledgeComponentId == knowledgeComponent.Id);
            
            actualKcMastery.Mastery.ShouldBe(expectedKcMastery);
        }

        public static IEnumerable<object[]> MRQSubmission()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new MrqSubmissionDto
                    {
                        AssessmentEventId = -106,
                        LearnerId = -2,
                        Answers = new List<MrqItemDto>
                        {
                            new() {Id = -1062},
                            new() {Id = -1065}
                        }
                    },
                    0.5
                },
                new object[]
                {
                    new MrqSubmissionDto
                    {
                        AssessmentEventId = -106,
                        LearnerId = -2,
                        Answers = new List<MrqItemDto>
                        {
                            new() {Id = -1061},
                            new() {Id = -1065}
                        }
                    },
                    0.5
                },
                new object[]
                {
                    new MrqSubmissionDto
                    {
                        AssessmentEventId = -107,
                        LearnerId = -2,
                        Answers = new List<MrqItemDto>
                        {
                            new() {Id = -1071},
                            new() {Id = -1074},
                            new() {Id = -1073}
                        }
                    },
                    0.5
                },
                new object[]
                {
                    new MrqSubmissionDto
                    {
                        AssessmentEventId = -107,
                        LearnerId = -2,
                        Answers = new List<MrqItemDto>
                        {
                            new() {Id = -1071},
                            new() {Id = -1074},
                            new() {Id = -1073}
                        }
                    },
                    0.5
                },
                new object[]
                {
                    new MrqSubmissionDto
                    {
                        AssessmentEventId = -107,
                        LearnerId = -2,
                        Answers = new List<MrqItemDto>
                        {
                            new() {Id = -1072},
                            new() {Id = -1074},
                        }
                    },
                    0.8
                },
                new object[]
                {
                    new MrqSubmissionDto
                    {
                        AssessmentEventId = -107,
                        LearnerId = -2,
                        Answers = new List<MrqItemDto>
                        {
                            new() {Id = -1072},
                            new() {Id = -1075},
                        }
                    },
                    1.0
                }
            };
        }

        public static IEnumerable<object[]> AssessmentEventRequest()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new AssessmentEventRequestDto
                    {
                        LearnerId = -2,
                        KnowledgeComponentId = -14
                    },
                    -144
                },
                new object[]
                {
                    new AssessmentEventRequestDto
                    {
                        LearnerId = -2,
                        KnowledgeComponentId = -15
                    },
                    -153
                },
                new object[]
                {
                    new AssessmentEventRequestDto
                    {
                        LearnerId = -2,
                        KnowledgeComponentId = -13
                    },
                    -134
                }
            };
        }
    }
}