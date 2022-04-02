using System.Collections.Generic;

namespace Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents.MultiResponseQuestions
{
    public class MrqEvaluationDto
    {
        public List<MrqItemEvaluationDto> ItemEvaluations { get; set; }
        
        public double CorrectnessLevel { get; set; }
    }
}