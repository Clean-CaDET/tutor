using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.LearnerModel.DomainOverlay;
using Tutor.Infrastructure.Database;
using Tutor.Web.Controllers.Domain;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentItems;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentItems.MultiResponseQuestions;
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
        [MemberData(nameof(AssessmentItemRequest))]
        public void Get_Suitable_Assessment_Event(AssessmentItemRequestDto request, int expectedSuitableAssessmentItemId)
        {
            using var scope = Factory.Services.CreateScope();
            var controller = new KcController(Factory.Services.GetRequiredService<IMapper>(),
                scope.ServiceProvider.GetRequiredService<ILearnerKcMasteryService>());

            var actualSuitableAssessmentItem =
                ((OkObjectResult) controller.GetSuitableAssessmentItem(request).Result)?.Value as AssessmentItemDto;
            actualSuitableAssessmentItem.ShouldNotBeNull();
            
            actualSuitableAssessmentItem.Id.ShouldBe(expectedSuitableAssessmentItemId);
        }
        
        [Theory]
        [MemberData(nameof(MrqSubmission))]
        public void Update_Kc_Mastery(MrqSubmissionDto submission, double expectedKcMastery)
        {
            using var scope = Factory.Services.CreateScope();
            var controller = new SubmissionController(Factory.Services.GetRequiredService<IMapper>(), 
                scope.ServiceProvider.GetRequiredService<ILearnerAssessmentsService>());
            var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();
            var assessmentItem = dbContext.AssessmentItems.FirstOrDefault(ae => ae.Id == submission.AssessmentItemId);
            var knowledgeComponent =
                dbContext.KnowledgeComponents.FirstOrDefault(kc => kc.Id == assessmentItem.KnowledgeComponentId);
            
            controller.SubmitMultipleResponseQuestion(submission);
            
            var actualKcMastery = dbContext.KcMasteries.FirstOrDefault(kcm => kcm.LearnerId == submission.LearnerId
            && kcm.KnowledgeComponent.Id == knowledgeComponent.Id);
            
            actualKcMastery.Mastery.ShouldBe(expectedKcMastery);
        }

        public static IEnumerable<object[]> MrqSubmission()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new MrqSubmissionDto
                    {
                        AssessmentItemId = -106,
                        LearnerId = -3,
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
                        AssessmentItemId = -106,
                        LearnerId = -3,
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
                        AssessmentItemId = -107,
                        LearnerId = -3,
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
                        AssessmentItemId = -107,
                        LearnerId = -3,
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
                        AssessmentItemId = -107,
                        LearnerId = -3,
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
                        AssessmentItemId = -107,
                        LearnerId = -3,
                        Answers = new List<MrqItemDto>
                        {
                            new() {Id = -1072},
                            new() {Id = -1075},
                        }
                    },
                    1.0
                },
                new object[]
                {
                    new MrqSubmissionDto
                    {
                        AssessmentItemId = -106,
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
                        AssessmentItemId = -106,
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
                        AssessmentItemId = -107,
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
                        AssessmentItemId = -107,
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
                        AssessmentItemId = -107,
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
                        AssessmentItemId = -107,
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

        public static IEnumerable<object[]> AssessmentItemRequest()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new AssessmentItemRequestDto
                    {
                        LearnerId = -2,
                        KnowledgeComponentId = -14
                    },
                    -144
                },
                new object[]
                {
                    new AssessmentItemRequestDto
                    {
                        LearnerId = -2,
                        KnowledgeComponentId = -15
                    },
                    -153
                },
                new object[]
                {
                    new AssessmentItemRequestDto
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