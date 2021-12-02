using System.Collections.Generic;

namespace Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents.ArrangeTask
{
    public class ArrangeTaskContainerEvaluationDto
    {
        public int Id { get; set; }
        public bool SubmissionWasCorrect { get; set; }
        public List<ArrangeTaskElementDto> CorrectElements { get; set; }
    }
}