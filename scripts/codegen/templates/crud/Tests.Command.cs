using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.{{ROLE}}.{{USE_CASE}};
using Tutor.{{MODULE}}.API.Dtos;
using Tutor.{{MODULE}}.API.Public.{{USE_CASE}};
using Tutor.{{MODULE}}.Infrastructure.Database;

namespace Tutor.{{MODULE}}.Tests.Integration.{{USE_CASE}};

// CodeGen v1
[Collection("Sequential")]
public class {{NAME}}CommandTests : Base{{MODULE}}IntegrationTest
{
    public {{NAME}}CommandTests({{MODULE}}TestFactory factory) : base(factory) { }

    // TODO: Ensure test data exists for tests and replace all "-1000" in the generated tests with meaningful IDs.

    [Fact]
    public void Creates()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<{{MODULE}}Context>();
        var newEntity = new {{NAME}}Dto
        {
            // TODO: Add data.
        };

        dbContext.Database.BeginTransaction();
        var result = ((OkObjectResult)controller.Create(newEntity).Result)?.Value as {{NAME}}Dto;
        dbContext.ChangeTracker.Clear();

        result.ShouldNotBeNull();
        result.Id.ShouldNotBe(0);
        // TODO: Assert result contains correct field values
        var storedEntity = dbContext.{{NAME}}s.FirstOrDefault(e => e.Id == result.Id);
        storedEntity.ShouldNotBeNull();
        // TODO: Assert storedEntity contains correct field values
    }

    [Fact]
    public void Updates()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<{{MODULE}}Context>();
        var updatedEntity = new {{NAME}}Dto
        {
            Id = -1000
            // TODO: Add data.
        };
        
        dbContext.Database.BeginTransaction();
        var result = ((OkObjectResult)controller.Update(updatedEntity).Result)?.Value as {{NAME}}Dto;
        dbContext.ChangeTracker.Clear();
        
        result.ShouldNotBeNull();
        result.Id.ShouldBe(-1000);
        // TODO: Assert result contains correct field values
        var updatedEntity = dbContext.{{NAME}}s.FirstOrDefault(e => e.Id == result.Id);
        updatedEntity.ShouldNotBeNull();
        // TODO: Assert updatedEntity contains correct field values
    }

    [Fact]
    public void Deletes()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<{{MODULE}}Context>();
        
        dbContext.Database.BeginTransaction();
        var result = (OkResult)controller.Delete(-1000);
        dbContext.ChangeTracker.Clear();

        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(200);
        var storedEntity = dbContext.{{NAME}}s.FirstOrDefault(i => i.Id == -1000);
        storedEntity.ShouldBeNull();
    }

    private static {{NAME}}Controller CreateController(IServiceScope scope)
    {
        return new {{NAME}}Controller(scope.ServiceProvider.GetRequiredService<I{{NAME}}Service>())
        {
            ControllerContext = BuildContext("-1000", "{{ROLE_L}}")
        };
    }
}