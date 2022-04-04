using System.Collections.Generic;

namespace Tutor.Web.Controllers.Domain.DTOs.AssessmentItems.ArrangeTasks
{
    public class AtSubmissionDto
    {
        public int AssessmentItemId { get; set; }
        public int LearnerId { get; set; }
        public List<AtContainerSubmissionDto> Containers { get; set; }
    }
}