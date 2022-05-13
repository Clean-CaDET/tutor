using System.Collections.Generic;

namespace Tutor.Web.Controllers.Domain.DTOs.AssessmentItems.MultiResponseQuestions
{
    public class MrqSubmissionDto
    {
        public List<MrqItemDto> Answers { get; set; }
        public int AssessmentItemId { get; set; }
    }
}