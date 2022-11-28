using System.Collections.Generic;

namespace Tutor.Web.Mappings.Knowledge.DTOs;

public class KnowledgeUnitDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<KnowledgeComponentDto> KnowledgeComponents { get; set; }
}