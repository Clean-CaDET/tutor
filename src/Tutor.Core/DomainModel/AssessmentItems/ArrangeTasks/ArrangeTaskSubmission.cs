using System.Collections.Generic;

namespace Tutor.Core.DomainModel.AssessmentItems.ArrangeTasks
{
    public class ArrangeTaskSubmission : Submission
    {
        public List<ArrangeTaskContainerSubmission> Containers { get; private set; }
    }
}