using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Administrator.Stakeholders;
using Tutor.Stakeholders.API.Dtos;
using Tutor.Stakeholders.API.Public.Management;
using Tutor.Stakeholders.Core.Domain;
using Tutor.Stakeholders.Infrastructure.Database;

namespace Tutor.Stakeholders.Tests.Integration.ManagementTests;

[Collection("Sequential")]
public class LearnerCommandTests : BaseStakeholdersIntegrationTest
{
    public LearnerCommandTests(StakeholdersTestFactory factory) : base(factory) { }

    [Fact]
    public void Registers()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<StakeholdersContext>();
        var newEntity = new StakeholderAccountDto
        {
            Index = "pera@peric.com",
            Email = "pera@peric.com",
            Name = "pera",
            Surname = "peric",
            Password = "123",
            LearnerType = "Regular"
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
    public void Registers_commercial()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<StakeholdersContext>();
        var newEntity = new StakeholderAccountDto
        {
            Index = "commercial-pera@peric.com",
            Email = "commercial-pera@peric.com",
            Name = "pera",
            Surname = "peric",
            Password = "123",
            LearnerType = "Commercial"
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
        storedAccount.Role.ShouldBe(UserRole.LearnerCommercial);
        var storedEntity = dbContext.Learners.FirstOrDefault(i => i.Index == newEntity.Index);
        storedEntity.ShouldNotBeNull();
        storedEntity.UserId.ShouldBe(storedAccount.Id);
    }

    [Fact]
    public void Register_fails_existing_username()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<StakeholdersContext>();
        var newEntity = new StakeholderAccountDto
        {
            Index = "SU-1-2021",
            Email = "SU-1-2021",
            Name = "pera",
            Surname = "peric",
            Password = "123",
            LearnerType = "Regular"
        };

        var result = (ObjectResult)controller.Register(newEntity).Result;
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(400);
    }

    [Fact]
    public void Register_fails_invalid_learner_type()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<StakeholdersContext>();
        var newEntity = new StakeholderAccountDto
        {
            Index = "SU-1-2021",
            Email = "SU-1-2021",
            Name = "pera",
            Surname = "peric",
            Password = "123",
            LearnerType = "perica"
        };

