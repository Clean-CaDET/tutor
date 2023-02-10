using System.Collections.Generic;
using System.Linq;
using Tutor.Core.BuildingBlocks;

namespace Tutor.Core.Domain.Knowledge.AssessmentItems.ArrangeTasks;

public class ArrangeTaskContainer : ValueObject
{
    public int Id { get; private set; }
    public int ArrangeTaskId { get; private set; }
    public string Title { get; private set; }
    public List<ArrangeTaskElement> Elements { get; private set; }

    public int CountIncorrectElements(List<int> elementIds)
    {
        return elementIds.Count(id => Elements.All(e => e.Id != id));
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Title;
        foreach (var element in Elements)
        {
            yield return element;
        }
    }
}