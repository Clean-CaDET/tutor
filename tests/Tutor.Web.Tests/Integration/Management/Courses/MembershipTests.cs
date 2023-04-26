using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.UseCases.Management.Groups;
using Tutor.Infrastructure.Database;
using Tutor.Web.Controllers.Administrators.Courses;
using Tutor.Web.Mappings.Stakeholders;
using Xunit;

namespace Tutor.Web.Tests.Integration.Management.Courses;

[Collection("Sequential")]
public class MembershipTests : BaseWebIntegrationTest
{
    public MembershipTests(TutorApplicationTestFactory<Startup> factory) : base(factory) { }

    [Fact]
    public void Gets_all()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupController(scope);

        var result = ((OkObjectResult)controller.GetMembers(-1, 0, 0).Result)?.Value as PagedResult<StakeholderAccountDto>;

        result.ShouldNotBeNull();
        result.Results.Count.ShouldBe(4);
        result.TotalCount.ShouldBe(4);
    }

    [Fact]
    public void Creates()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();
        var learners = new List<StakeholderAccountDto>
        {
            new()
            {
                Id = -1
            },
            new()
            {
                Id = -2
            }
        };
        dbContext.Database.BeginTransaction();

        var result = (OkResult)controller.CreateMembers(-3, learners);

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(200);
        var storedMemberships = dbContext.GroupMemberships
            .Where(m => m.LearnerGroupId == -3)
            .Include(m => m.Member).ToList();
        storedMemberships.ShouldNotBeNull();
        storedMemberships.Any(m => m.Member.Id == -1).ShouldBeTrue();
        storedMemberships.Any(m => m.Member.Id == -2).ShouldBeTrue();
    }

    [Fact]
    public void Deletes()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();
        dbContext.Database.BeginTransaction();

        var result = (OkResult)controller.Delete(-11, -1);

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(200);
        var storedCourses = dbContext.GroupMemberships.FirstOrDefault(m => m.Member.Id == -1 && m.LearnerGroupId == -11);
        storedCourses.ShouldBeNull();
    }

    private GroupMembershipController SetupController(IServiceScope scope)
    {
        return new GroupMembershipController(Factory.Services.GetRequiredService<IMapper>(),
            scope.ServiceProvider.GetRequiredService<ILearnerGroupService>())
        {
            ControllerContext = BuildContext("0", "administrator")
        };
    }
}