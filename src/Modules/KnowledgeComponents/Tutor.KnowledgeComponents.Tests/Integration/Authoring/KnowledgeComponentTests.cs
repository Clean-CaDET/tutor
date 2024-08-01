﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Instructor.Authoring;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge;
using Tutor.KnowledgeComponents.API.Public.Authoring;
using Tutor.KnowledgeComponents.Infrastructure.Database;

namespace Tutor.KnowledgeComponents.Tests.Integration.Authoring;

[Collection("Sequential")]
public class KnowledgeComponentTests : BaseKnowledgeComponentsIntegrationTest
{
    public KnowledgeComponentTests(KnowledgeComponentsTestFactory factory) : base(factory) { }

    [Fact]
    public void Gets_by_unit()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);

        var result = ((OkObjectResult)controller.GetByUnit(-1).Result)?.Value as List<KnowledgeComponentDto>;

        result.ShouldNotBeNull();
        result.Count.ShouldBe(6);
    }

    [Fact]
    public void Gets()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);

        var result = ((OkObjectResult)controller.Get(-15).Result)?.Value as KnowledgeComponentDto;

        result.ShouldNotBeNull();
        result.Id.ShouldBe(-15);
        result.Code.ShouldBe("N05");
    }

    [Fact]
    public void Creates()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<KnowledgeComponentsContext>();
        var newEntity = new KnowledgeComponentDto
        {
            KnowledgeUnitId = -1,
            Code = "TT-5",
            Name = "TT-5"
        };
        dbContext.Database.BeginTransaction();

        var result = ((OkObjectResult)controller.Create(newEntity).Result)?.Value as KnowledgeComponentDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Id.ShouldNotBe(0);
        result.Code.ShouldBe(newEntity.Code);
        result.Name.ShouldBe(newEntity.Name);
        var storedEntity = dbContext.KnowledgeComponents.FirstOrDefault(i => i.Code == newEntity.Code);
        storedEntity.ShouldNotBeNull();
        storedEntity.Id.ShouldBe(result.Id);
    }

    [Fact]
    public void Updates()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<KnowledgeComponentsContext>();
        var updatedEntity = new KnowledgeComponentDto
        {
            Id = -10,
            KnowledgeUnitId = -1,
            Name = "TT-10",
            Code = "TT-10"
        };
        dbContext.Database.BeginTransaction();

        var result = ((OkObjectResult)controller.Update(updatedEntity).Result)?.Value as KnowledgeComponentDto;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Id.ShouldBe(-10);
        result.Code.ShouldBe(updatedEntity.Code);
        var savedEntity = dbContext.KnowledgeComponents.FirstOrDefault(i => i.Code == "TT-10");
        savedEntity.ShouldNotBeNull();
        var oldEntity = dbContext.KnowledgeComponents.FirstOrDefault(i => i.Code == "T-10");
        oldEntity.ShouldBeNull();
    }

    [Fact]
    public void Deletes()
    {
        var kcId = -15;
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<KnowledgeComponentsContext>();
        var originalAiCount = dbContext.AssessmentItems.Count(a => a.KnowledgeComponentId == kcId);
        var originalIiCount = dbContext.InstructionalItems.Count(a => a.KnowledgeComponentId == kcId);
        var originalMasteryCount = dbContext.KcMasteries.Count(m => m.KnowledgeComponentId == kcId);
        dbContext.Database.BeginTransaction();

        var result = (OkResult)controller.Delete(kcId);

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(200);
        var storedEntity = dbContext.KnowledgeComponents.FirstOrDefault(i => i.Id == kcId);
        storedEntity.ShouldBeNull();
        originalAiCount.ShouldNotBe(0);
        originalIiCount.ShouldNotBe(0);
        originalMasteryCount.ShouldNotBe(0);
        dbContext.AssessmentItems.Count(a => a.KnowledgeComponentId == kcId).ShouldBe(0);
        dbContext.InstructionalItems.Count(a => a.KnowledgeComponentId == kcId).ShouldBe(0);
        dbContext.KcMasteries.Count(m => m.KnowledgeComponentId == kcId).ShouldBe(0);
    }

    private static KnowledgeComponentController CreateController(IServiceScope scope)
    {
        return new KnowledgeComponentController(scope.ServiceProvider.GetRequiredService<IKnowledgeComponentService>())
        {
            ControllerContext = BuildContext("-51", "instructor")
        };
    }
}