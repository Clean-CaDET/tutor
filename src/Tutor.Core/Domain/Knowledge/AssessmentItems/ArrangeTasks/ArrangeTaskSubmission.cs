using System.Collections.Generic;

namespace Tutor.Core.Domain.Knowledge.AssessmentItems.ArrangeTasks;

public class ArrangeTaskSubmission : Submission
{
    public List<ArrangeTaskContainerSubmission> Containers { get; private set; }
}