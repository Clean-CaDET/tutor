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
public class UnitTests : BaseWebIntegrationTest
{
    public UnitTests(TutorApplicationTestFactory<Startup> factory) : base(factory) { }

    [Fact]
    public void Creates()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();
        var newEntity = new KnowledgeUnitDto
        {
            Code = "TT-5",
            Name = "TT-5"
        };

        var result = ((OkObjectResult)controller.Create(-1, newEntity).Result)?.Value as KnowledgeUnitDto;

        result.ShouldNotBeNull();
        result.Id.ShouldNotBe(0);
        result.Code.ShouldBe(newEntity.Code);
        result.Name.ShouldBe(newEntity.Name);
        var storedEntity = dbContext.KnowledgeUnits.FirstOrDefault(i => i.Code == newEntity.Code);
        storedEntity.ShouldNotBeNull();
        storedEntity.Id.ShouldBe(result.Id);
    }

    [Fact]
    public void Updates()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();
        var updatedEntity = new KnowledgeUnitDto
        {
            Id = -1,
            Code = "TT-1"
        };

        var result = ((OkObjectResult)controller.Update(-1, updatedEntity).Result)?.Value as KnowledgeUnitDto;

        result.ShouldNotBeNull();
        result.Id.ShouldBe(-1);
        result.Code.ShouldBe(updatedEntity.Code);
        var savedEntity = dbContext.KnowledgeUnits.FirstOrDefault(i => i.Code == "TT-1");
        savedEntity.ShouldNotBeNull();
        var oldEntity = dbContext.KnowledgeUnits.FirstOrDefault(i => i.Code == "T-1");
        oldEntity.ShouldBeNull();
    }

    [Fact]
    public void Deletes()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = SetupController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<TutorContext>();

        var result = (OkResult)controller.Delete(-4);

        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(200);

        var storedEntity = dbContext.KnowledgeUnits.FirstOrDefault(i => i.Id == -4);
        storedEntity.ShouldBeNull();
    }

    private UnitController SetupController(IServiceScope scope)
    {
        return new UnitController(Factory.Services.GetRequiredService<IMapper>(),
            scope.ServiceProvider.GetRequiredService<IUnitService>())
        {
            ControllerContext = BuildContext("-51", "instructor")
        };
    }
}