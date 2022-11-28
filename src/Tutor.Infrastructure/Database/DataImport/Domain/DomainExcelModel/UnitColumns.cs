namespace Tutor.Infrastructure.Database.DataImport.Domain.DomainExcelModel;

public class UnitColumns
{
    public int Id { get; internal set; }
    public string Code { get; internal set; }
    public string Name { get; internal set; }
    public string Description { get; internal set; }
    public int CourseId { get; set; }
}