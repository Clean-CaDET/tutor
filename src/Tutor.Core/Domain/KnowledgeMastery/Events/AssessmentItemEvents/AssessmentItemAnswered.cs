using Tutor.Core.Domain.Knowledge.AssessmentItems;

namespace Tutor.Core.Domain.KnowledgeMastery.Events.AssessmentItemEvents;

public class AssessmentItemAnswered : AssessmentItemEvent
{
    public Submission Submission { get; set; }
    public Evaluation Evaluation { get; set; }
}