using System.Collections.Generic;
using Tutor.Core.BuildingBlocks;

namespace Tutor.Core.Domain.Knowledge.AssessmentItems;

public abstract class AssessmentItem : Entity
{
    public int KnowledgeComponentId { get; private set; }
    public int Order { get; private set; }
    public List<Hint> Hints { get; private set; }

    protected AssessmentItem() { }

    protected AssessmentItem(int id, int knowledgeComponentId)
    {
        Id = id;
        KnowledgeComponentId = knowledgeComponentId;
    }

    public abstract void ClearFeedback();
    public abstract Evaluation Evaluate(Submission submission);
}