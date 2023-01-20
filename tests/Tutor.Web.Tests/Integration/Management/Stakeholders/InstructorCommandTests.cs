using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Linq;
using Tutor.Core.UseCases.Management.Stakeholders;
using Tutor.Infrastructure.Database;
using Tutor.Web.Controllers.Administrators.Stakeholders;
using Tutor.Web.Mappings.Stakeholders;
using Xunit;

namespace Tutor.Web.Tests.Integration.Management.Stakeholders;

[Collection("Sequential")]
public class InstructorCommandTests : BaseWebIntegrationTest
{
    public InstructorCommandTests(TutorApplicationTestFactory<Startup> factory) : base(factory) { }

    [Fact]
    public void Saves_instructor()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupInstructorController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();
        var newInstructor = new StakeholderAccountDto
        {
            Email = "pera@peric.com",
            Name = "pera",
            Surname = "peric",
            Password = "123"
        };

        var result = ((OkObjectResult)controller.Register(newInstructor).Result)?.Value as StakeholderAccountDto;

        result.ShouldNotBeNull();
        result.Id.ShouldNotBe(0);
        result.Email.ShouldBe(newInstructor.Email);
        result.Name.ShouldBe(newInstructor.Name);
        result.Surname.ShouldBe(newInstructor.Surname);
        var storedAccount = dbContext.Users.FirstOrDefault(u => u.Username == newInstructor.Email);
        storedAccount.ShouldNotBeNull();
        var storedInstructor = dbContext.Instructors.FirstOrDefault(i => i.Email == newInstructor.Email);
        storedInstructor.ShouldNotBeNull();
        storedInstructor.UserId.ShouldBe(storedAccount.Id);
    }

    [Fact]
    public void Save_instructor_fails_existing_username()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupInstructorController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();
        var newInstructor = new StakeholderAccountDto
        {
            Email = "SU-1-2021",
            Name = "pera",
            Surname = "peric",
            Password = "123"
        };

        var result = (ObjectResult)controller.Register(newInstructor).Result;
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(409);
    }

    [Fact]
    public void Updates_instructor()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupInstructorController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();
        var updatedInstructor = new StakeholderAccountDto
        {
            Id = -51,
            Email = "mika@mikic.com",
            Name = "mika",
            Surname = "mikic",
            Password = "123"
        };

        var result = ((OkObjectResult)controller.Update(updatedInstructor).Result)?.Value as StakeholderAccountDto;

        result.ShouldNotBeNull();
        result.Id.ShouldBe(-51);
        result.Email.ShouldBe(updatedInstructor.Email);
        result.Name.ShouldBe(updatedInstructor.Name);
        result.Surname.ShouldBe(updatedInstructor.Surname);
        
        var storedInstructor = dbContext.Instructors.FirstOrDefault(i => i.Id == updatedInstructor.Id);
        storedInstructor.ShouldNotBeNull();
        var storedAccount = dbContext.Users.FirstOrDefault(u => u.Username == updatedInstructor.Email);
        storedAccount.ShouldNotBeNull();
        var oldInstructor = dbContext.Instructors.FirstOrDefault(i => i.Name == "TestInstructor1");
        oldInstructor.ShouldBeNull();
    }

    [Fact]
    public void Update_instructor_fails_invalid_id()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupInstructorController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();
        var updatedInstructor = new StakeholderAccountDto
        {
            Id = -1000,
        };

        var result = (ObjectResult)controller.Update(updatedInstructor).Result;
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(404);
    }

    [Fact]
    public void Archive_instructor()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupInstructorController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();

        var result = ((OkObjectResult)controller.Archive(-51, true).Result)?.Value as StakeholderAccountDto;

        result.ShouldNotBeNull();
        result.IsArchived.ShouldBe(true);
        var storedAccount = dbContext.Users.FirstOrDefault(u => u.Id == result.UserId);
        storedAccount.ShouldNotBeNull();
        storedAccount.IsActive.ShouldBe(false);
        var storedInstructor = dbContext.Instructors.FirstOrDefault(i => i.Id == -51);
        storedInstructor.ShouldNotBeNull();
        storedInstructor.IsArchived.ShouldBe(true);
    }

    [Fact]
    public void Delete_instructor()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupInstructorController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();

        var result = (OkResult)controller.Delete(-52);

        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(200);

        var storedInstructor = dbContext.Instructors.FirstOrDefault(i => i.Id == -52);
        storedInstructor.ShouldBeNull();
        var storedAccount = dbContext.Users.FirstOrDefault(i => i.Id == -52);
        storedAccount.ShouldBeNull();
    }

    private InstructorController SetupInstructorController(IServiceScope scope)
    {
        return new InstructorController(Factory.Services.GetRequiredService<IMapper>(),
            scope.ServiceProvider.GetRequiredService<IInstructorService>())
        {
            ControllerContext = BuildContext("0", "administrator")
        };
    }
}