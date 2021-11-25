using System.Collections.Generic;

namespace Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents.MultiResponseQuestion
{
    public class MRQSubmissionDTO
    {
        public List<MRQItemDTO> Answers { get; set; }
        public int LearnerId { get; set; }
        public int AssessmentEventId { get; set; }
    }
}