        var result = (ObjectResult)controller.Register(newEntity).Result;
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(400);
    }

    [Fact]
    public void Registers_bulk()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<StakeholdersContext>();
        var learners = new List<StakeholderAccountDto> {
            new()
            {
                Index = "tana@tanic.com",
                Email = "tana@tanic.com",
                Name = "tana",
                Surname = "tanic",
                Password = "123",
                LearnerType = "Regular"
            },
            new()
            {
                Index = "zika@zikic.com",
                Email = "zika@zikic.com",
                Name = "zika",
                Surname = "zikic",
                Password = "123",
                LearnerType = "Regular"
            },
            new()
            {
                Index = "steva@stevic.com",
                Email = "steva@stevic.com",
                Name = "steva",
                Surname = "steva",
                Password = "123",
                LearnerType = "Regular"
            }
        };

        var result = ((OkObjectResult)controller.BulkRegister(learners).Result)?.Value as List<StakeholderAccountDto>;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Count.ShouldBe(3);
        foreach (var newEntity in learners)
        {
            var storedAccount = dbContext.Users.FirstOrDefault(u => u.Username == newEntity.Index);
            storedAccount.ShouldNotBeNull();
            storedAccount.Role.ShouldBe(UserRole.Learner);
            var storedEntity = dbContext.Learners.FirstOrDefault(i => i.Index == newEntity.Index);
            storedEntity.ShouldNotBeNull();
            storedEntity.UserId.ShouldBe(storedAccount.Id);
        }
    }

    [Fact]
    public void Register_bulk_commercial()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<StakeholdersContext>();
        var learners = new List<StakeholderAccountDto> {
            new()
            {
                Index = "commercial-tana@tanic.com",
                Email = "commercial-tana@tanic.com",
                Name = "tana",
                Surname = "tanic",
                Password = "123",
                LearnerType = "Commercial"
            },
            new()
            {
                Index = "commercial-zika@zikic.com",
                Email = "commercial-zika@zikic.com",
                Name = "zika",
                Surname = "zikic",
                Password = "123",
                LearnerType = "Commercial"
            },
            new()
            {
                Index = "commercial-steva@stevic.com",
                Email = "commercial-steva@stevic.com",
                Name = "steva",
                Surname = "steva",
                Password = "123",
                LearnerType = "Commercial"
            }
        };

        var result = ((OkObjectResult)controller.BulkRegister(learners).Result)?.Value as List<StakeholderAccountDto>;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Count.ShouldBe(3);
        foreach (var newEntity in learners)
        {
            var storedAccount = dbContext.Users.FirstOrDefault(u => u.Username == newEntity.Index);
            storedAccount.ShouldNotBeNull();
            storedAccount.Role.ShouldBe(UserRole.LearnerCommercial);
            var storedEntity = dbContext.Learners.FirstOrDefault(i => i.Index == newEntity.Index);
            storedEntity.ShouldNotBeNull();
            storedEntity.UserId.ShouldBe(storedAccount.Id);
        }
    }

    [Fact]
    public void Registers_bulk_fails_mixed_learner_types()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var learners = new List<StakeholderAccountDto> {
            new()
            {
                Index = "tana@tanic.com",
                Email = "tana@tanic.com",
                Name = "tana",
                Surname = "tanic",
                Password = "123",
                LearnerType = "Regular"
            },
            new()
            {
                Index = "zika@zikic.com",
                Email = "zika@zikic.com",
                Name = "zika",
                Surname = "zikic",
                Password = "123",
                LearnerType = "Commercial"
            },
            new()
            {
                Index = "steva@stevic.com",
                Email = "steva@stevic.com",
                Name = "steva",
                Surname = "steva",
                Password = "123",
                LearnerType = "Regular"
            }
        };

        var result = (ObjectResult)controller.BulkRegister(learners).Result;

        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(400);
    }

    [Fact]
    public void Register_bulk_with_existing_username()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<StakeholdersContext>();

        var learners = new List<StakeholderAccountDto>
        {
            new()
            {
                Index = "SU-1-2021",
                Email = "SU-1-2021",
                Name = "pera",
                Surname = "peric",
                Password = "123",
                LearnerType = "Regular"
            },
            new()
            {
                Index = "pera@prvi.com",
                Email = "pera@prvi.com",
                Name = "pera",
                Surname = "prvi",
                Password = "123",
                LearnerType = "Regular"
            },
            new()
            {
                Index = "pera@drugi.com",
                Email = "pera@drugi.com",
                Name = "pera",
                Surname = "drugi",
                Password = "123",
                LearnerType = "Regular"
            },
        };

        var result = (ObjectResult)controller.BulkRegister(learners).Result;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(409);
    }

    [Fact]
    public void Updates()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<StakeholdersContext>();
        var updatedLearner = new StakeholderAccountDto
        {
            Id = -2,
            Email = "mika@mikic.com",
            Index = "XX-1-2023",
            Name = "mika",
            Surname = "mikic",
            Password = "123",
        };
        dbContext.Database.BeginTransaction();

        var result = ((OkObjectResult)controller.Update(updatedLearner).Result)?.Value as StakeholderAccountDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Id.ShouldBe(-2);
        result.Index.ShouldBe(updatedLearner.Index);
        result.Email.ShouldBe(updatedLearner.Email);
        result.Name.ShouldBe(updatedLearner.Name);
        result.Surname.ShouldBe(updatedLearner.Surname);

        var storedLearner = dbContext.Learners.FirstOrDefault(i => i.Id == updatedLearner.Id);
        storedLearner.ShouldNotBeNull();
        var storedAccount = dbContext.Users.FirstOrDefault(u => u.Username == updatedLearner.Index);
        storedAccount.ShouldNotBeNull();
        var oldLearner = dbContext.Learners.FirstOrDefault(i => i.Name == "SU-2-2021");
        oldLearner.ShouldBeNull();
    }

    [Fact]
    public void Update_fails_invalid_id()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<StakeholdersContext>();
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

    // Potential bug cause: learner update should not change username or should be more explicit about it
    [Fact]
    public void Update_fails_username_overlaps_with_email()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<StakeholdersContext>();
        // User Username field becomes Learner Email field, but was Learner Index field
        // Given email already exists
        // Stakeholder hierarchy problem
        var updatedEntity = new StakeholderAccountDto
        {
            Id = -2,
            Email = "email@email.com",
            Name = "mika",
            Surname = "mikic",
            Password = "123",
        };
        dbContext.Database.BeginTransaction();

        var result = (ObjectResult)controller.Update(updatedEntity).Result;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(409);
    }

    [Fact]
    public void Archives()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<StakeholdersContext>();
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

    [Theory]
    [InlineData(-6)]
    [InlineData(-2)]
    public void Deletes(int learnerId)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<StakeholdersContext>();
        dbContext.Database.BeginTransaction();

        var result = (OkResult)controller.Delete(learnerId);

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(200);
        var storedLearner = dbContext.Learners.FirstOrDefault(i => i.Id == learnerId);
        storedLearner.ShouldBeNull();
        var storedAccount = dbContext.Users.FirstOrDefault(i => i.Id == learnerId);
        storedAccount.ShouldBeNull();
        // TODO: Examine endpoint for deletion
        // var unitEnrollment = dbContext.UnitEnrollments.FirstOrDefault(i => i.LearnerId == learnerId);
        // unitEnrollment.ShouldBeNull();
        // var groupMembership = dbContext.GroupMemberships.Include(i => i.Member).FirstOrDefault(i => i.Member.Id == learnerId);
        // groupMembership.ShouldBeNull();
    }

    private static LearnerController CreateController(IServiceScope scope)
    {
        return new LearnerController(scope.ServiceProvider.GetRequiredService<ILearnerService>())
        {
            ControllerContext = BuildContext("0", "administrator")
        };
    }
}