namespace Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents.ShortAnswerQuestions
{
    public class SaqSubmissionDto
    {
        public int AssessmentEventId { get; set; }
        public int LearnerId { get; set; }
        public string Answer { get; set; }
    }
}
