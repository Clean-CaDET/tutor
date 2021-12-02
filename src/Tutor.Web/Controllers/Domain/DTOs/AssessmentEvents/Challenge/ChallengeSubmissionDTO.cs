namespace Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents.Challenge
{
    public class ChallengeSubmissionDto
    {
        public string[] SourceCode { get; set; }
        public int AssessmentEventId { get; set; }
        public int LearnerId { get; set; }
    }
}
