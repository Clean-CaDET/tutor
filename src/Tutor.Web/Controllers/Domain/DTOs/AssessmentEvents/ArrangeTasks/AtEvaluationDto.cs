using System.Collections.Generic;

namespace Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents.ArrangeTasks
{
    public class AtEvaluationDto
    {
        public List<AtContainerEvaluationDto> ContainerEvaluations { get; set; }
        
        public double CorrectnessLevel { get; set; }
    }
}