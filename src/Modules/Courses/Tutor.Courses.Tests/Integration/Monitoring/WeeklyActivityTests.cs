﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Instructor.Monitoring;
using Tutor.Courses.API.Dtos.Monitoring;
using Tutor.Courses.API.Public.Monitoring;

namespace Tutor.Courses.Tests.Integration.Monitoring;

[Collection("Sequential")]
public class WeeklyActivityTests : BaseCoursesIntegrationTest
{
    public WeeklyActivityTests(CoursesTestFactory factory) : base(factory) {}
    
    [Fact]
    public void Retrieves_unit_headers()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-9999");
        var result = ((OkObjectResult)controller.GetWeeklyUnitsWithTasksAndKcs(-9998, -9999, new DateTime(2023, 10, 25)).Result!).Value as List<UnitHeaderDto>;

        result.ShouldNotBeNull();
        result.Count.ShouldBe(2);
        var kcUnit = result.Find(u => u.Id == -9999);
        kcUnit.ShouldNotBeNull();
        kcUnit.Name.ShouldBe("T-9999");
        kcUnit.KnowledgeComponents.Count.ShouldBe(2);
        kcUnit.KnowledgeComponents.Find(kc => kc.Id == -9999).ShouldNotBeNull();
        kcUnit.KnowledgeComponents.Find(kc => kc.Id == -9998).ShouldNotBeNull();

        var taskUnit = result.Find(u => u.Id == -9998);
        taskUnit.ShouldNotBeNull();
        taskUnit.Name.ShouldBe("T-9998");
        taskUnit.Tasks.Count.ShouldBe(2);
        taskUnit.Tasks.Find(t => t.Id == -9999).ShouldNotBeNull();
        taskUnit.Tasks.Find(t => t.Id == -9998).ShouldNotBeNull();
    }

    private static WeeklyActivityController CreateController(IServiceScope scope, string id)
    {
        return new WeeklyActivityController(scope.ServiceProvider.GetRequiredService<IWeeklyActivityService>())
        {
            ControllerContext = BuildContext(id, "instructor")
        };
    }
}