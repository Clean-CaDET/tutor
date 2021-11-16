using System.Collections.Generic;

namespace Tutor.Web.Controllers.Units.DTOs
{
    public class UnitKnowledgeComponentDTO
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public List<int> KnowledgeNodeIds { get; private set; }
    }
}