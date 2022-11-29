using System.Collections.Generic;
using Tutor.Core.BuildingBlocks;

namespace Tutor.Core.Domain.Knowledge.AssessmentItems.ArrangeTasks;

public class ArrangeTaskContainerSubmission : ValueObject
{
    public int ArrangeTaskContainerId { get; private set; }
    public List<int> ElementIds { get; private set; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return ArrangeTaskContainerId;
        foreach (var elementId in ElementIds)
        {
            yield return elementId;
        }
    }
}