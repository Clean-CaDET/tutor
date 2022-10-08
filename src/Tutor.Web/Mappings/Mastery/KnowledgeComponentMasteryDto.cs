namespace Tutor.Web.Mappings.Mastery
{
    public class KnowledgeComponentMasteryDto
    {
        public int Id { get; set; }
        public double Mastery { get; set; }
        public int KnowledgeComponentId { get; set; }
        public int LearnerId { get; set; }
        public bool IsSatisfied { get; set; }
    }
}