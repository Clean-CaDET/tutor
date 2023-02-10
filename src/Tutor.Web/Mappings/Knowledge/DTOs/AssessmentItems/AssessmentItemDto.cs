using System.Collections.Generic;

namespace Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems;

public class AssessmentItemDto
{
    public int Id { get; set; }
    public int KnowledgeComponentId { get; set; }
    public int Order { get; set; }
    public List<string> Hints { get; set; }
}