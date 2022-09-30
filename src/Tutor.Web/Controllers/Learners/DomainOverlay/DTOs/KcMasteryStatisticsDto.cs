namespace Tutor.Web.Controllers.Learners.DomainOverlay.DTOs
{
    public class KcMasteryStatisticsDto
    {
        public double Mastery { get; set; }
        public int TotalCount { get; set; }
        public int PassedCount { get; set; }
        public int AttemptedCount { get; set; }
        public bool IsSatisfied { get; set; }
    }
}