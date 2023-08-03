namespace Tutor.KnowledgeComponents.Core.Domain.Knowledge.AssessmentItems.ShortAnswerQuestions;

public class SaqSubmission : Submission
{
    public string Answer { get; private set; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Answer;
    }
}