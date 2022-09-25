using System.Collections.Generic;

namespace Tutor.Web.Controllers.Domain.DTOs;

public class CourseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<UnitDto> KnowledgeUnits { get; set; }
}