namespace Tutor.Infrastructure.DataImport.Domain.DomainExcelModel;

public class IeColumns
{
    public int Id { get; internal set; }
    public int KnowledgeComponentId { get; internal set; }
    public string Type { get; internal set; }
    public string Text { get; internal set; }
    public string Url { get; internal set; }
    public string Caption { get; internal set; }
    public int Order { get; set; }
}