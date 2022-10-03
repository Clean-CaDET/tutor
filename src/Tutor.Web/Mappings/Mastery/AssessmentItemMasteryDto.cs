using System;

namespace Tutor.Web.Mappings.Mastery
{
    public class AssessmentItemMasteryDto
    {
        public int AssessmentItemId { get; set; }
        public int SubmissionCount { get; set; }
        public double Mastery { get; set; }
        public DateTime LastSubmissionTime { get; set; }
    }
}
