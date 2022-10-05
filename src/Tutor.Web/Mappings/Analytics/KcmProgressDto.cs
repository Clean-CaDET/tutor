using System.Collections.Generic;
using Tutor.Web.Mappings.Mastery;

namespace Tutor.Web.Mappings.Analytics
{
    public class KcmProgressDto
    {
        public int KcId { get; set; }
        public int KcUnitId { get; set; }
        public string KcCode { get; set; }
        public string KcName { get; set; }
        public KcMasteryStatisticsDto Statistics { get; set; }
        public List<AssessmentItemMasteryDto> AssessmentItemMasteries { get; set; }
        
        public int DurationOfFinishedSessionsInMinutes { get; set; }
        
        public int ExpectedDurationInMinutes { get; set; }
    }
}