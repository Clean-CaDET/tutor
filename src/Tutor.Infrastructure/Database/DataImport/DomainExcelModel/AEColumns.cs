using System.Collections.Generic;

namespace Tutor.Infrastructure.Database.DataImport.DomainExcelModel
{
    public class AEColumns
    {
        public int Id { get; internal set; }
        public int KnowledgeComponentId { get; internal set; }

        public string Type { get; internal set; }

        public string Text { get; internal set; }
        public List<string> Items { get; internal set; }
        public int Order { get; set; }
    }
}
