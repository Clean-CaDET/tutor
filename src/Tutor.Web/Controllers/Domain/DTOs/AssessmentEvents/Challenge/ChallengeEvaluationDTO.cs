using System.Collections.Generic;

namespace Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents.Challenge
{
    public class ChallengeEvaluationDto
    {
        public int AssessmentEventId { get; set; }
        public bool Correct { get; set; }
        public List<ChallengeHintDto> ApplicableHints { get; set; }
    }
}
