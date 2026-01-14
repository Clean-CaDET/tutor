using Tutor.KnowledgeComponents.API.Dtos.Knowledge.InstructionalItems;

namespace Tutor.KnowledgeComponents.API.Dtos.Knowledge;

public class KnowledgeComponentDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }
    public int? ParentId { get; set; }
    public int KnowledgeUnitId { get; set; }
    public int ExpectedDurationInMinutes { get; set; }
    public string IndexingDegree { get; set; }
    public List<InstructionalItemDto>? InstructionalItems { get; set; }
}