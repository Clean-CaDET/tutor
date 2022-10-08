namespace Tutor.Web.Mappings.Domain.DTOs.AssessmentItems.Challenges
{
    public class ChallengeSubmissionDto
    {
        public string[] SourceCode { get; set; }
        public int AssessmentItemId { get; set; }
        public int LearnerId { get; set; }
    }
}
