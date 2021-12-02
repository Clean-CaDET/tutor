using System.Collections.Generic;

namespace Tutor.Core.DomainModel.AssessmentEvents.MultiResponseQuestions
{
    public class MrqSubmission : Submission
    {
        public List<int> SubmittedAnswerIds { get; private set; }
    }
}