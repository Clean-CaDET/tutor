namespace Tutor.Infrastructure.DataImport.Domain.DomainExcelModel;

public class KcColumns
{
    public int Id { get; internal set; }
    public string Code { get; internal set; }
    public string Name { get; internal set; }
    public string Description { get; internal set; }
    public int ExpectedDurationInMinutes { get; internal set; }
    public int UnitId { get; internal set; }
    public int ParentId { get; internal set; }
}