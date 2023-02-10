using System.Collections.Generic;
using Tutor.Core.BuildingBlocks;

namespace Tutor.Core.Domain.Knowledge.AssessmentItems.ArrangeTasks;

public sealed class ArrangeTaskElement : ValueObject
{
    public int Id { get; private set; }
    public int ArrangeTaskContainerId { get; private set; }
    public string Text { get; private set; }
    public string Feedback { get; private set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Text;
        yield return Feedback;
    }
}