using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.KnowledgeComponents.Core.Domain.Knowledge.AssessmentItems.MultiResponseQuestions;

public class MrqItemEvaluation : ValueObject
{
    public MrqItem FullItem { get; }
    public bool SubmissionWasCorrect { get; }

    public MrqItemEvaluation(MrqItem item, bool isCorrect)
    {
        FullItem = item;
        SubmissionWasCorrect = isCorrect;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return FullItem;
        yield return SubmissionWasCorrect;
    }
}