using System.Collections.Generic;
using Tutor.Web.Mappings.KnowledgeMastery;

namespace Tutor.Web.Mappings.Enrollments;

public class KcmProgressDto
{
    public int LearnerId { get; set; }
    public int KnowledgeComponentId { get; set; }
    public KcMasteryStatisticsDto Statistics { get; set; }
    public List<AssessmentItemMasteryDto> AssessmentItemMasteries { get; set; }
    public int DurationOfAllSessionsInMinutes { get; set; }
}