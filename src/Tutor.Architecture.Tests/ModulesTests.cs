using ArchUnitNET.xUnit;
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