using System.Collections.Generic;

namespace Tutor.Core.DomainModel.AssessmentEvents.ArrangeTasks
{
    public class ArrangeTaskSubmission : Submission
    {
        public List<ArrangeTaskContainerSubmission> Containers { get; private set; }
    }
}