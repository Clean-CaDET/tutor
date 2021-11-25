using System.Collections.Generic;

namespace Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents.Challenge
{
    public class ChallengeEvaluationDTO
    {
        public int AssessmentEventId { get; set; }
        public bool Correct { get; set; }
        public List<ChallengeHintDTO> ApplicableHints { get; set; }
        public string SolutionUrl { get; set; }
    }
}
