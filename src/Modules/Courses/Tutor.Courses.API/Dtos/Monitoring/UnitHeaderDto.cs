namespace Tutor.Courses.API.Dtos.Monitoring;

public class UnitHeaderDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Order { get; set; }

    public List<TaskHeaderDto> Tasks { get; set; }
}