namespace Tutor.Infrastructure.Database.DataImport.ColumnModel
{
    internal class IEColumns
    {
        public int Id { get; internal set; }
        public int KnowledgeComponentId { get; internal set; }
        public string Type { get; internal set; }
        public string Text { get; internal set; }
        public string Url { get; internal set; }
        public string Caption { get; internal set; }
    }
}
