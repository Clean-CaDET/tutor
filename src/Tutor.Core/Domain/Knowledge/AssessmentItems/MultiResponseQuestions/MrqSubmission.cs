using System.Collections.Generic;
using System.Linq;

namespace Tutor.Core.Domain.Knowledge.AssessmentItems.MultiResponseQuestions;

public class MrqSubmission : Submission
{
    public List<int> SubmittedAnswerIds { get; private set; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        return SubmittedAnswerIds.Cast<object>();
    }
}