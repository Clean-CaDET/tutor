using System.Collections.Generic;

namespace Tutor.Core.DomainModel.AssessmentEvents.MultiResponseQuestions
{
    public class MRQSubmission : Submission
    {
        public List<int> SubmittedAnswerIds { get; private set; }
    }
}