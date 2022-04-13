namespace Tutor.Web.Controllers.Learners.DTOs.Feedback
{
    public class TutorImprovementFeedbackDto
    {
        public int LearnerId { get; set; }
        public int UnitId { get; set; }
        public string SoftwareComment { get; set; }
        public string ContentComment { get; set; }
    }
}
