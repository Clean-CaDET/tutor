using System.Collections.Generic;

namespace Tutor.Infrastructure.Database.DataImport.ColumnModel
{
    internal class AEColumns
    {
        public int Id { get; internal set; }
        public int KnowledgeComponentId { get; internal set; }

        public string Type { get; internal set; }

        public string Text { get; internal set; }
        public List<string> Items { get; internal set; }
    }
}
