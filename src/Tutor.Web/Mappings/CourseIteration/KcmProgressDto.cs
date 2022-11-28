using System.Collections.Generic;
using Tutor.Web.Mappings.KnowledgeMastery;

namespace Tutor.Web.Mappings.CourseIteration;

public class KcmProgressDto
{
    public int KnowledgeComponentId { get; set; }
    public KcMasteryStatisticsDto Statistics { get; set; }
    public List<AssessmentItemMasteryDto> AssessmentItemMasteries { get; set; }
    public int DurationOfFinishedSessionsInMinutes { get; set; }
}