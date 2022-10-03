using System.Collections.Generic;

namespace Tutor.Web.Mappings.Domain.DTOs.AssessmentItems.ArrangeTasks
{
    public class AtSubmissionDto
    {
        public int AssessmentItemId { get; set; }
        public List<AtContainerSubmissionDto> Containers { get; set; }
    }
}