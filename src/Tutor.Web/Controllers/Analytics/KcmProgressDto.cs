using System.Collections.Generic;
using Tutor.Web.Controllers.Learners.DomainOverlay.DTOs;

namespace Tutor.Web.Controllers.Analytics
{
    public class KcmProgressDto
    {
        public int KcId { get; set; }
        public string KcCode { get; set; }
        public string KcName { get; set; }
        public KcMasteryStatisticsDto Statistics { get; set; }
        public List<AssessmentItemMasteryDto> AssessmentItemMasteries { get; set; }
    }
}