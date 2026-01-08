using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Administrator.Courses;
using Tutor.Courses.API.Dtos.Groups;
using Tutor.Courses.API.Public.Management;
using Tutor.Courses.Infrastructure.Database;

namespace Tutor.Courses.Tests.Integration.Management;

[Collection("Sequential")]
public class GroupCommandTests : BaseCoursesIntegrationTest
{
    public GroupCommandTests(CoursesTestFactory factory) : base(factory) { }

    [Fact]
    public void Creates()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<CoursesContext>();
        var newEntity = new GroupDto
        {
            Name = "TT-1"
        };
        dbContext.Database.BeginTransaction();

        var result = ((OkObjectResult)controller.Create(-1, newEntity).Result)?.Value as GroupDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Id.ShouldNotBe(0);
        result.Name.ShouldBe(newEntity.Name);
        var storedEntity = dbContext.LearnerGroups.FirstOrDefault(g => g.Name == newEntity.Name);
        storedEntity.ShouldNotBeNull();
        storedEntity.Id.ShouldBe(result.Id);
    }

    [Fact]
    public void Updates()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<CoursesContext>();
        var newEntity = new GroupDto
        {
            Name = "TT-2"
        };
        dbContext.Database.BeginTransaction();

        var result = ((OkObjectResult)controller.Update(-11, newEntity).Result)?.Value as GroupDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Id.ShouldBe(-11);
        result.Name.ShouldBe(newEntity.Name);
        var updatedCourse = dbContext.LearnerGroups.FirstOrDefault(i => i.Name == "TT-2");
        updatedCourse.ShouldNotBeNull();
        var oldCourse = dbContext.LearnerGroups.FirstOrDefault(i => i.Name == "Test Group 2");
        oldCourse.ShouldBeNull();
    }

    [Fact]
    public void Deletes()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<CoursesContext>();
        dbContext.Database.BeginTransaction();

        var result = (OkResult)controller.Delete(-12);

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(200);
        var storedGroup = dbContext.LearnerGroups.FirstOrDefault(i => i.Id == -12);
        storedGroup.ShouldBeNull();
    }

    [Fact]
    public void Creates_wallets_for_new_members()
    {
        using var scope = Factory.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<CoursesContext>();
        var membershipService = scope.ServiceProvider.GetRequiredService<IGroupMembershipService>();
        dbContext.Database.BeginTransaction();

        // Add members to a group, which should trigger wallet creation
        var learnerIds = new List<int> { -6, -7 }; // New learners without existing wallets
        membershipService.CreateMembers(-12, learnerIds);

        dbContext.ChangeTracker.Clear();

        // Verify wallets were created with initial allowance
        var wallet1 = dbContext.TokenWallets.FirstOrDefault(w => w.LearnerId == -6 && w.CourseId == -1);
        wallet1.ShouldNotBeNull();
        wallet1.TotalAllowance.ShouldBe(2000000);
        wallet1.TotalSpent.ShouldBe(0);
        wallet1.RemainingBalance.ShouldBe(2000000);

        var wallet2 = dbContext.TokenWallets.FirstOrDefault(w => w.LearnerId == -7 && w.CourseId == -1);
        wallet2.ShouldNotBeNull();
        wallet2.TotalAllowance.ShouldBe(2000000);
        wallet2.TotalSpent.ShouldBe(0);
        wallet2.RemainingBalance.ShouldBe(2000000);
    }

    [Fact]
    public void Does_not_create_duplicate_wallets()
    {
        using var scope = Factory.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<CoursesContext>();
        var membershipService = scope.ServiceProvider.GetRequiredService<IGroupMembershipService>();
        dbContext.Database.BeginTransaction();

        // Learner -1 already has a wallet in course -1
        var existingWallet = dbContext.TokenWallets.FirstOrDefault(w => w.LearnerId == -1 && w.CourseId == -1);
        var initialAllowance = existingWallet?.TotalAllowance ?? 0;

        // Add learner -1 to another group in the same course
        membershipService.CreateMembers(-12, new List<int> { -1 });

        dbContext.ChangeTracker.Clear();

        // Verify no duplicate wallet was created and allowance unchanged
        var walletCount = dbContext.TokenWallets.Count(w => w.LearnerId == -1 && w.CourseId == -1);
        walletCount.ShouldBe(1);

        var wallet = dbContext.TokenWallets.First(w => w.LearnerId == -1 && w.CourseId == -1);
        wallet.TotalAllowance.ShouldBe(initialAllowance);
    }

    private static GroupController CreateController(IServiceScope scope)
    {
        return new GroupController(scope.ServiceProvider.GetRequiredService<IGroupService>())
        {
            ControllerContext = BuildContext("0", "administrator")
        };
    }
}