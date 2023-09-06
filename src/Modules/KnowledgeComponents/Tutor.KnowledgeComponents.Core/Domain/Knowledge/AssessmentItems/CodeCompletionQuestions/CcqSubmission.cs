namespace Tutor.KnowledgeComponents.Core.Domain.Knowledge.AssessmentItems.CodeCompletionQuestions;

public class CcqSubmission : Submission
{
    public string[] Answers { get; private set; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Answers;
    }
}