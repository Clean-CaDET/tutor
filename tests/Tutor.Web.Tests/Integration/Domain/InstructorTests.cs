using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Tutor.Core.DomainModel.KnowledgeComponents;
using Tutor.Core.InstructorModel.Instructors;
using Tutor.Web.Controllers.Domain;
using Tutor.Web.Controllers.Domain.DTOs;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents;
using Xunit;

namespace Tutor.Web.Tests.Integration.Domain
{
    public class InstructorTests : BaseIntegrationTest
    {
        public InstructorTests(TutorApplicationTestFactory<Startup> factory) : base(factory) {}
        
        [Fact]
        public void Get_Suitable_Assessment_Event()
        {
            // using var scope = Factory.Services.CreateScope();
            // var controller = new KCController(Factory.Services.GetRequiredService<IMapper>(),
            //     scope.ServiceProvider.GetRequiredService<IKCService>(), scope.ServiceProvider.GetRequiredService<IInstructor>());
            //
            // var suitableAssessmentEvent = ((OkObjectResult) controller.GetSuitableAssessmentEvent().Result).Value as AssessmentEventDto;
        }
    }
}