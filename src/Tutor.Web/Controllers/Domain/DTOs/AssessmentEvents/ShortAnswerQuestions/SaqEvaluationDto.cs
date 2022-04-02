using System.Collections.Generic;

namespace Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents.ShortAnswerQuestions
{
    public class SaqEvaluationDto
    {
        public int AssessmentEventId { get; set; }
        public double CorrectnessLevel { get; set; }
        public List<string> AcceptableAnswers { get; set; }
    }
}
