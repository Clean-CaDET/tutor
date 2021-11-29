using System.Collections.Generic;

namespace Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents.ArrangeTask
{
    public class ArrangeTaskContainerEvaluationDTO
    {
        public int Id { get; set; }
        public bool SubmissionWasCorrect { get; set; }
        public List<ArrangeTaskElementDTO> CorrectElements { get; set; }
    }
}