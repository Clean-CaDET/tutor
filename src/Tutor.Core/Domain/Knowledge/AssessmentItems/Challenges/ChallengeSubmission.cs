using System.Collections.Generic;

namespace Tutor.Core.Domain.Knowledge.AssessmentItems.Challenges;

public class ChallengeSubmission : Submission
{
    public string[] SourceCode { get; private set; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        return SourceCode;
    }
}