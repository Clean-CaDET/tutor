using ArchUnitNET.xUnit;
using Microsoft.AspNetCore.Authorization;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace Tutor.Architecture.Tests;

public class ApiTests : BaseArchitecturalTests
{
    [Fact]
    public void Controllers_should_have_authorize_attribute()
    {
        var examinedTypes = GetExaminedTypes($"Tutor.API");

        var controllers = Classes().That()
            .ResideInNamespaceMatching("Tutor.API.Controllers.([a-zA-Z0-9_.]+)*");

        var rule = controllers.Should().HaveAnyAttributes(typeof(AuthorizeAttribute));

        rule.Check(Architecture);
    }
}