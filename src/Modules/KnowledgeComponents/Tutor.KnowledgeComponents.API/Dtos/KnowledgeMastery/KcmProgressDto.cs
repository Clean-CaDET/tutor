namespace Tutor.KnowledgeComponents.API.Dtos.KnowledgeMastery;

public class KcmProgressDto
{
    public int LearnerId { get; set; }
    public int KnowledgeComponentId { get; set; }
    public KcMasteryStatisticsDto Statistics { get; set; }
    public List<AssessmentItemMasteryDto> AssessmentItemMasteries { get; set; }
    public int ActiveSessionInMinutes { get; set; }
}