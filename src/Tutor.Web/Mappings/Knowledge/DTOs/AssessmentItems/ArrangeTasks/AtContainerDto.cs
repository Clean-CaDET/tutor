using System.Collections.Generic;

namespace Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems.ArrangeTasks;

public class AtContainerDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public List<AtElementDto> Elements { get; set; }
}