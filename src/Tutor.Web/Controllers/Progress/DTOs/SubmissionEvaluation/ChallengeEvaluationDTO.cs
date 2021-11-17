using System.Collections.Generic;
using Tutor.Web.Controllers.Domain.DTOs;

namespace Tutor.Web.Controllers.Progress.DTOs.SubmissionEvaluation
{
    public class ChallengeEvaluationDTO
    {
        public int ChallengeId { get; set; }
        public bool ChallengeCompleted { get; set; }
        public List<ChallengeHintDTO> ApplicableHints { get; set; }
        public LearningObjectDTO SolutionLO { get; set; }
    }
}
