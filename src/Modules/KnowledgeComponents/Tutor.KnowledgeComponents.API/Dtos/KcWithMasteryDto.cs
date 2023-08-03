using Tutor.KnowledgeComponents.API.Dtos.Knowledge;
using Tutor.KnowledgeComponents.API.Dtos.KnowledgeMastery;

namespace Tutor.KnowledgeComponents.API.Dtos;

public class KcWithMasteryDto
{
    public KnowledgeComponentDto KnowledgeComponent { get; set; }
    public KnowledgeComponentMasteryDto Mastery { get; set; }
}