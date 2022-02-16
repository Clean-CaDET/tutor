using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.Infrastructure.Security.Authorization;
using Tutor.Web.Controllers.Learners;
using Tutor.Web.Controllers.Learners.DTOs;
using Tutor.Web.IAM;
using Xunit;

namespace Tutor.Web.Tests.Integration.Learner
{
    [Collection("Sequential")]
    public class LearnerTests : BaseIntegrationTest
    {
        public LearnerTests(TutorApplicationTestFactory<Startup> factory) : base(factory) {}

        [Fact]
        public void Successfully_1_register()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = new LearnerController(Factory.Services.GetRequiredService<IMapper>(),
                scope.ServiceProvider.GetRequiredService<IAuthProvider>(),
                scope.ServiceProvider.GetRequiredService<IAuthService>());
            var loginSubmission = new LearnerDto {StudentIndex = "TT-3-2021", Password = "123"};

            var authenticationResponse =  controller.Register(loginSubmission).Result.Value;

            authenticationResponse?.Id.ShouldBe(1);
        }

        [Fact]
        public void Successfully_2_login()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = new LearnerController(Factory.Services.GetRequiredService<IMapper>(),
                scope.ServiceProvider.GetRequiredService<IAuthProvider>(),
                scope.ServiceProvider.GetRequiredService<IAuthService>());
            var loginSubmission = new LoginDto {StudentIndex = "TT-3-2021", Password = "123"};

            var authenticationResponse = ((OkObjectResult) controller.Login(loginSubmission).Result)?.Value as AuthenticationResponse;

            authenticationResponse?.Id.ShouldBe(1);
        }

        [Fact]
        public void Nonexisting_user_login()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = new LearnerController(Factory.Services.GetRequiredService<IMapper>(),
                scope.ServiceProvider.GetRequiredService<IAuthProvider>(),
                scope.ServiceProvider.GetRequiredService<IAuthService>());
            var loginSubmission = new LoginDto {StudentIndex = "SA-1-2021", Password = "123"};

            var code = ((NotFoundObjectResult) controller.Login(loginSubmission).Result).StatusCode;

            code.ShouldBe(404);
        }
    }
}