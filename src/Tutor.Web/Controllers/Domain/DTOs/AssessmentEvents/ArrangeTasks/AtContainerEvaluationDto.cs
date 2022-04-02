using System.Collections.Generic;

namespace Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents.ArrangeTasks
{
    public class AtContainerEvaluationDto
    {
        public int Id { get; set; }
        public List<AtElementDto> CorrectElements { get; set; }
    }
}