using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.{{ROLE}}.{{USE_CASE}};
using Tutor.{{MODULE}}.API.Dtos;
using Tutor.{{MODULE}}.API.Public.{{USE_CASE}};
using Tutor.{{MODULE}}.Core.Domain;
using Tutor.{{MODULE}}.Infrastructure.Database;

namespace Tutor.{{MODULE}}.Tests.Integration.{{USE_CASE}};

// CodeGen v1
[Collection("Sequential")]
public class {{NAME}}CommandTests : Base{{MODULE}}IntegrationTest
{
    public {{NAME}}CommandTests({{MODULE}}TestFactory factory) : base(factory) { }

    // TODO: Ensure test data exists for tests and replace all "-1000" in the generated tests with meaningful IDs.
    // TODO: Remove this class if there are no command tests.

    private static {{NAME}}Controller CreateController(IServiceScope scope)
    {
        return new {{NAME}}Controller(scope.ServiceProvider.GetRequiredService<I{{NAME}}Service>())
        {
            ControllerContext = BuildContext("-1000", "{{ROLE_L}}")
        };
    }
}