using System.Collections.Generic;

namespace Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems.MultiResponseQuestions
{
    public class MrqEvaluationDto
    {
        public List<MrqItemEvaluationDto> ItemEvaluations { get; set; }
        
        public double CorrectnessLevel { get; set; }
    }
}