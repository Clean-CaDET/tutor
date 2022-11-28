using System.Collections.Generic;

namespace Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems.ArrangeTasks
{
    public class AtEvaluationDto : EvaluationDto
    {
        public List<AtContainerEvaluationDto> ContainerEvaluations { get; set; }
    }
}