namespace Tutor.Web.Controllers.Domain.DTOs.Feedback
{
    public class EmotionsFeedbackDto
    {
        public int LearnerId { get; set; }
        public int KnowledgeComponentId { get; set; }
        public string Comment { get; set; }
    }
}
