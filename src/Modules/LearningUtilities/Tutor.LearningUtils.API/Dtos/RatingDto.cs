
namespace Tutor.LearningUtils.API.Dtos
{
    public class RatingDto
    {
        public int LearnerId { get; set; }
        public int KnowledgeComponentId { get; set; }
        public int Rating { get; set; }
        public string[] Tags { get; set; }
    }
}
