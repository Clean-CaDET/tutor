namespace Tutor.Web.Controllers.Domain.DTOs
{
    public class KnowledgeComponentStatisticsDto
    {
        public double Mastery { get; set; }
        public int TotalCount { get; set; }
        public int CompletedCount { get; set; }
        public int AttemptedCount { get; set; }
        public bool IsSatisfied { get; set; }
    }
}