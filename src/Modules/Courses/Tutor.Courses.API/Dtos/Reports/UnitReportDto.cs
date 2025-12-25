namespace Tutor.Courses.API.Dtos.Reports;

public class UnitReportDto
{
    public int UnitId { get; set; }
    public string UnitName { get; set; } = string.Empty;
    public int Order { get; set; }
    public bool IsSatisfied { get; set; }
    public List<MeaningfulReflectionDto> MeaningfulReflections { get; set; } = new();
    public bool ContainsMeaningfulAnswer { get; set; }
}