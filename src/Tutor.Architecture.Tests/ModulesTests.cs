using ArchUnitNET.xUnit;
using Shouldly;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace Tutor.Architecture.Tests;

public class ModulesTests : BaseArchitecturalTests
{
    [Theory]
    [MemberData(nameof(GetModules))]
    public void API_projects_should_only_reference_themselves_and_core_building_blocks(string moduleName)
    {
        var examinedTypes = GetExaminedTypes($"Tutor.{moduleName}.API");
        var forbiddenTypes = GetForbiddenTypes("Tutor.BuildingBlocks.Core", $"Tutor.{moduleName}.API");

        var rule = Types().That().Are(examinedTypes).Should().NotDependOnAny(forbiddenTypes);

        rule.Check(Architecture);
    }

    [Theory]
    [MemberData(nameof(GetModules))]
    public void Core_projects_should_only_reference_themselves_API_projects_and_core_building_blocks(string moduleName)
    {
        var examinedTypes = GetExaminedTypes($"Tutor.{moduleName}.Core");
        var forbiddenTypes = GetForbiddenTypes("Tutor.BuildingBlocks.Core", "Tutor\\..+\\.API", $"Tutor.{moduleName}.Core");

        var rule = Types().That().Are(examinedTypes).Should().NotDependOnAny(forbiddenTypes);

        rule.Check(Architecture);
    }

    [Theory]
    [MemberData(nameof(GetModules))]
    public void Infra_projects_should_only_reference_themselves_their_API_and_core_projects_and_building_blocks(string moduleName)
    {
        var examinedTypes = GetExaminedTypes($"Tutor.{moduleName}.Infrastructure");
        var forbiddenTypes = GetForbiddenTypes("Tutor.BuildingBlocks.", $"Tutor.{moduleName}.");

        var rule = Types().That().Are(examinedTypes).Should().NotDependOnAny(forbiddenTypes);

        rule.Check(Architecture);
    }

    [Theory]
    [MemberData(nameof(GetModules))]
    public void Domain_namespaces_should_only_reference_themselves_and_core_building_blocks(string moduleName)
    {
        var allTypesFromCoreAssembly = GetExaminedTypes($"Tutor.{moduleName}.Core").ToList();
        var domainTypes = allTypesFromCoreAssembly.Where(x => x.FullName.Contains(".Domain.")).ToList();
        var nonDomainTypes = allTypesFromCoreAssembly.Where(x => !x.FullName.Contains(".Domain."));
        var typesFromOtherAssemblies = GetForbiddenTypes("Tutor.BuildingBlocks.Core", $"Tutor.{moduleName}.Core");

        var otherAssemblyRule = Types().That().Are(domainTypes).Should().NotDependOnAny(typesFromOtherAssemblies);
        var sameAssemblyRule = Types().That().Are(domainTypes).Should().NotDependOnAny(nonDomainTypes);

        otherAssemblyRule.Check(Architecture);
        sameAssemblyRule.Check(Architecture);
    }

    public static IEnumerable<object[]> GetModules() => new List<object[]>
    {
        new object[]
        {
            "Stakeholders"
        },
        new object[]
        {
            "Courses"
        },
        new object[]
        {
            "KnowledgeComponents"
        },
        new object[]
        {
            "LearningUtils"
        },
    };
}