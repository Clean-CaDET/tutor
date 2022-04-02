using System.Collections.Generic;

namespace Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents.ArrangeTasks
{
    public class AtSubmissionDto
    {
        public int AssessmentEventId { get; set; }
        public int LearnerId { get; set; }
        public List<AtContainerSubmissionDto> Containers { get; set; }
    }
}