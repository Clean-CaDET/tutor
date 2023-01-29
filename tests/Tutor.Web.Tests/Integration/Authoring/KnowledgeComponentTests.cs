using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Linq;
using Tutor.Core.UseCases.Management.Knowledge;
using Tutor.Infrastructure.Database;
using Tutor.Web.Controllers.Instructors.Authoring;
using Tutor.Web.Mappings.Knowledge.DTOs;
using Xunit;

namespace Tutor.Web.Tests.Integration.Authoring;

[Collection("Sequential")]
public class KnowledgeComponentTests : BaseWebIntegrationTest
{
    public KnowledgeComponentTests(TutorApplicationTestFactory<Startup> factory) : base(factory) { }

    [Fact]
    public void Gets()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupController(scope);

        var result = ((OkObjectResult)controller.Get(-15).Result)?.Value as KnowledgeComponentDto;

        result.ShouldNotBeNull();
        result.Id.ShouldBe(-15);
        result.Code.ShouldBe("N05");
    }

    [Fact]
    public void Creates()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();
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
        var controller = SetupController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();
        var updatedEntity = new KnowledgeComponentDto
        {
            Id = -10,
            KnowledgeUnitId = -1,
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
        using var scope = Factory.Services.CreateScope();
        var controller = SetupController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();
        dbContext.Database.BeginTransaction();

        var result = (OkResult)controller.Delete(-11);

        dbContext.ChangeTracker.Clear();
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(200);
        var storedEntity = dbContext.KnowledgeComponents.FirstOrDefault(i => i.Id == -11);
        storedEntity.ShouldBeNull();
    }

    private KnowledgeComponentController SetupController(IServiceScope scope)
    {
        return new KnowledgeComponentController(Factory.Services.GetRequiredService<IMapper>(),
            scope.ServiceProvider.GetRequiredService<IKnowledgeComponentService>())
        {
            ControllerContext = BuildContext("-51", "instructor")
        };
    }
}