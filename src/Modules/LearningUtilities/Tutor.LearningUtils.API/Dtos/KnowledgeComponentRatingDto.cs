
namespace Tutor.LearningUtils.API.Dtos
{
    public class KnowledgeComponentRatingDto
    {
        public int LearnerId { get; set; }
        public int KnowledgeComponentId { get; set; }
        public int Rating { get; set; }
        public string[] Tags { get; set; }
    }
}
