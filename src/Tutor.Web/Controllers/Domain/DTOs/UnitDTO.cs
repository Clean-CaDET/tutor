using System.Collections.Generic;

namespace Tutor.Web.Controllers.Domain.DTOs
{
    public class UnitDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<KnowledgeComponentDto> KnowledgeComponents { get; set; }
    }
}