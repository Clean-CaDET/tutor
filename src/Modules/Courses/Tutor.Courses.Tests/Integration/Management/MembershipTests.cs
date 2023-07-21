﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Administrator.Courses;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Interfaces.Management;
using Tutor.Courses.Infrastructure.Database;

namespace Tutor.Courses.Tests.Integration.Management;

[Collection("Sequential")]
public class MembershipTests : BaseCoursesIntegrationTest
{
    public MembershipTests(CoursesTestFactory factory) : base(factory) { }

    [Fact]
    public void Gets_all()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);

        var result = ((OkObjectResult)controller.GetMembers(-1).Result)?.Value as List<LearnerDto>;

        result.ShouldNotBeNull();
        result.Count.ShouldBe(4);
    }

    [Fact]
    public void Creates()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<CoursesContext>();
        var learners = new List<int> { -1, -2 };
        dbContext.Database.BeginTransaction();

        var result = (OkResult)controller.CreateMembers(-3, learners);

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(200);
        var storedGroup = dbContext.LearnerGroups.First(m => m.Id == -3);
        storedGroup.ShouldNotBeNull();
        storedGroup.LearnerIds.Contains(-1).ShouldBeTrue();
        storedGroup.LearnerIds.Contains(-2).ShouldBeTrue();
    }

    [Fact]
    public void Deletes()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<CoursesContext>();
        dbContext.Database.BeginTransaction();

        var result = (OkResult)controller.Delete(-11, -1);

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(200);
        var storedGroup = dbContext.LearnerGroups.First(m => m.Id == -11);
        storedGroup.ShouldNotBeNull();
        storedGroup.LearnerIds.Contains(-1).ShouldBeFalse();
    }

    private static GroupMembershipController CreateController(IServiceScope scope)
    {
        return new GroupMembershipController(scope.ServiceProvider.GetRequiredService<IGroupMembershipService>())
        {
            ControllerContext = BuildContext("0", "administrator")
        };
    }
}