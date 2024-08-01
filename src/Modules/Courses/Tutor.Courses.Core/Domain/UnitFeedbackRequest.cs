using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.Courses.Core.Domain;

public class UnitFeedbackRequest : ValueObject
{
    public bool RequestKcFeedback { get; }
    public bool RequestTaskFeedback { get; }

    public UnitFeedbackRequest(bool requestKcFeedback, bool requestTaskFeedback)
    {
        RequestKcFeedback = requestKcFeedback;
        RequestTaskFeedback = requestTaskFeedback;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return RequestKcFeedback;
        yield return RequestTaskFeedback;
    }
}