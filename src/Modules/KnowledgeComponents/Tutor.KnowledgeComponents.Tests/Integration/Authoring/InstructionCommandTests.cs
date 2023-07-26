﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Instructor.Authoring;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.InstructionalItems;
using Tutor.KnowledgeComponents.API.Interfaces.Authoring;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.InstructionalItems;
using Tutor.KnowledgeComponents.Infrastructure.Database;
using Xunit;

namespace Tutor.KnowledgeComponents.Tests.Integration.Authoring;

[Collection("Sequential")]
public class InstructionCommandTests : BaseKnowledgeComponentsIntegrationTest
{
    public InstructionCommandTests(KnowledgeComponentsTestFactory factory) : base(factory) { }

    [Fact]
    public void Creates()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-51");
        var dbContext = scope.ServiceProvider.GetRequiredService<KnowledgeComponentsContext>();
        var newEntity = new TextDto
        {
            KnowledgeComponentId = -11,
            Order = 3,
        };
        dbContext.Database.BeginTransaction();

        var result = ((OkObjectResult)controller.Create(newEntity).Result)?.Value as List<InstructionalItemDto>;

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.ShouldNotBeEmpty();
        result.Count.ShouldBe(1);
        var storedEntity = dbContext.InstructionalItems.FirstOrDefault(i => i.Id == result[0].Id);
        storedEntity.ShouldNotBeNull();
        storedEntity.Order.ShouldBe(3);
    }

    [Fact]
    public void Updates()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-51");
        var dbContext = scope.ServiceProvider.GetRequiredService<KnowledgeComponentsContext>();
        var newEntity = new TextDto
        {
            Id = -101,
            KnowledgeComponentId = -10,
            Content = "TT-1"
        };
        dbContext.Database.BeginTransaction();

        var result = ((OkObjectResult)controller.Update(newEntity).Result)?.Value as List<InstructionalItemDto>;
        
        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.ShouldNotBeEmpty();
        result.Count.ShouldBe(1);
        var savedEntity = dbContext.InstructionalItems.FirstOrDefault(i => i.Id == result[0].Id);
        savedEntity.ShouldNotBeNull();
        ((Markdown)savedEntity).Content.ShouldBe(newEntity.Content);
    }

    [Fact]
    public void Updates_ordering()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-51");
        var dbContext = scope.ServiceProvider.GetRequiredService<KnowledgeComponentsContext>();
        var instructionalItems = new List<InstructionalItemDto> {
            new TextDto
            {
                Id = -101,
                KnowledgeComponentId = -10,
                Order = 2,
            },
            new TextDto
            {
                Id = -102,
                KnowledgeComponentId = -10,
                Order = 3,
            },
            new ImageDto
            {
                Id = -103,
                KnowledgeComponentId = -10,
                Order = 1,
            }
        };
        dbContext.Database.BeginTransaction();

        var result = ((OkObjectResult)controller.UpdateOrdering(instructionalItems)).Value as List<InstructionalItemDto>;
        
        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.Count.ShouldBe(3);
        result[0].Id.ShouldBe(-103);
        result[1].Id.ShouldBe(-101);
        result[2].Id.ShouldBe(-102);
        var secondText = dbContext.InstructionalItems.FirstOrDefault(i => i.Id == -101);
        secondText.ShouldNotBeNull();
        secondText.Order.ShouldBe(2);
        var thirdText = dbContext.InstructionalItems.FirstOrDefault(i => i.Id == -102);
        thirdText.ShouldNotBeNull();
        thirdText.Order.ShouldBe(3);
        var firstImage = dbContext.InstructionalItems.FirstOrDefault(i => i.Id == -103);
        firstImage.ShouldNotBeNull();
        firstImage.Order.ShouldBe(1);
    }

    [Fact]
    public void Deletes()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-51");
        var dbContext = scope.ServiceProvider.GetRequiredService<KnowledgeComponentsContext>();
        dbContext.Database.BeginTransaction();

        var result = (OkResult)controller.Delete(-15, -152);

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(200);
        var storedEntity = dbContext.InstructionalItems.FirstOrDefault(i => i.Id == -152);
        storedEntity.ShouldBeNull();
    }

    private static InstructionalItemController CreateController(IServiceScope scope, string id)
    {
        return new InstructionalItemController(scope.ServiceProvider.GetRequiredService<IInstructionalItemsService>())
        {
            ControllerContext = BuildContext(id, "instructor")
        };
    }
}