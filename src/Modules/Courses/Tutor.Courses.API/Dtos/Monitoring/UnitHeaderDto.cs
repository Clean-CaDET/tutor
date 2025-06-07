using Tutor.Courses.API.Dtos.Reflections;

namespace Tutor.Courses.API.Dtos.Monitoring;

public class UnitHeaderDto
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int Order { get; set; }
    public DateTime? BestBefore { get; set; }

    public List<KcHeaderDto>? KnowledgeComponents { get; set; }
    public List<TaskHeaderDto>? Tasks { get; set; }
    public List<ReflectionDto>? Reflections { get; set; }
}