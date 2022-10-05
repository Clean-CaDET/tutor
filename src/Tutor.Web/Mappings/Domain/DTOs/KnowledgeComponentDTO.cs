using System.Collections.Generic;
using Tutor.Web.Mappings.Mastery;

namespace Tutor.Web.Mappings.Domain.DTOs
{
    public class KnowledgeComponentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<KnowledgeComponentDto> KnowledgeComponents { get; set; }
        public KnowledgeComponentMasteryDto Mastery { get; set; }
    }
}