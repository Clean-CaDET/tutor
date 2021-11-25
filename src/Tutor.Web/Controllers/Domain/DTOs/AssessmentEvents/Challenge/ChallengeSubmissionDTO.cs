namespace Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents.Challenge
{
    public class ChallengeSubmissionDTO
    {
        public string[] SourceCode { get; set; }
        public int ChallengeId { get; set; }
        public int LearnerId { get; set; }
    }
}
