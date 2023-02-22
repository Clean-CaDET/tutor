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
using Tutor.Core.Domain.Stakeholders;

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

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Id.ShouldNotBe(0);
        result.Email.ShouldBe(newEntity.Email);
        result.Name.ShouldBe(newEntity.Name);
        result.Surname.ShouldBe(newEntity.Surname);
        var storedAccount = dbContext.Users.FirstOrDefault(u => u.Username == newEntity.Index);
        storedAccount.ShouldNotBeNull();
        storedAccount.Role.ShouldBe(UserRole.Learner);
        var storedEntity = dbContext.Learners.FirstOrDefault(i => i.Index == newEntity.Index);
        storedEntity.ShouldNotBeNull();
        storedEntity.UserId.ShouldBe(storedAccount.Id);
    }

    [Fact]
    public void Register_fails_existing_username()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupLearnerController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();
        var newEntity = new StakeholderAccountDto
        {
            Index = "SU-1-2021",
            Email = "SU-1-2021",
            Name = "pera",
            Surname = "peric",
            Password = "123"
        };

        var result = (ObjectResult)controller.Register(newEntity).Result;
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(409);
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
                Index = "zika@zikic.com",
                Email = "zika@zikic.com",
                Name = "zika",
                Surname = "zikic",
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

        var result = (OkResult)controller.BulkRegister(learners);

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(200);
        foreach (var newEntity in learners)
        {
            var storedAccount = dbContext.Users.FirstOrDefault(u => u.Username == newEntity.Index);
            storedAccount.ShouldNotBeNull();
            var storedEntity = dbContext.Learners.FirstOrDefault(i => i.Index == newEntity.Index);
            storedEntity.ShouldNotBeNull();
            storedEntity.UserId.ShouldBe(storedAccount.Id);
        }
    }

    [Fact]
    public void Register_bulk_fails_existing_username()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupLearnerController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();
        var newEntities = new List<StakeholderAccountDto>
        {
            new StakeholderAccountDto
            {
                Index = "pera@prvi.com",
                Email = "pera@prvi.com",
                Name = "pera",
                Surname = "prvi",
                Password = "123"
            },
            new StakeholderAccountDto
            {
                Index = "pera@drugi.com",
                Email = "pera@drugi.com",
                Name = "pera",
                Surname = "drugi",
                Password = "123"
            },
            new StakeholderAccountDto
            {
                Index = "pera@prvi.com",
                Email = "pera@prvi.com",
                Name = "pera",
                Surname = "prvi",
                Password = "123"
            },
        };

        var result = (ObjectResult)controller.BulkRegister(newEntities);

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(409);
        foreach (var newEntity in newEntities)
        {
            var storedAccount = dbContext.Users.FirstOrDefault(u => u.Username == newEntity.Index);
            storedAccount.ShouldBeNull();
            var storedEntity = dbContext.Learners.FirstOrDefault(i => i.Index == newEntity.Index);
            storedEntity.ShouldBeNull();
        }
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
            Email = "mika@mikic.com",
            Name = "mika",
            Surname = "mikic",
            Password = "123"
        };
        dbContext.Database.BeginTransaction();

        var result = ((OkObjectResult)controller.Update(updatedEntity).Result)?.Value as StakeholderAccountDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Id.ShouldBe(-2);
        result.Email.ShouldBe(updatedEntity.Email);
        result.Name.ShouldBe(updatedEntity.Name);
        result.Surname.ShouldBe(updatedEntity.Surname);

        var storedEntity = dbContext.Learners.FirstOrDefault(i => i.Id == updatedEntity.Id);
        storedEntity.ShouldNotBeNull();
        var storedAccount = dbContext.Users.FirstOrDefault(u => u.Username == updatedEntity.Email);
        storedAccount.ShouldNotBeNull();
        var oldEntity = dbContext.Learners.FirstOrDefault(i => i.Name == "SU-2-2021");
        oldEntity.ShouldBeNull();
    }

    [Fact]
    public void Update_fails_invalid_id()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupLearnerController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();
        var updatedEntity = new StakeholderAccountDto
        {
            Id = -1000,
        };
        dbContext.Database.BeginTransaction();

        var result = (ObjectResult)controller.Update(updatedEntity).Result;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(404);
    }

    [Fact]
    public void Archives()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupLearnerController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();
        dbContext.Database.BeginTransaction();

        var result = ((OkObjectResult)controller.Archive(-3, true).Result)?.Value as StakeholderAccountDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.IsArchived.ShouldBe(true);
        var storedAccount = dbContext.Users.FirstOrDefault(u => u.Id == result.UserId);
        storedAccount.ShouldNotBeNull();
        storedAccount.IsActive.ShouldBe(false);
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
        dbContext.Database.BeginTransaction();

        var result = (OkResult)controller.Delete(-6);

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(200);
        var storedLearner = dbContext.Learners.FirstOrDefault(i => i.Id == -6);
        storedLearner.ShouldBeNull();
        var storedAccount = dbContext.Users.FirstOrDefault(i => i.Id == -6);
        storedAccount.ShouldBeNull();
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