namespace Tutor.Infrastructure.DataImport.Domain.DomainExcelModel;

public class CourseColumns
{
    public int Id { get; internal set; }
    public string Code { get; set; }
    public string Name { get; internal set; }
    public string Description { get; set; }
}