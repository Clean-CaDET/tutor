using System.Collections.Generic;

namespace Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems.MultiResponseQuestions
{
    public class MrqEvaluationDto : EvaluationDto
    {
        public List<MrqItemEvaluationDto> ItemEvaluations { get; set; }
    }
}