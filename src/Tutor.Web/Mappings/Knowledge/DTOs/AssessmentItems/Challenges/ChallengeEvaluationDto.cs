using System.Collections.Generic;

namespace Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems.Challenges
{
    public class ChallengeEvaluationDto
    {
        public bool Correct { get; set; }
        public string SolutionUrl { get; set; }
        public List<ChallengeHintDto> ApplicableHints { get; set; }
    }
}
