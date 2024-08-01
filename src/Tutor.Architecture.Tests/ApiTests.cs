using ArchUnitNET.xUnit;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace Tutor.Architecture.Tests;

public class ApiTests : BaseArchitecturalTests
{
    [Fact]
    public void Controllers_should_have_authorize_attribute()
    {
        var examinedTypes = GetExaminedTypes($"Tutor.API");

        var controllers = Classes().That()
            .ResideInNamespace("Tutor.API.Controllers.([a-zA-Z0-9_.]+)*", true);

        var rule = controllers.Should().HaveAnyAttributes("Microsoft.AspNetCore.Authorization.AuthorizeAttribute");

        rule.Check(Architecture);
    }
}