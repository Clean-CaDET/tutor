using System.Collections.Generic;

namespace Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents.MultiResponseQuestions
{
    public class MrqSubmissionDto
    {
        public List<MrqItemDto> Answers { get; set; }
        public int LearnerId { get; set; }
        public int AssessmentEventId { get; set; }
    }
}