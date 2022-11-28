using System.Collections.Generic;

namespace Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems.ShortAnswerQuestions
{
    public class SaqEvaluationDto : EvaluationDto
    {
        public List<string> AcceptableAnswers { get; set; }
    }
}
