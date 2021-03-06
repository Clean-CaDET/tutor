using System.Collections.Generic;
using Tutor.Web.Controllers.Learners.DomainOverlay.DTOs;

namespace Tutor.Web.Controllers.Domain.DTOs
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