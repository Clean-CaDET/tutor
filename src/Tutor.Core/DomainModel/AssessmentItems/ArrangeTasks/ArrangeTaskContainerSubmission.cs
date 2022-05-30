using System.Collections.Generic;

namespace Tutor.Core.DomainModel.AssessmentItems.ArrangeTasks
{
    public class ArrangeTaskContainerSubmission
    {
        public int ArrangeTaskContainerId { get; private set; }
        public List<int> ElementIds { get; private set; }
    }
}