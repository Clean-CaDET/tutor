using System.Collections.Generic;

namespace Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems.ArrangeTasks;

public class AtContainerSubmissionDto
{
    public int ArrangeTaskContainerId { get; set; }
    public List<int> ElementIds { get; set; }
}