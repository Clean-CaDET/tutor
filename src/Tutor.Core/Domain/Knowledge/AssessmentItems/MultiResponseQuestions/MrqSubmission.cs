using System.Collections.Generic;

namespace Tutor.Core.Domain.Knowledge.AssessmentItems.MultiResponseQuestions
{
    public class MrqSubmission : Submission
    {
        public List<int> SubmittedAnswerIds { get; private set; }
    }
}