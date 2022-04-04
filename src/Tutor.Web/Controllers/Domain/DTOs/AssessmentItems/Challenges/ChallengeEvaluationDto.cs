using System.Collections.Generic;

namespace Tutor.Web.Controllers.Domain.DTOs.AssessmentItems.Challenges
{
    public class ChallengeEvaluationDto
    {
        public int AssessmentItemId { get; set; }
        public bool Correct { get; set; }
        public string SolutionUrl { get; set; }
        public List<ChallengeHintDto> ApplicableHints { get; set; }
    }
}
