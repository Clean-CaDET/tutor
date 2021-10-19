using System.Collections.Generic;
using Tutor.Web.Controllers.Content.DTOs;

namespace Tutor.Web.Controllers.Progress.DTOs.SubmissionEvaluation
{
    public class ArrangeTaskContainerEvaluationDTO
    {
        public int Id { get; set; }
        public bool SubmissionWasCorrect { get; set; }
        public List<ArrangeTaskElementDTO> CorrectElements { get; set; }
    }
}