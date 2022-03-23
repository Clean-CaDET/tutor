namespace Tutor.Web.Controllers.Domain.DTOs
{
    public class KnowledgeComponentStatisticsDto
    {
        public double Mastery { get; set; }
        public int NumberOfAssessmentEvents { get; set; }
        public int NumberOfCompletedAssessmentEvents { get; set; }
        public int NumberOfTriedAssessmentEvents { get; set; }
        public bool IsSatisfied { get; set; }
    }
}