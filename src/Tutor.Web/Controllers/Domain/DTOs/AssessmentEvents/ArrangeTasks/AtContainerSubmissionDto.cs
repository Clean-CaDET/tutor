using System.Collections.Generic;

namespace Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents.ArrangeTasks
{
    public class AtContainerSubmissionDto
    {
        public int ArrangeTaskContainerId { get; set; }
        public List<int> ElementIds { get; set; }
    }
}