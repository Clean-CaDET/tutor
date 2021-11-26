using System.Collections.Generic;

namespace Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents.ArrangeTask
{
    public class ArrangeTaskSubmissionDTO
    {
        public int AssessmentEventId { get; set; }
        public int LearnerId { get; set; }
        public List<ArrangeTaskContainerSubmissionDTO> Containers { get; set; }
    }
}