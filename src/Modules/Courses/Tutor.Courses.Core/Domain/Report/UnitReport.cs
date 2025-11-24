using System.Text.Json.Serialization;
using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.Courses.Core.Domain.Report;

public class UnitReport : ValueObject
{
    public int UnitId { get; }
    public string UnitName { get; }
    public int Order { get; }
    public bool IsSatisfied { get; }
    public List<MeaningfulReflection> MeaningfulReflections { get; }
    public bool ContainsMeaningfulAnswer { get; }
    
    [JsonConstructor]
    public UnitReport(int unitId, string unitName, int order, bool isSatisfied, List<MeaningfulReflection> meaningfulReflections, bool containsMeaningfulAnswer)
    {
        UnitId = unitId;
        UnitName = unitName;
        Order = order;
        IsSatisfied = isSatisfied;
        MeaningfulReflections = meaningfulReflections;
        ContainsMeaningfulAnswer = containsMeaningfulAnswer;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return UnitId;
        yield return IsSatisfied;
        yield return UnitName;
        yield return Order;
        foreach (var reflection in MeaningfulReflections)
        {
            yield return reflection;
        }
        yield return ContainsMeaningfulAnswer;
    }
}