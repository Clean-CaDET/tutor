namespace Tutor.KnowledgeComponents.Core.Domain.Knowledge.AssessmentItems.CodeCompletionQuestions;

public class CcqSubmission : Submission
{
    public CcqItem[] Items { get; private set; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Items;
    }
}