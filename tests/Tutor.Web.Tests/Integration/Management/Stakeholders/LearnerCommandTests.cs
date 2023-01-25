using System.Collections.Generic;
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
using Tutor.Core.UseCases.Monitoring;

namespace Tutor.Web.Tests.Integration.Management.Stakeholders;

[Collection("Sequential")]
public class LearnerCommandTests : BaseWebIntegrationTest
{
    public LearnerCommandTests(TutorApplicationTestFactory<Startup> factory) : base(factory) { }

    [Fact]
    public void Registers()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupLearnerController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();
        var newEntity = new StakeholderAccountDto
        {
            Index = "pera@peric.com",
            Email = "pera@peric.com",
            Name = "pera",
            Surname = "peric",
            Password = "123"
        };

        var result = ((OkObjectResult)controller.Register(newEntity).Result)?.Value as StakeholderAccountDto;

        result.ShouldNotBeNull();
        result.Id.ShouldNotBe(0);
        result.Email.ShouldBe(newEntity.Email);
        result.Name.ShouldBe(newEntity.Name);
        result.Surname.ShouldBe(newEntity.Surname);
        var storedAccount = dbContext.Users.FirstOrDefault(u => u.Username == newEntity.Index);
        storedAccount.ShouldNotBeNull();
        var storedEntity = dbContext.Learners.FirstOrDefault(i => i.Index == newEntity.Index);
        storedEntity.ShouldNotBeNull();
        storedEntity.UserId.ShouldBe(storedAccount.Id);
    }

    [Fact]
    public void Registers_bulk()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupLearnerController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();
        var learners = new List<StakeholderAccountDto> {
            new()
            {
                Index = "tana@tanic.com",
                Email = "tana@tanic.com",
                Name = "tana",
                Surname = "tanic",
                Password = "123"
            },
            new()
            {
                Index = "mika@mikic.com",
                Email = "mika@mikic.com",
                Name = "mika",
                Surname = "mika",
                Password = "123"
            },
            new()
            {
                Index = "steva@stevic.com",
                Email = "steva@stevic.com",
                Name = "steva",
                Surname = "steva",
                Password = "123"
            }
        };

        controller.BulkRegister(learners);

        var storedAccounts = dbContext.Users.Where(u => u.Username == "tana@tanic.com" || u.Username == "mika@mikic.com" || u.Username == "steva@stevic.com").ToList();
        storedAccounts.ShouldNotBeNull();
        storedAccounts.Count.ShouldBe(3);
        var storedLearners = dbContext.Learners.Where(i => i.Index == "tana@tanic.com" || i.Index == "mika@mikic.com" || i.Index== "steva@stevic.com").ToList();
        storedLearners.ShouldNotBeNull();
        storedLearners.Count.ShouldBe(3);
        storedLearners.All(l => storedAccounts.Any(a => a.Id == l.UserId)).ShouldBeTrue();
    }

    [Fact]
    public void Updates()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupLearnerController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();
        var updatedEntity = new StakeholderAccountDto
        {
            Id = -2,
            Email = "pera@peric.com",
            Name = "pera",
            Surname = "peric",
            Password = "123"
        };

        var result = ((OkObjectResult)controller.Update(updatedEntity).Result)?.Value as StakeholderAccountDto;

        result.ShouldNotBeNull();
        result.Id.ShouldBe(-2);
        result.Email.ShouldBe(updatedEntity.Email);
        result.Name.ShouldBe(updatedEntity.Name);
        result.Surname.ShouldBe(updatedEntity.Surname);

        var storedEntity = dbContext.Learners.FirstOrDefault(i => i.Email == updatedEntity.Email);
        storedEntity.ShouldNotBeNull();
        var oldEntity = dbContext.Learners.FirstOrDefault(i => i.Name == "SU-2-2021");
        oldEntity.ShouldBeNull();
    }

    [Fact]
    public void Archives()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupLearnerController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();

        var result = ((OkObjectResult)controller.Archive(-3, true).Result)?.Value as StakeholderAccountDto;

        result.ShouldNotBeNull();
        result.IsArchived.ShouldBe(true);
        //Should expand tests to include account deactivation
        var storedEntity = dbContext.Learners.FirstOrDefault(i => i.Id == -3);
        storedEntity.ShouldNotBeNull();
        storedEntity.IsArchived.ShouldBe(true);
    }

    [Fact]
    public void Deletes()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupLearnerController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();

        var result = (OkResult)controller.Delete(-6);

        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(200);
        //Should expand tests to include account deletion (and for instructor)
        var storedEntity = dbContext.Learners.FirstOrDefault(i => i.Id == -6);
        storedEntity.ShouldBeNull();
    }

    private LearnerController SetupLearnerController(IServiceScope scope)
    {
        return new LearnerController(Factory.Services.GetRequiredService<IMapper>(),
            scope.ServiceProvider.GetRequiredService<ILearnerService>(), scope.ServiceProvider.GetRequiredService<IEnrollmentService>())
        {
            ControllerContext = BuildContext("0", "administrator")
        };
    }
}