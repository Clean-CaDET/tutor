using System.Collections.Generic;

namespace Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems.ArrangeTasks
{
    public class AtEvaluationDto
    {
        public List<AtContainerEvaluationDto> ContainerEvaluations { get; set; }
        
        public double CorrectnessLevel { get; set; }
    }
}