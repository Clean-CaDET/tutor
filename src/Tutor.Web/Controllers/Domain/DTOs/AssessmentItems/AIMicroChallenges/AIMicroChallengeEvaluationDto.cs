using System.Collections.Generic;

namespace Tutor.Web.Controllers.Domain.DTOs.AssessmentItems.AIMicroChallenges
{
    public class AIMicroChallengeEvaluationDto
    {
        public bool Correct { get; set; }
        public List<AIMicroChallengeHintDto> ApplicableHints { get; set; }
    }
}
