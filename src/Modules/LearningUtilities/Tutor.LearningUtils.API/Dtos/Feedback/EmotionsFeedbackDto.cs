
namespace Tutor.LearningUtils.API.Dtos.Feedback
{
    public class EmotionsFeedbackDto
    {
        public int LearnerId { get; set; }
        public int KnowledgeComponentId { get; set; }
        public string Comment { get; set; }
    }
}
