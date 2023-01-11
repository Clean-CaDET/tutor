namespace Tutor.Web.Mappings.Knowledge.DTOs;

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
}