using System.Collections.Generic;

namespace Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents.ArrangeTask
{
    public class ArrangeTaskContainerSubmissionDTO
    {
        public int ArrangeTaskContainerId { get; set; }
        public List<int> ElementIds { get; set; }
    }
}