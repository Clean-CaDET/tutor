using System.Collections.Generic;

namespace Tutor.Core.DomainModel.AssessmentEvents.ArrangeTasks
{
    public class ArrangeTaskSubmission : Submission
    {
        public List<ArrangeTaskContainerSubmission> Containers { get; private set; }
    }

    public class ArrangeTaskContainerSubmission
    {
        public int Id { get; private set; }
        public int ContainerId { get; private set; }
        public List<int> ElementIds { get; private set; }
    }
}