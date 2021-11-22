using System.Collections.Generic;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents;

namespace Tutor.Web.Controllers.Progress.DTOs.SubmissionEvaluation
{
    public class ArrangeTaskContainerEvaluationDTO
    {
        public int Id { get; set; }
        public bool SubmissionWasCorrect { get; set; }
        public List<ArrangeTaskElementDTO> CorrectElements { get; set; }
    }
}