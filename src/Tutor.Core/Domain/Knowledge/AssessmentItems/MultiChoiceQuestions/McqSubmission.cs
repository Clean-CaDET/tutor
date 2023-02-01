using System.Collections.Generic;

namespace Tutor.Core.Domain.Knowledge.AssessmentItems.MultiChoiceQuestions;

public class McqSubmission : Submission
{
    public string Answer { get; private set; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Answer;
    }
}