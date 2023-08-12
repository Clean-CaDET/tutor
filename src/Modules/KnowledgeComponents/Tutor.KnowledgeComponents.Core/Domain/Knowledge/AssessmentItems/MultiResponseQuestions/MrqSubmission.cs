namespace Tutor.KnowledgeComponents.Core.Domain.Knowledge.AssessmentItems.MultiResponseQuestions;

public class MrqSubmission : Submission
{
    public List<string> SubmittedAnswers { get; private set; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        return SubmittedAnswers;
    }
}