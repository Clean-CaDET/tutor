using System.Collections.Generic;

namespace Tutor.Web.Controllers.Domain.DTOs.AssessmentItems.ShortAnswerQuestions
{
    public class SaqEvaluationDto
    {
        public double CorrectnessLevel { get; set; }
        public List<string> AcceptableAnswers { get; set; }
    }
}
