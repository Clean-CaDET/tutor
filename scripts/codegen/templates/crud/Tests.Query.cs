using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.{{ROLE}}.{{USE_CASE}};
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.{{MODULE}}.API.Dtos;
using Tutor.{{MODULE}}.API.Public.{{USE_CASE}};

namespace Tutor.{{MODULE}}.Tests.Integration.{{USE_CASE}};

// CodeGen v1
[Collection("Sequential")]
public class {{NAME}}QueryTests : Base{{MODULE}}IntegrationTest
{
    public {{NAME}}QueryTests({{MODULE}}TestFactory factory) : base(factory) { }
    
    // TODO: Ensure test data exists for tests and replace all "-1000" in the generated tests with meaningful IDs.

    [Fact]
    public void Gets_all()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);

        var result = ((OkObjectResult)controller.GetAll(0, 0).Result)?.Value as PagedResult<{{NAME}}Dto>;

        result.ShouldNotBeNull();
        result.TotalCount.ShouldBe(-1000);
        // TODO: Assert result.Results contains objects with correct field values.
    }

    [Fact]
    public void Gets()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);

        var result = ((OkObjectResult)controller.Get(-1000).Result)?.Value as {{NAME}}Dto;

        result.ShouldNotBeNull();
        // TODO: Assert result contains correct field values.
    }

    private static {{NAME}}Controller CreateController(IServiceScope scope)
    {
        return new {{NAME}}Controller(scope.ServiceProvider.GetRequiredService<I{{NAME}}Service>())
        {
            ControllerContext = BuildContext("-1000", "{{ROLE_L}}")
        };
    }
}